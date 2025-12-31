#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[KamaResult](KamaResult.md 'TechnicalAnalysis\.Functions\.KamaResult')

## KamaResult\.Real Property

Gets the array of Kaufman Adaptive Moving Average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the Kaufman Adaptive Moving Average at each data point\.
The values adapt to market conditions, providing faster response in trending markets
and slower response in choppy or sideways markets\.