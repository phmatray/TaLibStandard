// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stoch.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Stoch.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Stoch Stoch(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int fastK_Period = 5,
            int slowK_Period = 3,
            MAType slowK_MAType = MAType.Sma,
            int slowD_Period = 3,
            MAType slowD_MAType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outSlowK = new double[endIdx - startIdx + 1];
            double[] outSlowD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Stoch(
                startIdx,
                endIdx,
                high,
                low,
                close,
                fastK_Period,
                slowK_Period,
                slowK_MAType,
                slowD_Period,
                slowD_MAType,
                ref outBegIdx,
                ref outNBElement,
                outSlowK,
                outSlowD);
            return new Stoch(retCode, outBegIdx, outNBElement, outSlowK, outSlowD);
        }

        public static Stoch Stoch(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int fastK_Period = 5,
            int slowK_Period = 3,
            MAType slowK_MAType = MAType.Sma,
            int slowD_Period = 3,
            MAType slowD_MAType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outSlowK = new double[endIdx - startIdx + 1];
            double[] outSlowD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Stoch(
                startIdx,
                endIdx,
                high,
                low,
                close,
                fastK_Period,
                slowK_Period,
                slowK_MAType,
                slowD_Period,
                slowD_MAType,
                ref outBegIdx,
                ref outNBElement,
                outSlowK,
                outSlowD);
            return new Stoch(retCode, outBegIdx, outNBElement, outSlowK, outSlowD);
        }
    }

    public class Stoch : IndicatorBase
    {
        public Stoch(RetCode retCode, int begIdx, int nbElement, double[] slowK, double[] slowD)
            : base(retCode, begIdx, nbElement)
        {
            this.SlowK = slowK;
            this.SlowD = slowD;
        }

        public double[] SlowD { get; }

        public double[] SlowK { get; }
    }
}
