// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;

namespace TechnicalAnalysis.Benchmarks.Configuration;

/// <summary>
/// The shared BenchmarkDotNet configuration for the TaLibStandard performance suite.
/// </summary>
/// <remarks>
/// <para>
/// The configuration deliberately declares no job. BenchmarkDotNet then falls back to <c>Job.Default</c>, which
/// means the standard command line switches (<c>--job Dry</c>, <c>--job Short</c>, <c>--runtimes</c>, ...) add
/// exactly one job instead of multiplying an already-declared one.
/// </para>
/// <para>
/// Exporters: GitHub-flavoured markdown (paste straight into an issue or a release note) and full JSON
/// (machine readable, for tracking regressions between releases). Both land in
/// <c>BenchmarkDotNet.Artifacts/results</c> next to the executable.
/// </para>
/// </remarks>
public sealed class TaLibBenchmarkConfig : ManualConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaLibBenchmarkConfig"/> class.
    /// </summary>
    public TaLibBenchmarkConfig()
    {
        AddLogger(ConsoleLogger.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
        AddColumn(StatisticColumn.OperationsPerSecond);

        // Also declared per class via [MemoryDiagnoser]; BenchmarkDotNet de-duplicates the singleton instance.
        AddDiagnoser(MemoryDiagnoser.Default);

        AddExporter(MarkdownExporter.GitHub);
        AddExporter(JsonExporter.Full);

        // Declared order keeps every "_TAFunc" / "_TAMath" and "_Managed" / "_Native" pair adjacent in the summary,
        // which is what a reader of this suite actually wants to compare.
        WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Declared, MethodOrderPolicy.Declared));

        WithSummaryStyle(SummaryStyle.Default
            .WithRatioStyle(RatioStyle.Trend)
            .WithMaxParameterColumnWidth(24));

        // Anchored to the executable rather than the current directory, so running the suite from the repository
        // root does not drop a BenchmarkDotNet.Artifacts folder there. Overridable with --artifacts.
        WithArtifactsPath(Path.Combine(AppContext.BaseDirectory, "BenchmarkDotNet.Artifacts"));
    }
}
