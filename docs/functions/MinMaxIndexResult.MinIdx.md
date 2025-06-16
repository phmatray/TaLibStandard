#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinMaxIndexResult](MinMaxIndexResult.md 'TechnicalAnalysis\.Functions\.MinMaxIndexResult')

## MinMaxIndexResult\.MinIdx Property

Gets the array of indices where minimum values occur\.

```csharp
public int[] MinIdx { get; }
```

#### Property Value
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
Each element contains the index position in the original data array where
the minimum value was found within the specified lookback period\.
These indices can be used to identify the exact timing of troughs\.