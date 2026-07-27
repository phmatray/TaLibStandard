// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// The preconditions every fluent indicator checks, in one place.
/// </summary>
/// <remarks>
/// <para>
/// Centralising the guards is what makes the rules uniform: no indicator author can invent a
/// different minimum period or a different way of reporting missing data. Every fluent indicator
/// validates its periods first, then the price components it needs, and only then short-circuits on
/// an empty price series — so a bad period is reported even when there is no data to compute over.
/// </para>
/// <para>
/// The period rule is deliberately stricter than parts of the raw layer, where a handful of
/// entry points accept a period of 1. One rule that cannot be got wrong is worth more than
/// per-indicator fidelity to an inconsistency, and it is what stops a signal period of 1 from
/// crashing inside an array copy deep in the MACD implementation.
/// </para>
/// </remarks>
internal static class HighLevelGuard
{
    /// <summary>
    /// The smallest period any fluent indicator accepts.
    /// </summary>
    internal const int MinPeriod = ValidationHelper.MinPeriod;

    /// <summary>
    /// The largest period any fluent indicator accepts.
    /// </summary>
    internal const int MaxPeriod = ValidationHelper.MaxPeriod;

    /// <summary>
    /// Validates an integer period parameter.
    /// </summary>
    /// <param name="value">The period supplied by the caller.</param>
    /// <param name="parameterName">The name of the parameter that carried it.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="value"/> is outside <see cref="MinPeriod"/> to <see cref="MaxPeriod"/>.
    /// </exception>
    internal static void Period(int value, string parameterName)
    {
        if (value is < MinPeriod or > MaxPeriod)
        {
            throw new ArgumentOutOfRangeException(
                parameterName,
                value,
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"The period must lie between {MinPeriod} and {MaxPeriod}."));
        }
    }

    /// <summary>
    /// Requires that the price series carries high and low prices.
    /// </summary>
    /// <param name="prices">The price series the indicator was called on.</param>
    /// <param name="indicator">The name of the indicator, for the message.</param>
    /// <exception cref="InvalidOperationException">The series carries no high and low prices.</exception>
    internal static void RequireHighLow(in PriceSeries prices, string indicator)
    {
        if (!prices.HasHighLow)
        {
            throw new InvalidOperationException(
                $"{indicator} needs the high and low of each bar, which this price series does not carry. Build it " +
                $"with PriceSeries.FromHlc, FromOhlc or FromOhlcv; the closing price alone is never substituted for a " +
                $"bar's range.");
        }
    }

    /// <summary>
    /// Requires that the price series carries volumes.
    /// </summary>
    /// <param name="prices">The price series the indicator was called on.</param>
    /// <param name="indicator">The name of the indicator, for the message.</param>
    /// <exception cref="InvalidOperationException">The series carries no volumes.</exception>
    internal static void RequireVolume(in PriceSeries prices, string indicator)
    {
        if (!prices.HasVolume)
        {
            throw new InvalidOperationException(
                $"{indicator} needs the volume of each bar, which this price series does not carry. Build it with " +
                $"PriceSeries.FromOhlcv.");
        }
    }

    /// <summary>
    /// Requires that a raw call succeeded.
    /// </summary>
    /// <param name="retCode">The code the raw call returned.</param>
    /// <param name="indicator">The name of the indicator, for the message.</param>
    /// <remarks>
    /// Unreachable through the fluent surface, because the guards above have already rejected every
    /// input the raw layer can refuse. It exists so that a failure can never degrade quietly into
    /// an empty series, which would be indistinguishable from an indicator that has not warmed up.
    /// </remarks>
    /// <exception cref="InvalidOperationException"><paramref name="retCode"/> is not success.</exception>
    internal static void Succeeded(RetCode retCode, string indicator)
    {
        if (retCode != Success)
        {
            throw new InvalidOperationException(
                string.Create(
                    CultureInfo.InvariantCulture,
                    $"{indicator} failed with {retCode}. This indicates a defect in the library rather than in the " +
                    $"call, because the fluent layer validates every parameter before computing."));
        }
    }
}
