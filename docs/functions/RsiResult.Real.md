#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')

## RsiResult\.Real Property

Gets the array of RSI values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the Relative Strength Index at each data point\.
Values typically range from 0 to 100, where values above 70 suggest overbought conditions
and values below 30 suggest oversold conditions\.