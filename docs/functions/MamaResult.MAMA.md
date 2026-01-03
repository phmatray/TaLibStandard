#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')

## MamaResult\.MAMA Property

Gets the array of MESA Adaptive Moving Average \(MAMA\) values\.

```csharp
public double[] MAMA { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
MAMA adapts quickly to price changes while maintaining smoothness\.
It automatically adjusts its smoothing based on the measured cycle period,
providing faster response to market changes than traditional moving averages\.