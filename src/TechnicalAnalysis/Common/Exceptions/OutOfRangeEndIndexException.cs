using System;

namespace TechnicalAnalysis.Common;

public class OutOfRangeEndIndexException : Exception
{
    public OutOfRangeEndIndexException()
        : base("End index is out of range")
    {
    }
}
