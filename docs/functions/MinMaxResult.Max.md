#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinMaxResult](MinMaxResult.md 'TechnicalAnalysis\.Functions\.MinMaxResult')

## MinMaxResult\.Max Property

Gets the array of maximum values\.

```csharp
public double[] Max { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Each element represents the highest value found within the lookback period
ending at that point\. These values can be used as dynamic resistance levels
or to calculate price channels and bands\.