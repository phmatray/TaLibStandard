#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[UltOscResult](UltOscResult.md 'TechnicalAnalysis\.Functions\.UltOscResult')

## UltOscResult\.Real Property

Gets the array of Ultimate Oscillator values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Values range from 0 to 100, where:
\- Values above 70 typically indicate overbought conditions
\- Values below 30 typically indicate oversold conditions
\- The indicator is less prone to false signals due to its multi\-timeframe approach