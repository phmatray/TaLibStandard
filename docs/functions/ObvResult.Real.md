#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[ObvResult](ObvResult.md 'TechnicalAnalysis\.Functions\.ObvResult')

## ObvResult\.Real Property

Gets the array of On Balance Volume values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of doubles representing the cumulative OBV values\. Rising OBV confirms 
an uptrend, falling OBV confirms a downtrend\. When OBV moves contrary to price, 
it may indicate a potential price reversal\.