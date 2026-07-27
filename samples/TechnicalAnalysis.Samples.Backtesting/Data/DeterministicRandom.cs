// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting.Data;

/// <summary>
/// A tiny SplitMix64 pseudo-random generator, used to make the sample's synthetic data byte-for-byte
/// reproducible.
/// </summary>
/// <remarks>
/// <see cref="System.Random"/> is deliberately avoided: its sequence is an implementation detail of the
/// runtime, so a sample that relied on it could print different numbers on a different .NET version and
/// silently invalidate every documented figure. SplitMix64 is eight lines long, has a documented reference
/// implementation and is entirely fixed by its seed. It is a statistical generator, never a cryptographic
/// one — do not use it for anything that needs to be unpredictable.
/// </remarks>
public sealed class DeterministicRandom
{
    private const ulong GoldenGamma = 0x9E3779B97F4A7C15UL;

    private ulong _state;
    private double _spareGaussian;
    private bool _hasSpareGaussian;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeterministicRandom"/> class.
    /// </summary>
    /// <param name="seed">The seed. The same seed always yields the same sequence, on every platform and runtime.</param>
    public DeterministicRandom(int seed)
    {
        _state = unchecked((ulong)seed);
    }

    /// <summary>
    /// Returns the next 64 raw pseudo-random bits.
    /// </summary>
    /// <returns>A uniformly distributed 64-bit value.</returns>
    public ulong NextUInt64()
    {
        unchecked
        {
            _state += GoldenGamma;
            ulong z = _state;
            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            return z ^ (z >> 31);
        }
    }

    /// <summary>
    /// Returns the next uniformly distributed value in the half-open interval <c>[0, 1)</c>.
    /// </summary>
    /// <returns>A uniform deviate in <c>[0, 1)</c>.</returns>
    public double NextDouble()
    {
        // 53 significant bits is exactly the mantissa of a double, so every representable value is reachable
        // and none is favoured.
        return (NextUInt64() >> 11) * (1.0 / 9007199254740992.0);
    }

    /// <summary>
    /// Returns the next standard normal deviate, using the polar form of the Box-Muller transform.
    /// </summary>
    /// <returns>A deviate drawn from N(0, 1).</returns>
    public double NextGaussian()
    {
        if (_hasSpareGaussian)
        {
            _hasSpareGaussian = false;
            return _spareGaussian;
        }

        double u1;
        do
        {
            u1 = NextDouble();
        }
        while (u1 <= double.Epsilon);

        double u2 = NextDouble();
        double magnitude = Math.Sqrt(-2.0 * Math.Log(u1));

        _spareGaussian = magnitude * Math.Sin(2.0 * Math.PI * u2);
        _hasSpareGaussian = true;

        return magnitude * Math.Cos(2.0 * Math.PI * u2);
    }
}
