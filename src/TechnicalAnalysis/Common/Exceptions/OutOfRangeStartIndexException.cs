using System;
using System.Runtime.Serialization;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an exception that is thrown when the start index is out of range.
/// </summary>
[Serializable]
public class OutOfRangeStartIndexException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OutOfRangeStartIndexException"/> class.
    /// </summary>
    public OutOfRangeStartIndexException()
        : base("Start index is out of range")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OutOfRangeStartIndexException"/> class with serialized data.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
    protected OutOfRangeStartIndexException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
