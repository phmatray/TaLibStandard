#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateIndexRange\(int, int\) Method

Validates the index range for indicator calculations\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateIndexRange(int startIdx, int endIdx);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateIndexRange(int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateIndexRange(int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if validation passes;
            [OutOfRangeStartIndex](RetCode.md#TechnicalAnalysis.Common.RetCode.OutOfRangeStartIndex 'TechnicalAnalysis\.Common\.RetCode\.OutOfRangeStartIndex') if startIdx is negative;
            [OutOfRangeEndIndex](RetCode.md#TechnicalAnalysis.Common.RetCode.OutOfRangeEndIndex 'TechnicalAnalysis\.Common\.RetCode\.OutOfRangeEndIndex') if endIdx is invalid\.