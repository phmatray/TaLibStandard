#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[IndicatorResult](IndicatorResult.md 'TechnicalAnalysis\.Common\.IndicatorResult')

## IndicatorResult\(RetCode, int, int\) Constructor

Initializes a new instance of the IndicatorBase class\.

```csharp
protected IndicatorResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement);
```
#### Parameters

<a name='TechnicalAnalysis.Common.IndicatorResult.IndicatorResult(TechnicalAnalysis.Common.RetCode,int,int).retCode'></a>

`retCode` [RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the indicator calculation\.

<a name='TechnicalAnalysis.Common.IndicatorResult.IndicatorResult(TechnicalAnalysis.Common.RetCode,int,int).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the calculated output series\.

<a name='TechnicalAnalysis.Common.IndicatorResult.IndicatorResult(TechnicalAnalysis.Common.RetCode,int,int).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the calculated output series\.