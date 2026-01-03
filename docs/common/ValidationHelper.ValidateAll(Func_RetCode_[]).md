#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateAll\(Func\<RetCode\>\[\]\) Method

Executes multiple validation functions sequentially, returning the first error encountered\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateAll(params System.Func<TechnicalAnalysis.Common.RetCode>[] validations);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateAll(System.Func_TechnicalAnalysis.Common.RetCode_[]).validations'></a>

`validations` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

One or more validation functions that return RetCode\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if all validations pass;
             the first non\-Success RetCode encountered otherwise\.

### Remarks
This method consolidates the common pattern of running multiple validation checks
and returning early on the first failure\. It reduces boilerplate code across
indicator functions that typically perform 3\-5 sequential validation checks\.

Example usage:

```csharp
RetCode validation = ValidationHelper.ValidateAll(
    () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
    () => ValidationHelper.ValidateArrays(inReal, outReal),
    () => ValidationHelper.ValidatePeriodRange(optInTimePeriod)
);
if (validation != Success) return validation;
```