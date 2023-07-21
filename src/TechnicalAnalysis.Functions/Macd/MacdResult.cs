// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public record MacdResult : IndicatorResult
{
    public MacdResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macdValue,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement)
    {
        MacdValue = macdValue;
        MacdSignal = macdSignal;
        MacdHist = macdHist;
    }

    public double[] MacdValue { get; }

    public double[] MacdHist { get; }

    public double[] MacdSignal { get; }
}
