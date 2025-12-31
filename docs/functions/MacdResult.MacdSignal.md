#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')

## MacdResult\.MacdSignal Property

Gets the array of signal line values\.

```csharp
public double[] MacdSignal { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the signal line, which is typically a 9\-period
EMA of the MACD line\. Crossovers between the MACD line and signal line often
indicate potential buy or sell signals\.