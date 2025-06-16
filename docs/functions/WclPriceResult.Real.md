#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult')

## WclPriceResult\.Real Property

Gets the array of weighted close price values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the weighted close price for each period, 
calculated with double weight on the closing price\. This emphasizes the importance 
of the closing price while still considering the full trading range, making it 
useful for trend analysis and momentum studies\.