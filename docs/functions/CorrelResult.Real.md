#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[CorrelResult](CorrelResult.md 'TechnicalAnalysis\.Functions\.CorrelResult')

## CorrelResult\.Real Property

Gets the array of correlation coefficient values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of doubles representing the correlation values, ranging from \-1 to \+1\. 
Values near \+1 indicate strong positive correlation, values near \-1 indicate 
strong negative correlation, and values near 0 indicate weak or no linear relationship\. 
These values are essential for risk management and portfolio optimization\.