// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Benchmarks.Diagnostics;

/// <summary>
/// Runs every benchmark method exactly once, outside BenchmarkDotNet, and checks that it actually succeeds.
/// </summary>
/// <remarks>
/// <para>
/// A benchmark that silently measures a validation failure looks fast and means nothing. This self check invokes
/// each <c>[Benchmark]</c> method once at the smallest configured series length and inspects the returned value:
/// a <see cref="RetCode"/>, an <see cref="IndicatorResult"/> or a native return code must all report success, and
/// any thrown exception is reported.
/// </para>
/// <para>
/// Invoke it with <c>-- --selfcheck</c>. It is a correctness gate, never a measurement: no timing is produced or
/// implied.
/// </para>
/// </remarks>
public static class BenchmarkSelfCheck
{
    /// <summary>
    /// The command line flag that triggers the self check.
    /// </summary>
    public const string Flag = "--selfcheck";

    /// <summary>
    /// The series length used by the self check. The smallest configured <c>[Params]</c> value keeps it instant.
    /// </summary>
    private const int SelfCheckLength = 1_000;

    /// <summary>
    /// Runs the self check over the supplied benchmark types.
    /// </summary>
    /// <param name="benchmarkTypes">The benchmark classes to check.</param>
    /// <returns>Zero when every benchmark succeeded, one otherwise.</returns>
    public static int Run(IReadOnlyList<Type> benchmarkTypes)
    {
        ArgumentNullException.ThrowIfNull(benchmarkTypes);

        int checkedCount = 0;
        List<string> failures = [];

        Console.WriteLine(string.Format(
            CultureInfo.InvariantCulture,
            "Self check: invoking every benchmark once with Length = {0}.",
            SelfCheckLength));
        Console.WriteLine();

        foreach (Type type in benchmarkTypes)
        {
            int typeFailures = failures.Count;
            CheckType(type, ref checkedCount, failures);

            Console.WriteLine(string.Format(
                CultureInfo.InvariantCulture,
                "  {0,-32} {1}",
                type.Name,
                failures.Count == typeFailures ? "OK" : "FAILED"));
        }

        Console.WriteLine();

        if (failures.Count == 0)
        {
            Console.WriteLine(string.Format(
                CultureInfo.InvariantCulture,
                "Self check passed: {0} benchmark method(s) all reported success.",
                checkedCount));
            return 0;
        }

        Console.WriteLine(string.Format(
            CultureInfo.InvariantCulture,
            "Self check FAILED: {0} of {1} benchmark method(s) did not report success.",
            failures.Count,
            checkedCount));

        foreach (string failure in failures)
        {
            Console.WriteLine("  " + failure);
        }

        return 1;
    }

    private static void CheckType(Type type, ref int checkedCount, List<string> failures)
    {
        object? instance;

        try
        {
            instance = Activator.CreateInstance(type);
        }
        catch (Exception ex)
        {
            failures.Add($"{type.Name}: could not be instantiated: {Describe(ex)}");
            return;
        }

        if (instance is null)
        {
            failures.Add($"{type.Name}: could not be instantiated.");
            return;
        }

        PropertyInfo? lengthProperty = type.GetProperty("Length", BindingFlags.Public | BindingFlags.Instance);
        lengthProperty?.SetValue(instance, SelfCheckLength);

        MethodInfo? setup = type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault(static method => method.GetCustomAttribute<GlobalSetupAttribute>() is not null);

        try
        {
            setup?.Invoke(instance, null);
        }
        catch (Exception ex)
        {
            failures.Add($"{type.Name}: [GlobalSetup] threw {Describe(ex)}");
            return;
        }

        foreach (MethodInfo method in type
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(static method => method.GetCustomAttribute<BenchmarkAttribute>() is not null)
            .Where(static method => method.GetParameters().Length == 0))
        {
            checkedCount++;

            try
            {
                object? result = method.Invoke(instance, null);
                string? problem = Validate(result);

                if (problem is not null)
                {
                    failures.Add($"{type.Name}.{method.Name}: {problem}");
                }
            }
            catch (Exception ex)
            {
                failures.Add($"{type.Name}.{method.Name}: threw {Describe(ex)}");
            }
        }
    }

    private static string? Validate(object? result)
    {
        return result switch
        {
            null => "returned null",
            RetCode code when code != RetCode.Success => $"returned RetCode.{code}",
            RetCode => null,
            IndicatorResult indicator when indicator.RetCode != RetCode.Success =>
                $"result carries RetCode.{indicator.RetCode}",
            IndicatorResult indicator when indicator.NBElement <= 0 =>
                $"result carries NBElement = {indicator.NBElement.ToString(CultureInfo.InvariantCulture)}",
            IndicatorResult => null,
            int nativeCode when nativeCode != 0 =>
                $"native call returned TA_RetCode {nativeCode.ToString(CultureInfo.InvariantCulture)}",
            _ => null
        };
    }

    private static string Describe(Exception exception)
    {
        Exception effective = exception;

        if (exception is TargetInvocationException { InnerException: { } inner })
        {
            effective = inner;
        }

        return $"{effective.GetType().Name}: {effective.Message}";
    }
}
