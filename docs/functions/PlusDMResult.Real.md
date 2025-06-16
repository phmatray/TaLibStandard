#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PlusDMResult](PlusDMResult.md 'TechnicalAnalysis\.Functions\.PlusDMResult')

## PlusDMResult\.Real Property

Gets the array of Plus Directional Movement values\.
Each value represents the positive \(upward\) directional movement for the period\.
Calculated as the difference between current high and previous high when it's positive and greater than the downward movement\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')