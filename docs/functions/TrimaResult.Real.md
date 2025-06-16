#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')

## TrimaResult\.Real Property

Gets the array of triangular moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of double values representing the Triangular Moving Average at each data point\.
Each value is calculated by averaging a simple moving average, which creates a
double\-smoothed result with emphasis on the middle values of the period\.