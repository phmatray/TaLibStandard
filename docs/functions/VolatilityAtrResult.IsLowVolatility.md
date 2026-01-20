#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityAtrResult](VolatilityAtrResult.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult')

## VolatilityAtrResult\.IsLowVolatility Property

Gets a value indicating whether volatility is low \(current ATR is below the average ATR\)\.

```csharp
public bool IsLowVolatility { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

### Remarks
This compares the current ATR to the average of all ATR values\.
Low volatility may precede significant price movements\.