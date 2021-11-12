using System.Runtime.Serialization;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Out of range end index exception
/// </summary>
[Serializable]
public class OutOfRangeEndIndexException : Exception
{
    /// <summary>
    /// Constructor for <see cref="OutOfRangeEndIndexException"/> class.
    /// </summary>
    protected OutOfRangeEndIndexException()
        : base("End index is out of range")
    {
    }
    
    /// <inheritdoc cref="Exception"/>
    protected OutOfRangeEndIndexException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
