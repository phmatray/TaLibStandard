#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common').[CandleIndicatorResult](CandleIndicatorResult.md 'TechnicalAnalysis.Common.CandleIndicatorResult')

## CandleIndicatorResult(RetCode, int, int, int[]) Constructor

Initializes a new instance of the CandleResult class.

```csharp
public CandleIndicatorResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicatorResult.CandleIndicatorResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [RetCode](RetCode.md 'TechnicalAnalysis.Common.RetCode')

The return code of the indicator calculation.

<a name='TechnicalAnalysis.Common.CandleIndicatorResult.CandleIndicatorResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index of the first element in the result.

<a name='TechnicalAnalysis.Common.CandleIndicatorResult.CandleIndicatorResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of elements in the result.

<a name='TechnicalAnalysis.Common.CandleIndicatorResult.CandleIndicatorResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of integers indicating the presence of the pattern.