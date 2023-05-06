// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles.UnitTests;

public class CdlTestsBase
{
    protected void InvokeGeneric(string methodName, Type floatingPointType)
    {
        GetType()
            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)?
            .MakeGenericMethod(floatingPointType)
            .Invoke(this, null);
    }
}
