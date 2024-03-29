﻿// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents the return codes for various functions in the TechnicalAnalysis library.
/// </summary>
public enum RetCode
{
    /// <summary>
    /// Operation completed successfully.
    /// </summary>
    Success = 0,
    
    /// <summary>
    /// Library not initialized.
    /// </summary>
    LibNotInitialize = 1,

    /// <summary>
    /// Bad parameter provided.
    /// </summary>
    BadParam = 2,
    
    /// <summary>
    /// Memory allocation error.
    /// </summary>
    AllocErr = 3,
    
    /// <summary>
    /// Group not found.
    /// </summary>
    GroupNotFound = 4,

    /// <summary>
    /// Function not found.
    /// </summary>
    FuncNotFound = 5,

    /// <summary>
    /// Invalid handle encountered.
    /// </summary>
    InvalidHandle = 6,

    /// <summary>
    /// Invalid parameter holder encountered.
    /// </summary>
    InvalidParamHolder = 7,

    /// <summary>
    /// Invalid parameter holder type encountered.
    /// </summary>
    InvalidParamHolderType = 8,

    /// <summary>
    /// Invalid parameter function encountered.
    /// </summary>
    InvalidParamFunction = 9,

    /// <summary>
    /// Not all input values are initialized.
    /// </summary>
    InputNotAllInitialize = 10,
    
    /// <summary>
    /// Not all output values are initialized.
    /// </summary>
    OutputNotAllInitialize = 11,

    /// <summary>
    /// Start index is out of range.
    /// </summary>
    OutOfRangeStartIndex = 12,

    /// <summary>
    /// End index is out of range.
    /// </summary>
    OutOfRangeEndIndex = 13,
    
    /// <summary>
    /// Invalid list type encountered.
    /// </summary>
    InvalidListType = 14,

    /// <summary>
    /// Bad object encountered.
    /// </summary>
    BadObject = 15,

    /// <summary>
    /// Feature not supported.
    /// </summary>
    NotSupported = 16,

    /// <summary>
    /// Internal error occurred.
    /// </summary>
    InternalError = 5000,

    /// <summary>
    /// Unknown error encountered.
    /// </summary>
    UnknownErr = 65535
}
