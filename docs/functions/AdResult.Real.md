#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AdResult](AdResult.md 'TechnicalAnalysis\.Functions\.AdResult')

## AdResult\.Real Property

Gets the array of Accumulation/Distribution Line values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of doubles representing the cumulative A/D Line values, where each value 
indicates the running total of money flow volume\. Positive trends suggest buying 
pressure, while negative trends suggest selling pressure\.