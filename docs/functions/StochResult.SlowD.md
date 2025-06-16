#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')

## StochResult\.SlowD Property

Gets the array of Slow %D values \(signal line\)\.
This is a moving average of the Slow %K line, typically used to generate trading signals\.
Buy signals often occur when %K crosses above %D, and sell signals when %K crosses below %D\.

```csharp
public double[] SlowD { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')