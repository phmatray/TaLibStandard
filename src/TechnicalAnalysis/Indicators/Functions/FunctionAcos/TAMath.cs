using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionAcos;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static ACosResult ACos(int startIdx, int endIdx, double[] real)
    {
        return new ACos(real)
            .Compute(startIdx, endIdx);
    }

    public static ACosResult ACos(int startIdx, int endIdx, float[] real)
        => ACos(startIdx, endIdx, real.ToDouble());
}
