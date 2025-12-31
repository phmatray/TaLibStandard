#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PpoResult](PpoResult.md 'TechnicalAnalysis\.Functions\.PpoResult')

## PpoResult\.Real Property

Gets the array of percentage price oscillator values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the Percentage Price Oscillator at each data point\.
Values are expressed as percentages, where positive values indicate the fast MA is above
the slow MA, and negative values indicate the fast MA is below the slow MA\.