// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.UnitTests.Helpers;

public class ValidationHelperTests
{
    #region ValidateIndexRange Tests

    [Fact]
    public void ValidateIndexRange_ValidIndices_ReturnsSuccess()
    {
        // Arrange
        const int startIdx = 0;
        const int endIdx = 99;

        // Act
        RetCode result = ValidationHelper.ValidateIndexRange(startIdx, endIdx);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidateIndexRange_NegativeStartIdx_ReturnsOutOfRangeStartIndex()
    {
        // Arrange
        const int startIdx = -1;
        const int endIdx = 99;

        // Act
        RetCode result = ValidationHelper.ValidateIndexRange(startIdx, endIdx);

        // Assert
        result.ShouldBe(RetCode.OutOfRangeStartIndex);
    }

    [Fact]
    public void ValidateIndexRange_NegativeEndIdx_ReturnsOutOfRangeEndIndex()
    {
        // Arrange
        const int startIdx = 0;
        const int endIdx = -1;

        // Act
        RetCode result = ValidationHelper.ValidateIndexRange(startIdx, endIdx);

        // Assert
        result.ShouldBe(RetCode.OutOfRangeEndIndex);
    }

    [Fact]
    public void ValidateIndexRange_EndIdxLessThanStartIdx_ReturnsOutOfRangeEndIndex()
    {
        // Arrange
        const int startIdx = 50;
        const int endIdx = 49;

        // Act
        RetCode result = ValidationHelper.ValidateIndexRange(startIdx, endIdx);

        // Assert
        result.ShouldBe(RetCode.OutOfRangeEndIndex);
    }

    #endregion

    #region ValidatePeriodRange Tests

    [Fact]
    public void ValidatePeriodRange_ValidPeriod_ReturnsSuccess()
    {
        // Arrange
        const int period = 14;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidatePeriodRange_PeriodBelowMin_ReturnsBadParam()
    {
        // Arrange
        const int period = 1;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidatePeriodRange_PeriodAboveMax_ReturnsBadParam()
    {
        // Arrange
        const int period = 100001;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidatePeriodRange_PeriodAtMinBoundary_ReturnsSuccess()
    {
        // Arrange
        const int period = 2;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidatePeriodRange_PeriodAtMaxBoundary_ReturnsSuccess()
    {
        // Arrange
        const int period = 100000;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidatePeriodRange_CustomRange_ValidatesCorrectly()
    {
        // Arrange
        const int period = 5;
        const int minPeriod = 1;
        const int maxPeriod = 50;

        // Act
        RetCode result = ValidationHelper.ValidatePeriodRange(period, minPeriod, maxPeriod);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    #endregion

    #region ValidateArrays Tests

    [Fact]
    public void ValidateArrays_AllArraysNonNull_ReturnsSuccess()
    {
        // Arrange
        Fixture fixture = new();
        double[] array1 = [.. fixture.CreateMany<double>(10)];
        double[] array2 = [.. fixture.CreateMany<double>(10)];

        // Act
        RetCode result = ValidationHelper.ValidateArrays(array1, array2);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidateArrays_FirstArrayNull_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        double[]? array1 = null;
        double[] array2 = [.. fixture.CreateMany<double>(10)];

        // Act
        RetCode result = ValidationHelper.ValidateArrays(array1, array2);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidateArrays_SecondArrayNull_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        double[] array1 = [.. fixture.CreateMany<double>(10)];
        double[]? array2 = null;

        // Act
        RetCode result = ValidationHelper.ValidateArrays(array1, array2);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidateArrays_AllArraysNull_ReturnsBadParam()
    {
        // Arrange
        double[]? array1 = null;
        double[]? array2 = null;

        // Act
        RetCode result = ValidationHelper.ValidateArrays(array1, array2);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    #endregion

    #region ValidateOhlcArrays Tests

    [Fact]
    public void ValidateOhlcArrays_AllArraysValid_ReturnsSuccess()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(10)];
        double[] high = [.. fixture.CreateMany<double>(10)];
        double[] low = [.. fixture.CreateMany<double>(10)];
        double[] close = [.. fixture.CreateMany<double>(10)];

        // Act
        RetCode result = ValidationHelper.ValidateOhlcArrays(open, high, low, close);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidateOhlcArrays_OpenNull_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        double[]? open = null;
        double[] high = [.. fixture.CreateMany<double>(10)];
        double[] low = [.. fixture.CreateMany<double>(10)];
        double[] close = [.. fixture.CreateMany<double>(10)];

        // Act
        RetCode result = ValidationHelper.ValidateOhlcArrays(open, high, low, close);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidateOhlcArrays_CloseNull_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(10)];
        double[] high = [.. fixture.CreateMany<double>(10)];
        double[] low = [.. fixture.CreateMany<double>(10)];
        double[]? close = null;

        // Act
        RetCode result = ValidationHelper.ValidateOhlcArrays(open, high, low, close);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    #endregion

    #region ValidateOhlcvArrays Tests

    [Fact]
    public void ValidateOhlcvArrays_AllArraysValid_ReturnsSuccess()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(10)];
        double[] high = [.. fixture.CreateMany<double>(10)];
        double[] low = [.. fixture.CreateMany<double>(10)];
        double[] close = [.. fixture.CreateMany<double>(10)];
        double[] volume = [.. fixture.CreateMany<double>(10)];

        // Act
        RetCode result = ValidationHelper.ValidateOhlcvArrays(open, high, low, close, volume);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidateOhlcvArrays_VolumeNull_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        double[] open = [.. fixture.CreateMany<double>(10)];
        double[] high = [.. fixture.CreateMany<double>(10)];
        double[] low = [.. fixture.CreateMany<double>(10)];
        double[] close = [.. fixture.CreateMany<double>(10)];
        double[]? volume = null;

        // Act
        RetCode result = ValidationHelper.ValidateOhlcvArrays(open, high, low, close, volume);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    #endregion

    #region ValidateSingleInputIndicator Tests

    [Fact]
    public void ValidateSingleInputIndicator_AllValid_ReturnsSuccess()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] inReal = [.. fixture.CreateMany<double>(100)];
        double[] outReal = new double[100];
        const int optInTimePeriod = 14;

        // Act
        RetCode result = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);

        // Assert
        result.ShouldBe(RetCode.Success);
    }

    [Fact]
    public void ValidateSingleInputIndicator_InvalidIndex_ReturnsOutOfRangeStartIndex()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = -1;
        const int endIdx = 99;
        double[] inReal = [.. fixture.CreateMany<double>(100)];
        double[] outReal = new double[100];

        // Act
        RetCode result = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal);

        // Assert
        result.ShouldBe(RetCode.OutOfRangeStartIndex);
    }

    [Fact]
    public void ValidateSingleInputIndicator_NullInReal_ReturnsBadParam()
    {
        // Arrange
        const int startIdx = 0;
        const int endIdx = 99;
        double[]? inReal = null;
        double[] outReal = new double[100];

        // Act
        RetCode result = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    [Fact]
    public void ValidateSingleInputIndicator_InvalidPeriod_ReturnsBadParam()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] inReal = [.. fixture.CreateMany<double>(100)];
        double[] outReal = new double[100];
        const int optInTimePeriod = 1;

        // Act
        RetCode result = ValidationHelper.ValidateSingleInputIndicator(
            startIdx, endIdx, inReal, outReal, optInTimePeriod);

        // Assert
        result.ShouldBe(RetCode.BadParam);
    }

