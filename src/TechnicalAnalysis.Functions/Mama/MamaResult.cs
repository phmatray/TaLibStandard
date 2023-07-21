// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public record MamaResult : IndicatorResult
{
    public MamaResult(RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama)
        : base(retCode, begIdx, nbElement)
    {
        MAMA = mama;
        FAMA = fama;
    }

    public double[] FAMA { get; }

    public double[] MAMA { get; }
}
