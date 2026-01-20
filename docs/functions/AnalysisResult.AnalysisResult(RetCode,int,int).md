#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AnalysisResult](AnalysisResult.md 'TechnicalAnalysis\.Functions\.AnalysisResult')

## AnalysisResult\(RetCode, int, int\) Constructor

Initializes a new instance of the AnalysisResult class\.

```csharp
protected AnalysisResult(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.AnalysisResult.AnalysisResult(TechnicalAnalysis.Common.RetCode,int,int).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code indicating the status of the analysis calculation\.

<a name='TechnicalAnalysis.Functions.AnalysisResult.AnalysisResult(TechnicalAnalysis.Common.RetCode,int,int).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The beginning index of the analyzed output series\.

<a name='TechnicalAnalysis.Functions.AnalysisResult.AnalysisResult(TechnicalAnalysis.Common.RetCode,int,int).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of elements in the analyzed output series\.