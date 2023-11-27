// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

public static partial class TACandle
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    /// <param name="penetration"></param>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <returns></returns>
    public static CandleIndicatorResult CdlEveningDojiStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleEveningDojiStar<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <returns></returns>
    public static CandleIndicatorResult CdlEveningDojiStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.3));
    }
}
