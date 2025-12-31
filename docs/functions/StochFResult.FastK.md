#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')

## StochFResult\.FastK Property

Gets the array of Fast %K values\.
Values range from 0 to 100, calculated as: 100 × \(Close \- Lowest Low\) / \(Highest High \- Lowest Low\)\.
This raw stochastic value is more sensitive to price changes than the slow version\.

```csharp
public double[] FastK { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')