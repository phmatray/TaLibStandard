#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult')

## MinIndexResult\(RetCode, int, int, int\[\]\) Constructor

Initializes a new instance of the [MinIndexResult](MinIndexResult.md 'TechnicalAnalysis\.Functions\.MinIndexResult') class\.

```csharp
public MinIndexResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MinIndexResult.MinIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MinIndexResult.MinIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output array\.

<a name='TechnicalAnalysis.Functions.MinIndexResult.MinIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output array\.

<a name='TechnicalAnalysis.Functions.MinIndexResult.MinIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array containing the indices of minimum values\. Each element represents
            the relative position \(offset from the start of the period\) where the minimum value was found
            within the specified rolling window\.