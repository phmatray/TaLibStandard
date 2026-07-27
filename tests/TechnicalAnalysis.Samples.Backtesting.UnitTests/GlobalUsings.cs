// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

global using System.Globalization;
global using Shouldly;
global using TechnicalAnalysis.Common;
global using TechnicalAnalysis.Functions;
global using TechnicalAnalysis.Samples.Backtesting;
global using TechnicalAnalysis.Samples.Backtesting.Data;
global using TechnicalAnalysis.Samples.Backtesting.Engine;
global using TechnicalAnalysis.Samples.Backtesting.Metrics;
global using TechnicalAnalysis.Samples.Backtesting.Reporting;
global using TechnicalAnalysis.Samples.Backtesting.Strategies;
global using TechnicalAnalysis.Samples.Backtesting.UnitTests.TestSupport;
global using Xunit;

// Same name collision as the sample project: pin the engine's types.
global using IndicatorSeries = TechnicalAnalysis.Samples.Backtesting.Engine.IndicatorSeries;
global using MacdSeries = TechnicalAnalysis.Samples.Backtesting.Engine.MacdSeries;
