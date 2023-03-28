// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Candles.CandleDarkCloudCover;

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDarkCloudCoverResult CdlDarkCloudCover<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleDarkCloudCover<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleDarkCloudCoverResult CdlDarkCloudCover<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.5));
    }
}
