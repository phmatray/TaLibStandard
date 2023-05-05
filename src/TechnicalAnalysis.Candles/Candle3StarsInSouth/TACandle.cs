// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.Candle3StarsInSouth;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TACandle
{
    public static Candle3StarsInSouthResult Cdl3StarsInSouth<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3StarsInSouth<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
