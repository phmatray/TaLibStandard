// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Collections.Concurrent;
using System.Reflection;

namespace TechnicalAnalysis.Functions.UnitTests.HighLevel;

/// <remarks>
/// Exception behaviour across every indicator, plus the three machine-checkable forms of the design
/// constraint itself: no public member names a raw TA-Lib index, absence is a nullable type rather
/// than a sentinel, and the whole surface is a set of values with no shared mutable state.
/// </remarks>
public class HighLevelValidationTests
{
    private static readonly Type[] HighLevelPublicSurface =
    [
        typeof(PriceSeries),
        typeof(IndicatorSeries),
        typeof(OverlapStudyIndicators),
        typeof(MomentumIndicators),
        typeof(VolatilityIndicators),
        typeof(VolumeIndicators),
    ];

    private static double[] Ramp(int count)
    {
        double[] values = new double[count];
        for (int i = 0; i < count; i++)
        {
            values[i] = i + 1;
        }

        return values;
    }

    private static double[] Constant(int count, double value)
    {
        double[] values = new double[count];
        Array.Fill(values, value);
        return values;
    }

    private static PriceSeries CloseOnly()
    {
        return PriceSeries.FromClose(Ramp(100));
    }

    private static PriceSeries Hlc()
    {
        return PriceSeries.FromHlc(Constant(100, 102.0), Constant(100, 98.0), Constant(100, 100.0));
    }

    private static IEnumerable<(string Member, string Parameter)> PublicParameters(Type type)
    {
        const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

        foreach (MethodInfo method in type.GetMethods(Flags))
        {
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                yield return (method.Name, parameter.Name ?? string.Empty);
            }
        }

        foreach (ConstructorInfo constructor in type.GetConstructors(Flags))
        {
            foreach (ParameterInfo parameter in constructor.GetParameters())
            {
                yield return (".ctor", parameter.Name ?? string.Empty);
            }
        }

