﻿// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.
namespace TechnicalAnalysis.Candles.Candle3Inside;

/// <summary>
/// Represents the result of the Three Inside candlestick pattern indicator.
/// </summary>
public record Candle3InsideResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle3InsideResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integers">An array of integers indicating the presence of the Three Inside pattern.</param>
    public Candle3InsideResult(RetCode retCode, int begIdx, int nbElement, int[] integers)
        : base(retCode, begIdx, nbElement)
    {
        Integers = integers;
    }
    
    /// <summary>
    /// Gets the array of integers indicating the presence of the Three Inside pattern.
    /// </summary>
    public int[] Integers { get; }
}
