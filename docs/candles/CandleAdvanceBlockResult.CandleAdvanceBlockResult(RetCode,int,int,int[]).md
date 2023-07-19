#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles').[CandleAdvanceBlockResult](CandleAdvanceBlockResult.md 'TechnicalAnalysis.Candles.CandleAdvanceBlockResult')

## CandleAdvanceBlockResult(RetCode, int, int, int[]) Constructor

Initializes a new instance of the CandleAdvanceBlockResult class.

```csharp
public CandleAdvanceBlockResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Candles.CandleAdvanceBlockResult.CandleAdvanceBlockResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [TechnicalAnalysis.Common.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis.Common.RetCode')

The return code of the indicator calculation.

<a name='TechnicalAnalysis.Candles.CandleAdvanceBlockResult.CandleAdvanceBlockResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index of the first element in the result.

<a name='TechnicalAnalysis.Candles.CandleAdvanceBlockResult.CandleAdvanceBlockResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of elements in the result.

<a name='TechnicalAnalysis.Candles.CandleAdvanceBlockResult.CandleAdvanceBlockResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of integers indicating the presence of the Advance Block pattern.