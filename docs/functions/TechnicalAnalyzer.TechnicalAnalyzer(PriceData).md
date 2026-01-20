#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TechnicalAnalyzer](TechnicalAnalyzer.md 'TechnicalAnalysis\.Functions\.TechnicalAnalyzer')

## TechnicalAnalyzer\(PriceData\) Constructor

Initializes a new instance of the TechnicalAnalyzer class\.

```csharp
public TechnicalAnalyzer(TechnicalAnalysis.Functions.PriceData priceData);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TechnicalAnalyzer.TechnicalAnalyzer(TechnicalAnalysis.Functions.PriceData).priceData'></a>

`priceData` [PriceData](PriceData.md 'TechnicalAnalysis\.Functions\.PriceData')

The price data to analyze\.

### Remarks
The price data should contain sufficient historical data points for the indicators
you plan to calculate\. Most indicators require a minimum number of periods before
they can produce meaningful results\.