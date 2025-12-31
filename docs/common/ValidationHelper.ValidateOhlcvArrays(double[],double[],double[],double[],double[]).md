#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateOhlcvArrays\(double\[\], double\[\], double\[\], double\[\], double\[\]\) Method

Validates OHLCV \(Open, High, Low, Close, Volume\) input arrays\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateOhlcvArrays(double[]? open, double[]? high, double[]? low, double[]? close, double[]? volume);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateOhlcvArrays(double[],double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of volume data\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if all OHLCV arrays are non\-null;
            [BadParam](RetCode.md#TechnicalAnalysis.Common.RetCode.BadParam 'TechnicalAnalysis\.Common\.RetCode\.BadParam') if any array is null\.