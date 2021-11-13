using TechnicalAnalysis.Common;
using static TechnicalAnalysis.Common.RetCode;

namespace TechnicalAnalysis.Functions.FunctionAcos;

/// <summary>
/// Vector Trigonometric ACos
/// </summary>
public class ACos : FunctionIndicator
{
    public double[] InReal { get; }

    public ACos(in double[] inReal)
    {
        InReal = inReal;
    }

    public ACosResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        // Validate the requested output range.
        if (startIdx < 0)
        {
            return new ACosResult(OutOfRangeStartIndex, outBegIdx, outNBElement, outReal);
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return new ACosResult(OutOfRangeEndIndex, outBegIdx, outNBElement, outReal);
        }

        if (InReal == null)
        {
            return new ACosResult(BadParam, outBegIdx, outNBElement, outReal);
        }

        if (outReal == null)
        {
            return new ACosResult(BadParam, outBegIdx, outNBElement, outReal);
        }

        int i = startIdx;
        int outIdx = 0;
        while (i <= endIdx)
        {
            outReal[outIdx] = Math.Acos(InReal[i]);
            i++;
            outIdx++;
        }

        outNBElement = outIdx;
        outBegIdx = startIdx;

        return new ACosResult(Success, outBegIdx, outNBElement, outReal);
    }
    
    public static int Lookback()
    {
        return 0;
    }
}
