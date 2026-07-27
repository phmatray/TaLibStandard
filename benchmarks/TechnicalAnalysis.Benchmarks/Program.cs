// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using TechnicalAnalysis.Benchmarks.Benchmarks;
using TechnicalAnalysis.Benchmarks.Configuration;
using TechnicalAnalysis.Benchmarks.Diagnostics;
using TechnicalAnalysis.Benchmarks.Interop;

namespace TechnicalAnalysis.Benchmarks;

/// <summary>
/// Entry point of the TaLibStandard performance benchmark suite.
/// </summary>
/// <remarks>
/// <para>
/// All standard BenchmarkDotNet command line arguments are passed straight through to
/// <see cref="BenchmarkSwitcher"/>, so <c>--list flat</c>, <c>--filter</c>, <c>--anyCategories</c>, <c>--job</c>,
/// <c>--exporters</c> and friends all work as documented upstream.
/// </para>
/// <para>
/// One project-specific flag is recognised before the switcher runs: <c>--selfcheck</c> invokes every benchmark
/// once and asserts it reports success, without producing any timing.
/// </para>
/// </remarks>
public static class Program
{
    /// <summary>
    /// Runs the suite.
    /// </summary>
    /// <param name="args">The BenchmarkDotNet command line arguments.</param>
    /// <returns>Zero on success.</returns>
    public static int Main(string[] args)
    {
        args ??= [];

        bool nativeAvailable = NativeTaLib.IsAvailable;
        PrintBanner(nativeAvailable);

        Type[] runnableTypes = GetRunnableBenchmarkTypes(nativeAvailable);
        if (runnableTypes.Length == 0)
        {
            Console.WriteLine("No benchmark types were discovered. Nothing to do.");
            return 0;
        }

        if (args.Contains(BenchmarkSelfCheck.Flag, StringComparer.OrdinalIgnoreCase))
        {
            return BenchmarkSelfCheck.Run(runnableTypes);
        }

        IConfig config = new TaLibBenchmarkConfig();
        BenchmarkSwitcher.FromTypes(runnableTypes).Run(args, config);

        return 0;
    }

    /// <summary>
    /// Returns every benchmark class that should be offered to <see cref="BenchmarkSwitcher"/>.
    /// </summary>
    /// <param name="nativeAvailable">Whether the native TA-Lib C library was found.</param>
    /// <returns>The runnable benchmark types, in a stable alphabetical order.</returns>
    /// <remarks>
    /// <see cref="NativeComparisonBenchmarks"/> is excluded when the native library is missing, so that
    /// <c>--list</c>, <c>--filter *</c> and an unattended full run never attempt something that cannot work.
    /// </remarks>
    private static Type[] GetRunnableBenchmarkTypes(bool nativeAvailable)
    {
        IEnumerable<Type> candidates = Assembly.GetExecutingAssembly()
            .GetExportedTypes()
            .Where(static type => type is { IsClass: true, IsAbstract: false, IsGenericTypeDefinition: false })
            .Where(static type => type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Any(static method => method.GetCustomAttribute<BenchmarkAttribute>() is not null));

        if (!nativeAvailable)
        {
            candidates = candidates.Where(static type => type != typeof(NativeComparisonBenchmarks));
        }

        return [.. candidates.OrderBy(static type => type.Name, StringComparer.Ordinal)];
    }

    /// <summary>
    /// The horizontal rule drawn around the startup banner.
    /// </summary>
    private const string Rule = "================================================================================";

    private static void PrintBanner(bool nativeAvailable)
    {
        Console.WriteLine(Rule);
        Console.WriteLine(" TaLibStandard performance benchmarks");
        Console.WriteLine(Rule);
        Console.WriteLine(string.Format(
            CultureInfo.InvariantCulture,
            " Runtime      : {0}",
            RuntimeInformation.FrameworkDescription));
        Console.WriteLine(string.Format(
            CultureInfo.InvariantCulture,
            " OS / arch    : {0} / {1}",
            RuntimeInformation.OSDescription.Trim(),
            RuntimeInformation.OSArchitecture));
        Console.WriteLine(string.Format(
            CultureInfo.InvariantCulture,
            " Server GC    : {0}   GC latency mode: {1}   Logical cores: {2}",
            GCSettings.IsServerGC,
            GCSettings.LatencyMode,
            Environment.ProcessorCount));
        Console.WriteLine(Rule);

        if (nativeAvailable)
        {
            Console.WriteLine(string.Format(
                CultureInfo.InvariantCulture,
                " NATIVE TA-LIB: AVAILABLE (resolved from '{0}')",
                NativeTaLib.ResolvedName));
            Console.WriteLine(" NativeComparisonBenchmarks is included. Managed and native outputs are checked for");
            Console.WriteLine(" equivalence in [GlobalSetup] before anything is timed.");
        }
        else
        {
            Console.WriteLine(" NATIVE TA-LIB: NOT AVAILABLE - the managed-versus-C comparison is DISABLED.");
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, " Probe result : {0}", NativeTaLib.Diagnostics));
            Console.WriteLine(" Everything else runs normally; the suite has no native dependency by design.");
            Console.WriteLine(" To enable the comparison, install the TA-Lib C library and re-run:");
            Console.WriteLine("   macOS   : brew install ta-lib");
            Console.WriteLine("   Debian  : apt-get install libta-lib0 libta-lib-dev   (or build from source)");
            Console.WriteLine("   Windows : put ta-lib.dll (or ta_libc_cdr.dll) on PATH or next to the executable");
            Console.WriteLine("   Any OS  : set TALIB_NATIVE_LIBRARY to the full path of the shared library");
        }

        Console.WriteLine(Rule);
        Console.WriteLine();
    }
}
