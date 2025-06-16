#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult')

## AvgPriceResult\.Real Property

Gets the array of average price values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the average price for each period, calculated as 
the mean of open, high, low, and close prices\. This smoothed price series can be 
used as input for other indicators or as a reference for support and resistance levels\.