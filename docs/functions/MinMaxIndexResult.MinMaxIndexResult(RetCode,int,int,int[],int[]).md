#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')

## MinMaxIndexResult\(RetCode, int, int, int\[\], int\[\]\) Constructor

Initializes a new instance of the [MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult') class\.

```csharp
public MinMaxIndexResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] minIdx, int[] maxIdx);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MinMaxIndexResult.MinMaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[],int[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MinMaxIndexResult.MinMaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[],int[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output arrays\.

<a name='TechnicalAnalysis.Functions.MinMaxIndexResult.MinMaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[],int[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output arrays\.

<a name='TechnicalAnalysis.Functions.MinMaxIndexResult.MinMaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[],int[]).minIdx'></a>

`minIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of indices where minimum values occur within each period\.

<a name='TechnicalAnalysis.Functions.MinMaxIndexResult.MinMaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[],int[]).maxIdx'></a>

`maxIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of indices where maximum values occur within each period\.