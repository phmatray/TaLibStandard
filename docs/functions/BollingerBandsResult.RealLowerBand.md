#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[BollingerBandsResult](BollingerBandsResult.md 'TechnicalAnalysis\.Functions\.BollingerBandsResult')

## BollingerBandsResult\.RealLowerBand Property

Gets the array of lower band values\.
The lower band is typically calculated as the middle band minus \(n × standard deviation\)\.
Prices near or below this band may indicate oversold conditions\.

```csharp
public double[] RealLowerBand { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')