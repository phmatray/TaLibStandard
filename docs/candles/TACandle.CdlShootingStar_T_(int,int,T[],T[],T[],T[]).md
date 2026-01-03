#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles').[TACandle](TACandle.md 'TechnicalAnalysis\.Candles\.TACandle')

## TACandle\.CdlShootingStar\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\) Method

```csharp
public static TechnicalAnalysis.Common.CandleIndicatorResult CdlShootingStar<T>(int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
    where T : System.Numerics.IFloatingPoint<T>;
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).T'></a>

`T`

The type of the array elements\.
#### Parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).open'></a>

`open` [T](TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).md#TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlShootingStar\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of open prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).high'></a>

`high` [T](TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).md#TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlShootingStar\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).low'></a>

`low` [T](TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).md#TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlShootingStar\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).close'></a>

`close` [T](TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).md#TechnicalAnalysis.Candles.TACandle.CdlShootingStar_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlShootingStar\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of close prices\.

#### Returns
[TechnicalAnalysis\.Common\.CandleIndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicatorresult 'TechnicalAnalysis\.Common\.CandleIndicatorResult')