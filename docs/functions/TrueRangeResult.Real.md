#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult')

## TrueRangeResult\.Real Property

Gets the array of True Range values\.
Each value represents the greatest of: \(High \- Low\), \|High \- Previous Close\|, or \|Low \- Previous Close\|\.
This captures volatility including gaps between trading sessions\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')