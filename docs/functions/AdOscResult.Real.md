#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')

## AdOscResult\.Real Property

Gets the array of Chaikin A/D Oscillator values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the oscillator values\. Positive values suggest 
increasing buying pressure \(bullish momentum\), negative values suggest increasing 
selling pressure \(bearish momentum\), and crossovers through zero may indicate 
potential trend changes\.