#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BetaResult](BetaResult.md 'TechnicalAnalysis\.Functions\.BetaResult')

## BetaResult\.Real Property

Gets the array of beta coefficient values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the beta values over time\. Values above 1\.0 indicate 
the security is more volatile than the benchmark, values below 1\.0 indicate less 
volatility, and negative values indicate inverse movement\. These values are essential 
for portfolio risk assessment and hedging strategies\.