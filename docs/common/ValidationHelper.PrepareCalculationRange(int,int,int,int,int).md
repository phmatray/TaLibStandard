#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.PrepareCalculationRange\(int, int, int, int, int\) Method

Adjusts the start index based on lookback period and validates the calculation range\.

```csharp
public static bool PrepareCalculationRange(int lookbackTotal, ref int startIdx, int endIdx, ref int outBegIdx, ref int outNBElement);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.PrepareCalculationRange(int,int,int,int,int).lookbackTotal'></a>

`lookbackTotal` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The total lookback period required\.

<a name='TechnicalAnalysis.Common.ValidationHelper.PrepareCalculationRange(int,int,int,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index \(will be adjusted if needed\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.PrepareCalculationRange(int,int,int,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index\.

<a name='TechnicalAnalysis.Common.ValidationHelper.PrepareCalculationRange(int,int,int,int,int).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Output beginning index \(set to 0 if range invalid\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.PrepareCalculationRange(int,int,int,int,int).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Output number of elements \(set to 0 if range invalid\)\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if calculation should proceed;
            `false` if the range is invalid and calculation should be skipped\.