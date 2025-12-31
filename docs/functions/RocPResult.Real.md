#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')

## RocPResult\.Real Property

Gets the array of Rate of Change Percentage values\.
Each value represents the rate of change as a decimal \(e\.g\., 0\.05 = 5% increase, \-0\.03 = 3% decrease\)\.
This is calculated as: \(price \- price\[n periods ago\]\) / price\[n periods ago\]\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')