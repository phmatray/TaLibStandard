// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The three aligned outputs of the MACD indicator.
/// </summary>
/// <param name="Line">The MACD line: fast EMA minus slow EMA.</param>
/// <param name="Signal">The signal line: an EMA of <paramref name="Line"/>.</param>
/// <param name="Histogram">The histogram: <paramref name="Line"/> minus <paramref name="Signal"/>.</param>
public sealed record MacdSeries(IndicatorSeries Line, IndicatorSeries Signal, IndicatorSeries Histogram);
