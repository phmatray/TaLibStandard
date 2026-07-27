// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Engine;

/// <summary>
/// The three aligned outputs of the Bollinger Bands indicator.
/// </summary>
/// <param name="Upper">The upper band: the moving average plus <c>deviationsUp</c> standard deviations.</param>
/// <param name="Middle">The middle band: the moving average itself.</param>
/// <param name="Lower">The lower band: the moving average minus <c>deviationsDown</c> standard deviations.</param>
public sealed record BollingerBandSeries(IndicatorSeries Upper, IndicatorSeries Middle, IndicatorSeries Lower);
