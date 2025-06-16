#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')

## StochRsiResult\.FastK Property

Gets the array of %K values \(raw StochRSI\)\.
This represents the position of the current RSI relative to its range over the lookback period\.
Values range from 0 to 100, with extreme readings suggesting potential reversal points\.

```csharp
public double[] FastK { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')