#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')

## MaxIndexResult\(RetCode, int, int, int\[\]\) Constructor

Initializes a new instance of the [MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult') class\.

```csharp
public MaxIndexResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, int[] integers);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MaxIndexResult.MaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Functions.MaxIndexResult.MaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).begIdx'></a>

`begIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid data point in the output array\.

<a name='TechnicalAnalysis.Functions.MaxIndexResult.MaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).nbElement'></a>

`nbElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid data points in the output array\.

<a name='TechnicalAnalysis.Functions.MaxIndexResult.MaxIndexResult(TechnicalAnalysis.Common.RetCode,int,int,int[]).integers'></a>

`integers` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array containing the indices of maximum values\. Each element represents
            the relative position \(offset from the start of the period\) where the maximum value was found
            within the specified rolling window\.