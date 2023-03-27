namespace TechnicalAnalysis.Common
{
    /// <summary>
    /// Represents an abstract base class for technical indicators.
    /// </summary>
    public abstract record IndicatorBase
    {
        /// <summary>
        /// Initializes a new instance of the IndicatorBase class.
        /// </summary>
        /// <param name="retCode">The return code indicating the status of the indicator calculation.</param>
        /// <param name="begIdx">The beginning index of the calculated output series.</param>
        /// <param name="nbElement">The number of elements in the calculated output series.</param>
        protected IndicatorBase(RetCode retCode, int begIdx, int nbElement)
        {
            RetCode = retCode;
            BegIdx = begIdx;
            NBElement = nbElement;
        }

        /// <summary>
        /// Gets the return code indicating the status of the indicator calculation.
        /// </summary>
        public RetCode RetCode { get; }

        /// <summary>
        /// Gets the beginning index of the calculated output series.
        /// </summary>
        public int BegIdx { get; }

        /// <summary>
        /// Gets the number of elements in the calculated output series.
        /// </summary>
        public int NBElement { get; }
    }
}
