#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult')

## TypPriceResult\.Real Property

Gets the array of typical price values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the typical price for each period, calculated as 
the average of high, low, and close prices\. This provides a balanced representation 
of each period's trading activity and is commonly used as input for volume\-weighted 
indicators and pivot point calculations\.