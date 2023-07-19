#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles').[CandleCounterAttackResult](CandleCounterAttackResult.md 'TechnicalAnalysis.Candles.CandleCounterAttackResult')

## CandleCounterAttackResult(RetCode, int, int, int[]) Constructor

Initializes a new instance of the CandleCounterAttackResult class.

```csharp
public CandleCounterAttackResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Candles.CandleCounterAttackResult.CandleCounterAttackResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [TechnicalAnalysis.Common.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis.Common.RetCode')

The return code of the indicator calculation.

<a name='TechnicalAnalysis.Candles.CandleCounterAttackResult.CandleCounterAttackResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index of the first element in the result.

<a name='TechnicalAnalysis.Candles.CandleCounterAttackResult.CandleCounterAttackResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of elements in the result.

<a name='TechnicalAnalysis.Candles.CandleCounterAttackResult.CandleCounterAttackResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of integers indicating the presence of the Counter Attack pattern.