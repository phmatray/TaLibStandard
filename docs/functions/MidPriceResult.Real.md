#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MidPriceResult](MidPriceResult.md 'TechnicalAnalysis\.Functions\.MidPriceResult')

## MidPriceResult\.Real Property

Gets the array of midprice values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
Each value represents the midpoint of the high\-low range over the lookback period,
calculated as \(period high \+ period low\) / 2\. This provides a smoothed representation
of the price center and can be used to identify trend direction and support/resistance levels\.