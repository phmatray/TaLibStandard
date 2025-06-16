#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[HtTrendModeResult](HtTrendModeResult.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult')

## HtTrendModeResult\(RetCode, int, int, int\[\]\) Constructor

Initializes a new instance of the [HtTrendModeResult](HtTrendModeResult.md 'TechnicalAnalysis\.Functions\.HtTrendModeResult') class\.

```csharp
public HtTrendModeResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.HtTrendModeResult.HtTrendModeResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.HtTrendModeResult.HtTrendModeResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output array\.

<a name='TechnicalAnalysis.Functions.HtTrendModeResult.HtTrendModeResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output array\.

<a name='TechnicalAnalysis.Functions.HtTrendModeResult.HtTrendModeResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The array of trend mode values indicating market state \(0 = cycle mode, 1 = trend mode\)\.