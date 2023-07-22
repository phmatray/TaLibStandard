#### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md 'TechnicalAnalysis.Candles')
### [TechnicalAnalysis.Candles](TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis.Candles').[TACandle](TACandle.md 'TechnicalAnalysis.Candles.TACandle')

## TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T) Method

```csharp
public static TechnicalAnalysis.Common.CandleIndicatorResult CdlDarkCloudCover<T>(int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
    where T : System.Numerics.IFloatingPoint<T>;
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T'></a>

`T`
#### Parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).startIdx'></a>

`startIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).endIdx'></a>

`endIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).open'></a>

`open` [T](TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).md#TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of open prices.

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).high'></a>

`high` [T](TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).md#TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of high prices.

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).low'></a>

`low` [T](TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).md#TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of low prices.

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).close'></a>

`close` [T](TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).md#TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of close prices.

<a name='TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).penetration'></a>

`penetration` [T](TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).md#TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis.Candles.TACandle.CdlDarkCloudCover<T>(int, int, T[], T[], T[], T[], T).T')

#### Returns
[TechnicalAnalysis.Common.CandleIndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.CandleIndicatorResult 'TechnicalAnalysis.Common.CandleIndicatorResult')