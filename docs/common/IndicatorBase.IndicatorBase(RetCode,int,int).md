#### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md 'TechnicalAnalysis.Common')
### [TechnicalAnalysis.Common](TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis.Common').[IndicatorBase](IndicatorBase.md 'TechnicalAnalysis.Common.IndicatorBase')

## IndicatorBase(RetCode, int, int) Constructor

Initializes a new instance of the IndicatorBase class.

```csharp
protected IndicatorBase(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement);
```
#### Parameters

<a name='TechnicalAnalysis.Common.IndicatorBase.IndicatorBase(TechnicalAnalysis.Common.RetCode,int,int).retCode'></a>

`retCode` [RetCode](RetCode.md 'TechnicalAnalysis.Common.RetCode')

The return code indicating the status of the indicator calculation.

<a name='TechnicalAnalysis.Common.IndicatorBase.IndicatorBase(TechnicalAnalysis.Common.RetCode,int,int).begIdx'></a>

`begIdx` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The beginning index of the calculated output series.

<a name='TechnicalAnalysis.Common.IndicatorBase.IndicatorBase(TechnicalAnalysis.Common.RetCode,int,int).nbElement'></a>

`nbElement` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of elements in the calculated output series.