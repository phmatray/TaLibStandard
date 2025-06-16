#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')

## BollingerBandsResult\.RealUpperBand Property

Gets the array of upper band values\.
The upper band is typically calculated as the middle band plus \(n × standard deviation\)\.
Prices near or above this band may indicate overbought conditions\.

```csharp
public double[] RealUpperBand { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')