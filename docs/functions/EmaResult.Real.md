#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[EmaResult](EmaResult.md 'TechnicalAnalysis\.Functions\.EmaResult')

## EmaResult\.Real Property

Gets the array of exponential moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the Exponential Moving Average at each data point\.
Each value is calculated using an exponential weighting factor that gives more importance
to recent price data\.