    #endregion

    #region PrepareCalculationRange Tests

    [Fact]
    public void PrepareCalculationRange_ValidRange_ReturnsTrue()
    {
        // Arrange
        const int lookbackTotal = 10;
        int startIdx = 20;
        const int endIdx = 99;
        int outBegIdx = 0;
        int outNBElement = 0;

        // Act
        bool result = ValidationHelper.PrepareCalculationRange(
            lookbackTotal, ref startIdx, endIdx, ref outBegIdx, ref outNBElement);

        // Assert
        result.ShouldBeTrue();
        startIdx.ShouldBe(20);
    }

    [Fact]
    public void PrepareCalculationRange_StartIdxLessThanLookback_AdjustsStartIdx()
    {
        // Arrange
        const int lookbackTotal = 20;
        int startIdx = 10;
        const int endIdx = 99;
        int outBegIdx = 0;
        int outNBElement = 0;

        // Act
        bool result = ValidationHelper.PrepareCalculationRange(
            lookbackTotal, ref startIdx, endIdx, ref outBegIdx, ref outNBElement);

        // Assert
        result.ShouldBeTrue();
        startIdx.ShouldBe(20);
    }

    [Fact]
    public void PrepareCalculationRange_StartIdxGreaterThanEndIdx_ReturnsFalse()
    {
        // Arrange
        const int lookbackTotal = 10;
        int startIdx = 100;
        const int endIdx = 99;
        int outBegIdx = 0;
        int outNBElement = 0;

        // Act
        bool result = ValidationHelper.PrepareCalculationRange(
            lookbackTotal, ref startIdx, endIdx, ref outBegIdx, ref outNBElement);

        // Assert
        result.ShouldBeFalse();
        outBegIdx.ShouldBe(0);
        outNBElement.ShouldBe(0);
    }

    #endregion

    #region ValidateLookbackPeriod Tests

    [Fact]
    public void ValidateLookbackPeriod_ValidPeriod_ReturnsPeriod()
    {
        // Arrange
        const int period = 14;

        // Act
        int result = ValidationHelper.ValidateLookback(period);

        // Assert
        result.ShouldBe(14);
    }

    [Fact]
    public void ValidateLookbackPeriod_PeriodBelowMin_ReturnsNegativeOne()
    {
        // Arrange
        const int period = 1;

        // Act
        int result = ValidationHelper.ValidateLookback(period);

        // Assert
        result.ShouldBe(-1);
    }

    [Fact]
    public void ValidateLookbackPeriod_PeriodAboveMax_ReturnsNegativeOne()
    {
        // Arrange
        const int period = 100001;

        // Act
        int result = ValidationHelper.ValidateLookback(period);

        // Assert
        result.ShouldBe(-1);
    }

    [Fact]
    public void ValidateLookbackPeriod_CustomRange_ValidatesCorrectly()
    {
        // Arrange
        const int period = 5;
        const int minPeriod = 1;
        const int maxPeriod = 50;

        // Act
        int result = ValidationHelper.ValidateLookback(period, minPeriod: minPeriod, maxPeriod: maxPeriod);

        // Assert
        result.ShouldBe(5);
    }

    #endregion
}
