#### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md 'Atypical\.TechnicalAnalysis\.Candles')
### [TechnicalAnalysis\.Candles](Atypical.TechnicalAnalysis.Candles.md#TechnicalAnalysis.Candles 'TechnicalAnalysis\.Candles').[TACandle](TACandle.md 'TechnicalAnalysis\.Candles\.TACandle')

## TACandle\.CdlAbandonedBaby Method

| Overloads | |
| :--- | :--- |
| [CdlAbandonedBaby&lt;T&gt;\(int, int, T\[\], T\[\], T\[\], T\[\]\)](TACandle.CdlAbandonedBaby.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]) 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)') | |
| [CdlAbandonedBaby&lt;T&gt;\(int, int, T\[\], T\[\], T\[\], T\[\], T\)](TACandle.CdlAbandonedBaby.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T) 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)') | |

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[])'></a>

## TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\) Method

```csharp
public static TechnicalAnalysis.Common.CandleIndicatorResult CdlAbandonedBaby<T>(int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
    where T : System.Numerics.IFloatingPoint<T>;
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).T'></a>

`T`

The type of the array elements\.
#### Parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).open'></a>

`open` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of open prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).high'></a>

`high` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).low'></a>

`low` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).close'></a>

`close` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[]).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\]\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of close prices\.

#### Returns
[TechnicalAnalysis\.Common\.CandleIndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicatorresult 'TechnicalAnalysis\.Common\.CandleIndicatorResult')

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T)'></a>

## TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\) Method

```csharp
public static TechnicalAnalysis.Common.CandleIndicatorResult CdlAbandonedBaby<T>(int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
    where T : System.Numerics.IFloatingPoint<T>;
```
#### Type parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T'></a>

`T`

The type of the array elements\.
#### Parameters

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).open'></a>

`open` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of open prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).high'></a>

`high` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).low'></a>

`low` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).close'></a>

`close` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)\.T')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of close prices\.

<a name='TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).penetration'></a>

`penetration` [T](TACandle.md#TechnicalAnalysis.Candles.TACandle.CdlAbandonedBaby_T_(int,int,T[],T[],T[],T[],T).T 'TechnicalAnalysis\.Candles\.TACandle\.CdlAbandonedBaby\<T\>\(int, int, T\[\], T\[\], T\[\], T\[\], T\)\.T')

#### Returns
[TechnicalAnalysis\.Common\.CandleIndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.candleindicatorresult 'TechnicalAnalysis\.Common\.CandleIndicatorResult')