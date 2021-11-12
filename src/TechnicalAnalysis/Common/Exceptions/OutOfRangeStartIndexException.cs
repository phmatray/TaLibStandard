using System.Runtime.Serialization;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Out of range start index exception
/// </summary>
[Serializable]
public class OutOfRangeStartIndexException : Exception
{
    /// <summary>
    /// Constructor for <see cref="OutOfRangeStartIndexException"/> class.
    /// </summary>
    protected OutOfRangeStartIndexException()
        : base("Start index is out of range")
    {
    }

    /// <inheritdoc cref="Exception"/>
    protected OutOfRangeStartIndexException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
