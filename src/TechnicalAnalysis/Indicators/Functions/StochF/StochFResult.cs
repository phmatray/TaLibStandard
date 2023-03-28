// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public record StochFResult : IndicatorBase
{
    public StochFResult(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
        : base(retCode, begIdx, nbElement)
    {
        FastK = fastK;
        FastD = fastD;
    }

    public double[] FastD { get; }

    public double[] FastK { get; }
}
