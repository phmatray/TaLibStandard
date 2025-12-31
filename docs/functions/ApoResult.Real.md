#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[ApoResult](ApoResult.md 'TechnicalAnalysis\.Functions\.ApoResult')

## ApoResult\.Real Property

Gets the array of absolute price oscillator values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the Absolute Price Oscillator at each data point\.
Positive values indicate the fast MA is above the slow MA, while negative values
indicate the fast MA is below the slow MA\.