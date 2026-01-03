// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the MESA Adaptive Moving Average (MAMA) for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="fastLimit">The fast limit parameter for adaptation speed (default: 0.5).</param>
    /// <param name="slowLimit">The slow limit parameter for adaptation speed (default: 0.05).</param>
    /// <returns>A MamaResult containing the MAMA and FAMA (Following Adaptive Moving Average) values.</returns>
    /// <remarks>
    /// MESA Adaptive Moving Average automatically adjusts its smoothing factor based on 
    /// the dominant market cycle measured by the Hilbert Transform. MAMA closely follows 
    /// price in trending markets and provides smooth results in cycling markets. FAMA 
    /// (Following Adaptive Moving Average) is a complementary indicator that can be used 
    /// for crossover signals.
    /// </remarks>
    public static MamaResult Mama(int startIdx, int endIdx, double[] real, double fastLimit, double slowLimit)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMAMA = new double[endIdx - startIdx + 1];
        double[] outFAMA = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Mama(
            startIdx,
            endIdx,
            real,
            fastLimit,
            slowLimit,
            ref outBegIdx,
            ref outNBElement,
            ref outMAMA,
            ref outFAMA);
            
        return new MamaResult(retCode, outBegIdx, outNBElement, outMAMA, outFAMA);
    }
        
    /// <summary>
    /// Calculates the MESA Adaptive Moving Average (MAMA) using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A MamaResult containing the MAMA and FAMA values.</returns>
    public static MamaResult Mama(int startIdx, int endIdx, double[] real)
        => Mama(startIdx, endIdx, real, 0.5, 0.05);

    /// <summary>
    /// Calculates the MESA Adaptive Moving Average (MAMA) for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <param name="fastLimit">The fast limit parameter for adaptation speed.</param>
    /// <param name="slowLimit">The slow limit parameter for adaptation speed.</param>
    /// <returns>A MamaResult containing the MAMA and FAMA values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static MamaResult Mama(int startIdx, int endIdx, float[] real, double fastLimit, double slowLimit)
        => Mama(startIdx, endIdx, real.ToDouble(), fastLimit, slowLimit);
        
    /// <summary>
    /// Calculates the MESA Adaptive Moving Average (MAMA) using default parameters.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>A MamaResult containing the MAMA and FAMA values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static MamaResult Mama(int startIdx, int endIdx, float[] real)
        => Mama(startIdx, endIdx, real, 0.5, 0.05);
}
