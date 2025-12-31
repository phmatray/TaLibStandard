#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## ValidationHelper Class

Provides centralized validation methods for technical analysis indicators\.

```csharp
public static class ValidationHelper
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ValidationHelper

### Remarks
This helper class consolidates repetitive validation logic that appears across
100\+ indicator functions, reducing code duplication and ensuring consistent
validation behavior throughout the library\.

| Methods | |
| :--- | :--- |
| [PrepareCalculationRange\(int, int, int, int, int\)](ValidationHelper.PrepareCalculationRange(int,int,int,int,int).md 'TechnicalAnalysis\.Common\.ValidationHelper\.PrepareCalculationRange\(int, int, int, int, int\)') | Adjusts the start index based on lookback period and validates the calculation range\. |
| [ValidateArrays\(double\[\]\[\]\)](ValidationHelper.ValidateArrays(double[][]).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateArrays\(double\[\]\[\]\)') | Validates that input and output arrays are not null\. |
| [ValidateIndexRange\(int, int\)](ValidationHelper.ValidateIndexRange(int,int).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateIndexRange\(int, int\)') | Validates the index range for indicator calculations\. |
| [ValidateLookbackPeriod\(int, int, int\)](ValidationHelper.ValidateLookbackPeriod(int,int,int).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateLookbackPeriod\(int, int, int\)') | Validates a lookback period parameter and returns the adjusted lookback value\. |
| [ValidateOhlcArrays\(double\[\], double\[\], double\[\], double\[\]\)](ValidationHelper.ValidateOhlcArrays(double[],double[],double[],double[]).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateOhlcArrays\(double\[\], double\[\], double\[\], double\[\]\)') | Validates OHLC \(Open, High, Low, Close\) input arrays for candle\-based indicators\. |
| [ValidateOhlcvArrays\(double\[\], double\[\], double\[\], double\[\], double\[\]\)](ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateOhlcvArrays\(double\[\], double\[\], double\[\], double\[\], double\[\]\)') | Validates OHLCV \(Open, High, Low, Close, Volume\) input arrays\. |
| [ValidatePeriodRange\(int, int, int\)](ValidationHelper.ValidatePeriodRange(int,int,int).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidatePeriodRange\(int, int, int\)') | Validates a time period parameter is within acceptable range\. |
| [ValidateSingleInputIndicator\(int, int, double\[\], double\[\], Nullable&lt;int&gt;, int, int\)](ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],Nullable_int_,int,int).md 'TechnicalAnalysis\.Common\.ValidationHelper\.ValidateSingleInputIndicator\(int, int, double\[\], double\[\], System\.Nullable\<int\>, int, int\)') | Performs comprehensive validation for single\-input indicators\. |
