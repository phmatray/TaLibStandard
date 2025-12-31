#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')

## RocResult\.Real Property

Gets the array of Rate of Change values\.
Each value represents the percentage change from n periods ago, calculated as: \(\(price \- price\[n periods ago\]\) / price\[n periods ago\]\) \* 100\.
Positive values indicate upward momentum, while negative values indicate downward momentum\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')