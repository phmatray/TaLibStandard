namespace TechnicalAnalysis.Common;

public enum RetCode
{
    /// <summary>
    /// No error
    /// </summary>
    Success = 0,

    /// <summary>
    /// Initialize was not successfully called
    /// </summary>
    LibNotInitialize = 1,

    /// <summary>
    /// A parameter is out of range
    /// </summary>
    BadParam = 2,

    /// <summary>
    /// Possibly out-of-memory
    /// </summary>
    AllocErr = 3,

    GroupNotFound = 4,
    FuncNotFound = 5,
    InvalidHandle = 6,
    InvalidParamHolder = 7,
    InvalidParamHolderType = 8,
    InvalidParamFunction = 9,
    InputNotAllInitialize = 10,
    OutputNotAllInitialize = 11,
    OutOfRangeStartIndex = 12,
    OutOfRangeEndIndex = 13,
    InvalidListType = 14,
    BadObject = 15,
    NotSupported = 16,
    InternalError = 5000,
    UnknownErr = 65535
}
