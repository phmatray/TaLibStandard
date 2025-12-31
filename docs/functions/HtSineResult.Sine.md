#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult')

## HtSineResult\.Sine Property

Gets the array of sine wave values\.
Values oscillate between \-1 and \+1, representing the smoothed cyclic component of price movement\.
Crossovers between sine and lead sine can indicate cycle turning points\.

```csharp
public double[] Sine { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')