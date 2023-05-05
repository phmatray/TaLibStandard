// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public record HtSineResult : IndicatorBase
{
    public HtSineResult(RetCode retCode, int begIdx, int nbElement, double[] sine, double[] leadSine)
        : base(retCode, begIdx, nbElement)
    {
        Sine = sine;
        LeadSine = leadSine;
    }

    public double[] LeadSine { get; }

    public double[] Sine { get; }
}
