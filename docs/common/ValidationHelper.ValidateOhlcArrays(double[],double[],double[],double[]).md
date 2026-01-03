#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateOhlcArrays\(double\[\], double\[\], double\[\], double\[\]\) Method

Validates OHLC \(Open, High, Low, Close\) input arrays for candle\-based indicators\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateOhlcArrays(double[]? open, double[]? high, double[]? low, double[]? close);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcArrays(double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcArrays(double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcArrays(double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcArrays(double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if all OHLC arrays are non\-null;
            [BadParam](RetCode.md#TechnicalAnalysis.Common.RetCode.BadParam 'TechnicalAnalysis\.Common\.RetCode\.BadParam') if any array is null\.