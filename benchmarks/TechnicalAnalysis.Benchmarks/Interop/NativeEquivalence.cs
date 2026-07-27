// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;

namespace TechnicalAnalysis.Benchmarks.Interop;

/// <summary>
/// Verifies that the managed TaLibStandard implementation and the native TA-Lib C implementation compute the same
/// thing before either of them is timed.
/// </summary>
/// <remarks>
/// <para>
/// A benchmark that is "faster" because it computes the wrong answer is worse than no benchmark at all. Every
/// head-to-head pair in <c>NativeComparisonBenchmarks</c> is therefore validated in <c>[GlobalSetup]</c>: the
/// alignment metadata (<c>outBegIdx</c> and <c>outNBElement</c>) must match exactly and every produced value must
/// agree within tolerance. A mismatch throws, which BenchmarkDotNet surfaces as a failed benchmark.
/// </para>
/// <para>
/// Both APIs use the same output convention: the buffer is filled from index 0, and output element <c>k</c>
/// corresponds to input index <c>outBegIdx + k</c> for <c>k</c> in <c>[0, outNBElement)</c>. Elements at or beyond
/// <c>outNBElement</c> are meaningless and are never compared.
/// </para>
/// </remarks>
public static class NativeEquivalence
{
    /// <summary>
    /// The default relative tolerance. TA-Lib C and TaLibStandard run the same recurrences in the same order, so
    /// results normally agree to the last few bits; this leaves room for compiler-level reassociation only.
    /// </summary>
    public const double DefaultTolerance = 1e-9;

    /// <summary>
    /// Asserts that two implementations produced the same aligned output series.
    /// </summary>
    /// <param name="indicator">The indicator name, used in the failure message.</param>
    /// <param name="managedBegIdx">The managed <c>outBegIdx</c>.</param>
    /// <param name="managedCount">The managed <c>outNBElement</c>.</param>
    /// <param name="managedValues">The managed output buffer, filled from index zero.</param>
    /// <param name="nativeBegIdx">The native <c>outBegIdx</c>.</param>
    /// <param name="nativeCount">The native <c>outNBElement</c>.</param>
    /// <param name="nativeValues">The native output buffer, filled from index zero.</param>
    /// <param name="tolerance">The relative tolerance. Defaults to <see cref="DefaultTolerance"/>.</param>
    /// <exception cref="InvalidOperationException">Thrown when the two implementations disagree.</exception>
    public static void AssertEquivalent(
        string indicator,
        int managedBegIdx,
        int managedCount,
        double[] managedValues,
        int nativeBegIdx,
        int nativeCount,
        double[] nativeValues,
        double tolerance = DefaultTolerance)
    {
        ArgumentNullException.ThrowIfNull(managedValues);
        ArgumentNullException.ThrowIfNull(nativeValues);

        if (managedBegIdx != nativeBegIdx)
        {
            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                "{0}: output alignment differs. Managed outBegIdx = {1}, native outBegIdx = {2}. " +
                "Comparing the timings would be meaningless.",
                indicator,
                managedBegIdx,
                nativeBegIdx));
        }

        if (managedCount != nativeCount)
        {
            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                "{0}: output length differs. Managed outNBElement = {1}, native outNBElement = {2}.",
                indicator,
                managedCount,
                nativeCount));
        }

        for (int i = 0; i < managedCount; i++)
        {
            double managed = managedValues[i];
            double @native = nativeValues[i];

            if (AreClose(managed, @native, tolerance))
            {
                continue;
            }

            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                "{0}: values diverge at output index {1} (input index {2}). Managed = {3:R}, native = {4:R}, " +
                "absolute difference = {5:R}, tolerance = {6:R}.",
                indicator,
                i,
                managedBegIdx + i,
                managed,
                @native,
                Math.Abs(managed - @native),
                tolerance));
        }
    }

    private static bool AreClose(double left, double right, double tolerance)
    {
        if (double.IsNaN(left) && double.IsNaN(right))
        {
            return true;
        }

        if (double.IsNaN(left) || double.IsNaN(right))
        {
            return false;
        }

        if (left.Equals(right))
        {
            return true;
        }

        double scale = Math.Max(1.0, Math.Max(Math.Abs(left), Math.Abs(right)));
        return Math.Abs(left - right) <= tolerance * scale;
    }
}