        foreach (PropertyInfo property in type.GetProperties(Flags))
        {
            foreach (ParameterInfo parameter in property.GetIndexParameters())
            {
                yield return (property.Name, parameter.Name ?? string.Empty);
            }
        }
    }

    [Fact]
    public void EveryPeriodBelowTwoIsRejectedUniformlyAcrossEveryIndicator()
    {
        // Arrange
        // One rule for every period parameter of every indicator: [2, 100000]. This is deliberately
        // stricter than TAMath, where Atr and Stoch accept 1 and Sma, Ema, Rsi and BollingerBands
        // do not -- a single rule cannot be got wrong by the author of the next indicator.
        PriceSeries closes = CloseOnly();
        PriceSeries hlc = Hlc();

        // Act
        List<ArgumentOutOfRangeException> thrown =
        [
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.Sma(1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.Sma(0); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.Sma(-1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.Ema(1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.Rsi(1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = hlc.Atr(1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = hlc.Adx(1); }),
            Should.Throw<ArgumentOutOfRangeException>(() => { _ = closes.BollingerBands(1); }),
        ];

        // Assert
        foreach (ArgumentOutOfRangeException exception in thrown)
        {
            exception.ParamName.ShouldBe("timePeriod");
        }
    }

    [Fact]
    public void APeriodAboveTheUpperBoundIsRejected()
    {
        // Arrange
        // ValidationHelper.MaxPeriod is 100000, so 100001 is one past the boundary.
        PriceSeries closes = CloseOnly();

        // Act
        ArgumentOutOfRangeException tooLarge = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = closes.Sma(100001);
        });

        // Assert
        tooLarge.ParamName.ShouldBe("timePeriod");
    }

    [Fact]
    public void EveryMacdPeriodIsValidatedIndividually()
    {
        // Arrange
        // The signalPeriod case is the important one: TAMath.Macd accepts a signal period of 1 and
        // then throws ArgumentOutOfRangeException from Array.Copy inside TA_INT_MACD rather than
        // returning a code. The facade must refuse before TAMath is reached.
        PriceSeries closes = CloseOnly();

        // Act
        ArgumentOutOfRangeException fast = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = closes.Macd(1, 26, 9);
        });

        ArgumentOutOfRangeException slow = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = closes.Macd(12, 1, 9);
        });

        ArgumentOutOfRangeException signal = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = closes.Macd(12, 26, 1);
        });

        // Assert
        fast.ParamName.ShouldBe("fastPeriod");
        slow.ParamName.ShouldBe("slowPeriod");
        signal.ParamName.ShouldBe("signalPeriod");
    }

    [Fact]
    public void EveryStochPeriodIsValidatedIndividually()
    {
        // Arrange
        PriceSeries hlc = Hlc();

        // Act
        ArgumentOutOfRangeException fastK = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = hlc.Stoch(1, 3, MAType.Sma, 3, MAType.Sma);
        });

        ArgumentOutOfRangeException slowK = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = hlc.Stoch(5, 1, MAType.Sma, 3, MAType.Sma);
        });

        ArgumentOutOfRangeException slowD = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = hlc.Stoch(5, 3, MAType.Sma, 1, MAType.Sma);
        });

        // Assert
        fastK.ParamName.ShouldBe("fastKPeriod");
        slowK.ParamName.ShouldBe("slowKPeriod");
        slowD.ParamName.ShouldBe("slowDPeriod");
    }

    [Fact]
    public void PeriodValidationHappensBeforeEmptinessAndBeforeTheOhlcRequirement()
    {
        // Arrange
        // The order is part of the contract: period, then component availability, then the empty
        // short-circuit. So a bad period always reports itself as a bad period, whatever else is
        // also wrong with the call.
        PriceSeries empty = PriceSeries.Empty;
        PriceSeries closeOnly = CloseOnly();

        // Act
        ArgumentOutOfRangeException onEmpty = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = empty.Sma(1);
        });

        ArgumentOutOfRangeException onCloseOnly = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            _ = closeOnly.Atr(1);
        });

        // Assert
        onEmpty.ParamName.ShouldBe("timePeriod");
        onCloseOnly.ParamName.ShouldBe("timePeriod");
    }

    [Fact]
    public void DeviationsAreNotValidatedAndZeroCollapsesTheBandsOntoTheMiddle()
    {
        // Arrange
        // TA-Lib accepts any finite deviation, so the facade adds no rule of its own. With both
        // deviations 0 the envelope has no width and all three bands read the 20-period mean of
        // closes 81..100 = 90.5.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));

        // Act
        BollingerBandsSeries bands = prices.BollingerBands(20, 0.0, 0.0);

        // Assert
        bands.Upper.Latest.ShouldBe(90.5);
        bands.Middle.Latest.ShouldBe(90.5);
        bands.Lower.Latest.ShouldBe(90.5);
    }

    [Fact]
    public void NoPublicMemberNamesARawTaLibIndex()
    {
        // Arrange
        // This is the machine-checkable form of the whole design constraint. startIdx and endIdx do
        // not exist on this surface at all -- every indicator analyses the full range and windowing
        // is expressed by AsOf. begIdx and nbElement appear in exactly one place, the single point
        // at which raw TA-Lib metadata enters the type system.
        List<(string Type, string Member, string Parameter)> parameters = [];
        foreach (Type type in HighLevelPublicSurface)
        {
            foreach ((string member, string parameter) in PublicParameters(type))
            {
                parameters.Add((type.Name, member, parameter));
            }
        }

        // Act
        List<(string Type, string Member, string Parameter)> rawIndexParameters =
            [.. parameters.Where(p => p.Parameter is "startIdx" or "endIdx")];

        List<(string Type, string Member, string Parameter)> rawMetadataParameters =
            [.. parameters.Where(p => p.Parameter is "begIdx" or "nbElement")];

        // Assert
        parameters.ShouldNotBeEmpty();
        rawIndexParameters.ShouldBeEmpty();
        rawMetadataParameters.ShouldAllBe(p => p.Type == nameof(IndicatorSeries) && p.Member == "Create");
        rawMetadataParameters.Count.ShouldBe(2);
    }

    [Fact]
    public void NoArraySpaceMemberWearsABarSpaceName()
    {
        // Arrange
        // IndicatorSeries has two index spaces and one indexer, so the names that read as bar space
        // must not be occupied by array-space members.
        //   Count   reads as "the number of valid indices" on any type with an indexer, and the
        //           indexer's domain here is [0, BarCount) -- so the array-space count is WarmCount
        //           and `for (i = 0; i < s.Count; i++) s[i]` cannot be written at all.
        //   Values  is the first name a caller reaches for, and series.Values[bar] would compile
        //           and return a plausible number for the wrong bar -- so it is WarmValues.
        //   IsEmpty means "no bars" on PriceSeries; here it would mean "no values" on a type that
        //           also has a BarCount, so the warmth test is HasValues.
        Type series = typeof(IndicatorSeries);
        const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        // Act
        string[] memberNames = [.. series.GetMembers(Flags).Select(m => m.Name)];

        // Assert
        memberNames.ShouldContain(nameof(IndicatorSeries.WarmCount));
        memberNames.ShouldContain(nameof(IndicatorSeries.WarmValues));
        memberNames.ShouldContain(nameof(IndicatorSeries.HasValues));
        memberNames.ShouldNotContain("Count");
        memberNames.ShouldNotContain("Values");
        memberNames.ShouldNotContain("IsEmpty");

        // PriceSeries keeps IsEmpty, where it unambiguously means "no bars".
        typeof(PriceSeries).GetProperty(nameof(PriceSeries.IsEmpty)).ShouldNotBeNull();
    }

    [Fact]
    public void AbsenceIsANullableTypeRatherThanASentinelValue()
    {
        // Arrange
        // A double? is discovered by the compiler; a NaN or a 0.0 is discovered in production.
        // Making "no value" a distinct type is the strongest available fix for a bug whose whole
        // shape was "a plausible-looking number where there was no value".
        Type type = typeof(IndicatorSeries);

        // Act
        PropertyInfo indexer = type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Single(p => p.GetIndexParameters().Length == 1);
        PropertyInfo? latest = type.GetProperty(nameof(IndicatorSeries.Latest));
        PropertyInfo? firstBar = type.GetProperty(nameof(IndicatorSeries.FirstBar));
        PropertyInfo? lastBar = type.GetProperty(nameof(IndicatorSeries.LastBar));

        // Assert
        indexer.PropertyType.ShouldBe(typeof(double?));
        indexer.GetIndexParameters()[0].ParameterType.ShouldBe(typeof(int));
        latest.ShouldNotBeNull();
        latest.PropertyType.ShouldBe(typeof(double?));
        firstBar.ShouldNotBeNull();
        firstBar.PropertyType.ShouldBe(typeof(int?));
        lastBar.ShouldNotBeNull();
        lastBar.PropertyType.ShouldBe(typeof(int?));
    }

    [Fact]
    public void EqualityIsReferenceIdentityOverTheBackingArray()
    {
        // Arrange
        // Two separate calls compute two separate output arrays, so the series are not equal even
        // though every value agrees. AsOf allocates nothing and keeps the same array, so narrowing
        // to the last bar is genuinely the same value.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        IndicatorSeries first = prices.Sma(30);
        IndicatorSeries second = prices.Sma(30);
        IndicatorSeries identity = first.AsOf(99);

        // Act
        bool separateCallsEqual = first == second;
#pragma warning disable CS1718 // Comparison made to same variable -- reflexivity of operator== is exactly what is under test.
        bool selfEqual = first == first;
#pragma warning restore CS1718
        bool narrowingIsIdentity = identity == first;

        // Assert
        separateCallsEqual.ShouldBeFalse();
        first.Equals(second).ShouldBeFalse();
        first.Equals((object)second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
        selfEqual.ShouldBeTrue();
        narrowingIsIdentity.ShouldBeTrue();

        // Values agree even though the series do not, which is exactly what "not a value comparison"
        // means. If this ever fails, the two series are not merely unequal -- they disagree.
        first.Latest.ShouldBe(second.Latest);

        identity.GetHashCode().ShouldBe(first.GetHashCode());
        first.GetHashCode().ShouldBe(first.GetHashCode());
        first.GetHashCode().ShouldNotBe(
            second.GetHashCode(),
            "Two distinct backing arrays should hash differently; a genuine collision here is astronomically unlikely.");
    }

    [Fact]
    public void ConcurrentUseOfOneSharedPriceSeriesGivesTheSequentialAnswers()
    {
        // Arrange
        // There is no cache, no lazy field and no lock anywhere on this surface: a PriceSeries is an
        // immutable copy and every IndicatorSeries wraps a freshly allocated array nothing else
        // holds. So this must pass unconditionally, not merely usually.
        PriceSeries prices = PriceSeries.FromClose(Ramp(100));
        double? expectedSma = prices.Sma(30).Latest;
        double? expectedRsi = prices.Rsi(14).Latest;
        double? expectedMacd = prices.Macd().Line.Latest;
        ConcurrentBag<(double? Sma, double? Rsi, double? Macd)> observed = [];

        // Act
        Parallel.For(0, 256, _ =>
        {
            observed.Add((prices.Sma(30).Latest, prices.Rsi(14).Latest, prices.Macd().Line.Latest));
        });

        // Assert
        expectedSma.ShouldBe(85.5);
        expectedRsi.ShouldBe(100.0);
        expectedMacd.ShouldBe(7.0);
        observed.Count.ShouldBe(256);

        foreach ((double? sma, double? rsi, double? macd) in observed)
        {
            sma.ShouldBe(expectedSma);
            rsi.ShouldBe(expectedRsi);
            macd.ShouldBe(expectedMacd);
        }
    }
}
