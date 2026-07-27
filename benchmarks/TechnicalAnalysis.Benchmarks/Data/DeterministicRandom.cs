// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Numerics;

namespace TechnicalAnalysis.Benchmarks.Data;

/// <summary>
/// A self-contained, fully deterministic pseudo random number generator (xoshiro256** seeded through SplitMix64).
/// </summary>
/// <remarks>
/// <para>
/// The BCL <see cref="System.Random"/> does not guarantee that a given seed produces the same sequence across
/// runtime versions. Benchmarks must be comparable across machines and across .NET releases, so the generator is
/// implemented here instead of being taken from the BCL. The algorithm is deliberately simple and allocation free.
/// </para>
/// <para>
/// This type is not thread safe. Each generated series creates its own instance.
/// </para>
/// </remarks>
public sealed class DeterministicRandom
{
    private ulong _s0;
    private ulong _s1;
    private ulong _s2;
    private ulong _s3;
    private double _spareGaussian;
    private bool _hasSpareGaussian;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeterministicRandom"/> class.
    /// </summary>
    /// <param name="seed">The seed. The same seed always yields the same sequence.</param>
    public DeterministicRandom(int seed)
    {
        ulong state = unchecked((ulong)seed + 0x9E3779B97F4A7C15UL);
        _s0 = SplitMix64(ref state);
        _s1 = SplitMix64(ref state);
        _s2 = SplitMix64(ref state);
        _s3 = SplitMix64(ref state);
    }

    /// <summary>
    /// Returns the next raw 64 bit sample of the generator.
    /// </summary>
    /// <returns>A uniformly distributed unsigned 64 bit integer.</returns>
    public ulong NextUInt64()
    {
        unchecked
        {
            ulong result = BitOperations.RotateLeft(_s1 * 5UL, 7) * 9UL;
            ulong t = _s1 << 17;

            _s2 ^= _s0;
            _s3 ^= _s1;
            _s1 ^= _s2;
            _s0 ^= _s3;
            _s2 ^= t;
            _s3 = BitOperations.RotateLeft(_s3, 45);

            return result;
        }
    }

    /// <summary>
    /// Returns the next uniformly distributed sample in the half open interval [0, 1).
    /// </summary>
    /// <returns>A uniformly distributed double in [0, 1).</returns>
    public double NextDouble()
    {
        // 53 significant bits, the exact precision of a double mantissa.
        return (NextUInt64() >> 11) * (1.0 / 9007199254740992.0);
    }

    /// <summary>
    /// Returns the next standard normal sample (mean 0, standard deviation 1) using the Marsaglia polar method.
    /// </summary>
    /// <returns>A normally distributed double.</returns>
    public double NextGaussian()
    {
        if (_hasSpareGaussian)
        {
            _hasSpareGaussian = false;
            return _spareGaussian;
        }

        double u;
        double v;
        double s;

        do
        {
            u = (2.0 * NextDouble()) - 1.0;
            v = (2.0 * NextDouble()) - 1.0;
            s = (u * u) + (v * v);
        }
        while (s is <= 0.0 or >= 1.0);

        double factor = Math.Sqrt(-2.0 * Math.Log(s) / s);
        _spareGaussian = v * factor;
        _hasSpareGaussian = true;

        return u * factor;
    }

    private static ulong SplitMix64(ref ulong state)
    {
        unchecked
        {
            state += 0x9E3779B97F4A7C15UL;
            ulong z = state;
            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            return z ^ (z >> 31);
        }
    }
}
