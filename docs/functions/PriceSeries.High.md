#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.High Property

Gets the high prices\.

```csharp
public System.ReadOnlySpan<double> High { get; }
```

#### Property Value
[System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')  
A read\-only span of exactly [BarCount](PriceSeries.BarCount.md 'TechnicalAnalysis\.Functions\.PriceSeries\.BarCount') elements indexed by BAR index\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The series carries no high prices; see [HasHighLow](PriceSeries.HasHighLow.md 'TechnicalAnalysis\.Functions\.PriceSeries\.HasHighLow')\.