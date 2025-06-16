#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MinusDMResult](MinusDMResult.md 'TechnicalAnalysis\.Functions\.MinusDMResult')

## MinusDMResult\.Real Property

Gets the array of Minus Directional Movement values\.
Each value represents the negative \(downward\) directional movement for the period\.
Calculated as the difference between previous low and current low when it's positive and greater than the upward movement\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')