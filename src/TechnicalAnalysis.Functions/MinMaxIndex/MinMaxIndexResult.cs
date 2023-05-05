// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public record MinMaxIndexResult : IndicatorBase
{
    public MinMaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] minIdx, int[] maxIdx)
        : base(retCode, begIdx, nbElement)
    {
        MinIdx = minIdx;
        MaxIdx = maxIdx;
    }

    public int[] MaxIdx { get; }

    public int[] MinIdx { get; }
}
