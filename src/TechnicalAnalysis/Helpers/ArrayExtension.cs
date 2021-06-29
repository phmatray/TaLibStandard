using System;

namespace TechnicalAnalysis
{
    internal static class ArrayExtension
    {
        internal static double[] ToDouble(this float[] arr)
            => Array.ConvertAll(arr, x => (double)x);
    }
}
