#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityAtrResult](VolatilityAtrResult.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult')

## VolatilityAtrResult\.IsHighVolatility Property

Gets a value indicating whether volatility is high \(current ATR is above the average ATR\)\.

```csharp
public bool IsHighVolatility { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

### Remarks
This compares the current ATR to the average of all ATR values\.
High volatility indicates increased market activity and risk\.