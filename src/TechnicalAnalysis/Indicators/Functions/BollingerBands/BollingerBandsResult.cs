// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public record BollingerBandsResult : IndicatorBase
{
    public BollingerBandsResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] realUpperBand,
        double[] realMiddleBand,
        double[] realLowerBand)
        : base(retCode, begIdx, nbElement)
    {
        RealUpperBand = realUpperBand;
        RealMiddleBand = realMiddleBand;
        RealLowerBand = realLowerBand;
    }

    public double[] RealLowerBand { get; }

    public double[] RealMiddleBand { get; }

    public double[] RealUpperBand { get; }
}
