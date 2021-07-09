using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public record MaxIndexResult : IndicatorBase
    {
        public MaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
