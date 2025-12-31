#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrixResult](TrixResult.md 'TechnicalAnalysis\.Functions\.TrixResult')

## TrixResult\.Real Property

Gets the array of TRIX values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
TRIX oscillates around zero, where:
\- Positive values indicate upward momentum
\- Negative values indicate downward momentum
\- Crossovers of the zero line can signal trend changes
\- Divergences between price and TRIX can indicate potential reversals