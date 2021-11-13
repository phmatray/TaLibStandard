using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAd;

/// <summary>
/// Chaikin A/D Line
/// </summary>
public class Ad : FunctionIndicator
{
    public double[] InHigh { get; }
    public double[] InLow { get; }
    public double[] InClose { get; }
    public double[] InVolume { get; }

    public Ad(in double[] inHigh, in double[] inLow, in double[] inClose, in double[] inVolume)
    {
        InHigh = inHigh;
        InLow = inLow;
        InClose = inClose;
        InVolume = inVolume;
    }

    public AdResult Compute(int startIdx, int endIdx)
    {
        // Initialize output variables 
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        throw new NotImplementedException();
    }

    public static int Lookback()
    {
        return 0;
    }
}
