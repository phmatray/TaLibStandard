#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MovingAverageResult](MovingAverageResult.md 'TechnicalAnalysis\.Functions\.MovingAverageResult')

## MovingAverageResult\.Real Property

Gets the array of moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
The moving average values smooth out price action and help identify trends\.
Common uses include:
\- Trend identification \(price above MA = uptrend, below = downtrend\)
\- Support and resistance levels
\- Signal generation through crossovers
\- Filtering out market noise