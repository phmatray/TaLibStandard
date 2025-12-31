#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[SingleOutputResult](SingleOutputResult.md 'TechnicalAnalysis\.Common\.SingleOutputResult')

## SingleOutputResult\(RetCode, int, int, double\[\]\) Constructor

Initializes a new instance of the [SingleOutputResult](SingleOutputResult.md 'TechnicalAnalysis\.Common\.SingleOutputResult') class\.

```csharp
protected SingleOutputResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Common.SingleOutputResult.SingleOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).retCode'></a>

`retCode` [RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the success or failure of the calculation\.

<a name='TechnicalAnalysis.Common.SingleOutputResult.SingleOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid data point in the output array\.

<a name='TechnicalAnalysis.Common.SingleOutputResult.SingleOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid data points in the output array\.

<a name='TechnicalAnalysis.Common.SingleOutputResult.SingleOutputResult(TechnicalAnalysis.Common.RetCode,int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The array of calculated indicator values\.