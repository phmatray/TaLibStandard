#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')

## MidPointResult\.Real Property

Gets the array of midpoint values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Each value represents the midpoint of the price range over the lookback period,
calculated as \(highest \+ lowest\) / 2\. The midpoint line can act as a dynamic
support/resistance level and helps identify the central tendency of price movement\.