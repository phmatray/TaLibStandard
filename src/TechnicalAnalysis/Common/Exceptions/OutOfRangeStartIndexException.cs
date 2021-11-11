namespace TechnicalAnalysis.Common;

public class OutOfRangeStartIndexException : Exception
{
    public OutOfRangeStartIndexException()
        : base("Start index is out of range")
    {
    }
}
