#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[SarResult](SarResult.md 'TechnicalAnalysis\.Functions\.SarResult')

## SarResult\.Real Property

Gets the array of Parabolic SAR values\.
Each value represents a stop\-loss level that trails the price\. When price is above SAR,
the trend is bullish; when below, it's bearish\. SAR flips sides when price crosses it\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')