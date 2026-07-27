// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

global using System.Globalization;
global using TechnicalAnalysis.Common;
global using TechnicalAnalysis.Functions;
global using TechnicalAnalysis.Samples.Backtesting.Data;
global using TechnicalAnalysis.Samples.Backtesting.Engine;
global using TechnicalAnalysis.Samples.Backtesting.Metrics;
global using TechnicalAnalysis.Samples.Backtesting.Reporting;
global using TechnicalAnalysis.Samples.Backtesting.Strategies;

// The library's fluent API introduces TechnicalAnalysis.Functions.IndicatorSeries and MacdSeries,
// which collide by name with this sample's engine types of the same name. The sample keeps its own:
// they are bar-window aware and clamp their metadata so a strategy cannot read a future bar. Pin
// them explicitly rather than relying on using order.
global using IndicatorSeries = TechnicalAnalysis.Samples.Backtesting.Engine.IndicatorSeries;
global using MacdSeries = TechnicalAnalysis.Samples.Backtesting.Engine.MacdSeries;
