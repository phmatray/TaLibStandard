#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[NatrResult](NatrResult.md 'TechnicalAnalysis\.Functions\.NatrResult')

## NatrResult\.Real Property

Gets the array of Normalized Average True Range values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Values are expressed as percentages of the closing price\.
Higher values indicate greater volatility relative to the price level,
while lower values suggest lower volatility\. This makes it easier to
compare volatility across different price ranges and securities\.