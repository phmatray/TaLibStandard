#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RsiResult](RsiResult.md 'TechnicalAnalysis\.Functions\.RsiResult')

## RsiResult\.Real Property

Gets the array of RSI values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of double values representing the Relative Strength Index at each data point\.
Values typically range from 0 to 100, where values above 70 suggest overbought conditions
and values below 30 suggest oversold conditions\.