namespace TechnicalAnalysis.Common
{
    public abstract record IndicatorBase
    {
        protected IndicatorBase(RetCode retCode, int begIdx, int nbElement)
        {
            RetCode = retCode;
            BegIdx = begIdx;
            NBElement = nbElement;
        }

        public RetCode RetCode { get; }

        public int BegIdx { get; }

        public int NBElement { get; }
    }
}
