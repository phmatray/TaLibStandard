#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')

## VolatilityBollingerBandsResult\.BandWidth Property

Gets the current band width as a percentage of the middle band\.

```csharp
public double BandWidth { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

### Remarks
Band width = \(Upper Band \- Lower Band\) / Middle Band × 100
Lower values indicate band contraction \(low volatility\)\.
Higher values indicate band expansion \(high volatility\)\.