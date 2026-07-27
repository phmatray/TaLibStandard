// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Benchmarks.Benchmarks;

/// <summary>
/// The category names used by <c>[BenchmarkCategory]</c>, so that <c>--anyCategories</c> and
/// <c>--allCategories</c> filters can be written without guessing at spelling.
/// </summary>
public static class BenchmarkCategories
{
    /// <summary>
    /// Moving averages, envelopes and other overlap studies.
    /// </summary>
    public const string OverlapStudies = "OverlapStudies";

    /// <summary>
    /// Momentum oscillators.
    /// </summary>
    public const string Momentum = "Momentum";

    /// <summary>
    /// Volatility and volume indicators plus the statistic functions.
    /// </summary>
    public const string VolatilityVolume = "VolatilityVolume";

    /// <summary>
    /// Candlestick pattern recognisers.
    /// </summary>
    public const string CandlePatterns = "CandlePatterns";

    /// <summary>
    /// Numeric precision comparisons.
    /// </summary>
    public const string Precision = "Precision";

    /// <summary>
    /// Managed versus native TA-Lib C head-to-head comparisons.
    /// </summary>
    public const string NativeComparison = "NativeComparison";

    /// <summary>
    /// The low level, allocation-free <c>TAFunc</c> API with caller-supplied output buffers.
    /// </summary>
    public const string TaFunc = "TAFunc";

    /// <summary>
    /// The ergonomic <c>TAMath</c> API that allocates its output arrays and a result record per call.
    /// </summary>
    public const string TaMath = "TAMath";

    /// <summary>
    /// Benchmarks operating on <see cref="double"/> inputs.
    /// </summary>
    public const string DoublePrecision = "double";

    /// <summary>
    /// Benchmarks operating on <see cref="float"/> inputs.
    /// </summary>
    public const string SinglePrecision = "float";

    /// <summary>
    /// Benchmarks operating on <see cref="decimal"/> inputs.
    /// </summary>
    public const string DecimalPrecision = "decimal";

    /// <summary>
    /// The managed TaLibStandard implementation.
    /// </summary>
    public const string Managed = "Managed";

    /// <summary>
    /// The original TA-Lib C implementation reached through P/Invoke.
    /// </summary>
    public const string Native = "Native";
}
