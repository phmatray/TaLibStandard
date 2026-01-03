#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateArrays\(double\[\]\[\]\) Method

Validates that input and output arrays are not null\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateArrays(params double[]?[] arrays);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateArrays(double[][]).arrays'></a>

`arrays` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Variable number of arrays to validate\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if all arrays are non\-null;
            [BadParam](RetCode.md#TechnicalAnalysis.Common.RetCode.BadParam 'TechnicalAnalysis\.Common\.RetCode\.BadParam') if any array is null\.