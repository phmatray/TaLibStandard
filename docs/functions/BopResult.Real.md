#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult')

## BopResult\.Real Property

Gets the array of Balance Of Power values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Values range from \-1 to \+1, where:
\- Positive values \(0 to \+1\) indicate buying pressure
\- Negative values \(\-1 to 0\) indicate selling pressure
\- Values near zero indicate balanced market conditions