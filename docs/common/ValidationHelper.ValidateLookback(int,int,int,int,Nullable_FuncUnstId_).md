#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateLookback\(int, int, int, int, Nullable\<FuncUnstId\>\) Method

Validates a lookback period and returns the adjusted lookback value with optional modifications\.

```csharp
public static int ValidateLookback(int period, int adjustment=0, int minPeriod=2, int maxPeriod=100000, System.Nullable<TechnicalAnalysis.Common.FuncUnstId> unstablePeriod=null);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookback(int,int,int,int,System.Nullable_TechnicalAnalysis.Common.FuncUnstId_).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The time period to validate\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookback(int,int,int,int,System.Nullable_TechnicalAnalysis.Common.FuncUnstId_).adjustment'></a>

`adjustment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Value to add to the period \(e\.g\., \-1 for period\-1 lookback\)\. Default: 0\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookback(int,int,int,int,System.Nullable_TechnicalAnalysis.Common.FuncUnstId_).minPeriod'></a>

`minPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum allowed period\. Default: [MinPeriod](ValidationHelper.MinPeriod.md 'TechnicalAnalysis\.Common\.ValidationHelper\.MinPeriod') \(2\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookback(int,int,int,int,System.Nullable_TechnicalAnalysis.Common.FuncUnstId_).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum allowed period\. Default: [MaxPeriod](ValidationHelper.MaxPeriod.md 'TechnicalAnalysis\.Common\.ValidationHelper\.MaxPeriod') \(100000\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateLookback(int,int,int,int,System.Nullable_TechnicalAnalysis.Common.FuncUnstId_).unstablePeriod'></a>

`unstablePeriod` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[FuncUnstId](FuncUnstId.md 'TechnicalAnalysis\.Common\.FuncUnstId')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Optional unstable period function ID to add to the result\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
\-1 if the period is out of range;
the validated and adjusted lookback value otherwise\.

### Remarks
This method consolidates the common lookback validation pattern used across 40\+ indicators\.
It handles several common cases:
\- Simple period validation: ValidateLookback\(period\)
\- With adjustment: ValidateLookback\(period, adjustment: \-1\)
\- With min period: ValidateLookback\(period, minPeriod: 1\)
\- With unstable period: ValidateLookback\(period, unstablePeriod: FuncUnstId\.Ema\)
\- Complex: ValidateLookback\(period, adjustment: \-1, unstablePeriod: FuncUnstId\.Ema\)

Examples:

```csharp
// CCI: period - 1
public static int CciLookback(int optInTimePeriod) =>
    ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1);

// SMA: period (no adjustment)
ublic static int SmaLookback(int optInTimePeriod) =>
    ValidationHelper.ValidateLookback(optInTimePeriod, minPeriod: 1);

// EMA: period - 1 + unstable period
public static int EmaLookback(int optInTimePeriod) =>
    ValidationHelper.ValidateLookback(optInTimePeriod, adjustment: -1,
        unstablePeriod: FuncUnstId.Ema);
```