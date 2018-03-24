namespace GLPM.TechnicalAnalysis
{
    public abstract class IndicatorBase
    {
        public IndicatorBase(RetCode retCode, int begIdx, int nbElement)
        {
            this.RetCode = retCode;
            this.BegIdx = begIdx;
            this.NBElement = nbElement;
        }

        public RetCode RetCode { get; }

        public int BegIdx { get; }

        public int NBElement { get; }
    }
}