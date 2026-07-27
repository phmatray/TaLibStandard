// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Benchmarks.Data;

/// <summary>
/// One synthetic market data set, exposed in the three numeric precisions the library supports plus a second,
/// correlated instrument used by the two-input indicators (Correl, Beta).
/// </summary>
/// <remarks>
/// <para>
/// <see cref="Doubles"/>, <see cref="Singles"/> and <see cref="Decimals"/> are projections of the exact same
/// underlying series. The generator rounds every price to four decimal places so that the decimal projection is an
/// exact representation of the double projection; only the float projection loses information. That makes a
/// double / float / decimal comparison a pure cost comparison rather than a "different data" comparison.
/// </para>
/// </remarks>
public sealed class MarketSeries
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketSeries"/> class.
    /// </summary>
    /// <param name="seed">The seed the series was generated from.</param>
    /// <param name="doubles">The primary instrument as doubles.</param>
    /// <param name="singles">The primary instrument as floats.</param>
    /// <param name="decimals">The primary instrument as decimals.</param>
    /// <param name="referenceDoubles">The correlated reference instrument as doubles.</param>
    /// <param name="referenceSingles">The correlated reference instrument as floats.</param>
    public MarketSeries(
        int seed,
        OhlcvSeries<double> doubles,
        OhlcvSeries<float> singles,
        OhlcvSeries<decimal> decimals,
        OhlcvSeries<double> referenceDoubles,
        OhlcvSeries<float> referenceSingles)
    {
        Seed = seed;
        Doubles = doubles;
        Singles = singles;
        Decimals = decimals;
        ReferenceDoubles = referenceDoubles;
        ReferenceSingles = referenceSingles;
    }

    /// <summary>
    /// Gets the seed the series was generated from.
    /// </summary>
    public int Seed { get; }

    /// <summary>
    /// Gets the number of bars in the series.
    /// </summary>
    public int Length => Doubles.Length;

    /// <summary>
    /// Gets the primary instrument projected onto <see cref="double"/>.
    /// </summary>
    public OhlcvSeries<double> Doubles { get; }

    /// <summary>
    /// Gets the primary instrument projected onto <see cref="float"/>.
    /// </summary>
    public OhlcvSeries<float> Singles { get; }

    /// <summary>
    /// Gets the primary instrument projected onto <see cref="decimal"/>.
    /// </summary>
    public OhlcvSeries<decimal> Decimals { get; }

    /// <summary>
    /// Gets a second, correlated instrument projected onto <see cref="double"/>, used by Correl and Beta.
    /// </summary>
    public OhlcvSeries<double> ReferenceDoubles { get; }

    /// <summary>
    /// Gets a second, correlated instrument projected onto <see cref="float"/>, used by Correl and Beta.
    /// </summary>
    public OhlcvSeries<float> ReferenceSingles { get; }
}
