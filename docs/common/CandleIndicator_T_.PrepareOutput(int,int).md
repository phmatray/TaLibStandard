#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[CandleIndicator&lt;T&gt;](CandleIndicator_T_.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>')

## CandleIndicator\<T\>\.PrepareOutput\(int, int\) Method

Prepares the output variables\.

```csharp
protected virtual ValueTuple<int,int,int[]> PrepareOutput(int startIdx, int endIdx);
```
#### Parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.PrepareOutput(int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The start index\.

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.PrepareOutput(int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The end index\.

#### Returns
[System\.ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the output variables\.