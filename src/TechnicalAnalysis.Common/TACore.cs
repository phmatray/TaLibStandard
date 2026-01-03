// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

/// <summary>
/// Provides core functionalities for the Technical Analysis library.
/// </summary>
public static class TACore
{
    /// <summary>
    /// Gets the global settings for the Technical Analysis library.
    /// </summary>
    public static GlobalsType Globals { get; }

    static TACore()
    {
        Globals = new GlobalsType();
    }
}
