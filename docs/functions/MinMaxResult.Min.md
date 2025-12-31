#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')

## MinMaxResult\.Min Property

Gets the array of minimum values\.

```csharp
public double[] Min { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Each element represents the lowest value found within the lookback period
ending at that point\. These values can be used as dynamic support levels
or to calculate price channels and bands\.