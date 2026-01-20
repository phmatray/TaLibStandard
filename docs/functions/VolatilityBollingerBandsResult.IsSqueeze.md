#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')

## VolatilityBollingerBandsResult\.IsSqueeze Property

Gets a value indicating whether the bands are contracting \(Bollinger Squeeze\)\.

```csharp
public bool IsSqueeze { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

### Remarks
Compares current band width to the average band width\.
A Bollinger Squeeze \(narrow bands\) often precedes significant price movements\.