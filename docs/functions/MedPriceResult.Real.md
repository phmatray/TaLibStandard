#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult')

## MedPriceResult\.Real Property

Gets the array of median price values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of doubles representing the median price for each period, calculated as 
the average of high and low prices\. This provides the midpoint of each period's 
trading range and can be used as a baseline for trend analysis or as input to 
other technical indicators\.