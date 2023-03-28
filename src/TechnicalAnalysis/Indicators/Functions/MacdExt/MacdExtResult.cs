// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public record MacdExtResult : IndicatorBase
{
    public MacdExtResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macd,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement)
    {
        MACD = macd;
        MACDSignal = macdSignal;
        MACDHist = macdHist;
    }

    public double[] MACD { get; }

    public double[] MACDHist { get; }

    public double[] MACDSignal { get; }
}
