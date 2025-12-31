#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')

## StochResult\.SlowK Property

Gets the array of Slow %K values\.
Values range from 0 to 100\. Readings above 80 indicate overbought conditions, while readings below 20 indicate oversold conditions\.
The Slow %K is a smoothed version of the Fast %K, reducing false signals\.

```csharp
public double[] SlowK { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')