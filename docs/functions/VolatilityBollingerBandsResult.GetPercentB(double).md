#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')

## VolatilityBollingerBandsResult\.GetPercentB\(double\) Method

Gets the %B indicator value for the most recent price point\.

```csharp
public double GetPercentB(double currentPrice);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolatilityBollingerBandsResult.GetPercentB(double).currentPrice'></a>

`currentPrice` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The current price to evaluate\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
A value indicating where the price is relative to the bands:
\- Above 1\.0: Price is above the upper band
\- 1\.0: Price is at the upper band
\- 0\.5: Price is at the middle band
\- 0\.0: Price is at the lower band
\- Below 0\.0: Price is below the lower band

### Remarks
%B = \(Close \- Lower Band\) / \(Upper Band \- Lower Band\)
This indicator quantifies price position relative to the bands\.