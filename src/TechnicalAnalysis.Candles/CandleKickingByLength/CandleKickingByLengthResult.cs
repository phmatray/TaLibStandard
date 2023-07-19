// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// 
/// </summary>
public record CandleKickingByLengthResult : IndicatorBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="retCode"></param>
    /// <param name="begIdx"></param>
    /// <param name="nbElement"></param>
    /// <param name="integers"></param>
    public CandleKickingByLengthResult(RetCode retCode, int begIdx, int nbElement, int[] integers)
        : base(retCode, begIdx, nbElement)
    {
        Integers = integers;
    }

    /// <summary>
    /// 
    /// </summary>
    public int[] Integers { get; }
}
