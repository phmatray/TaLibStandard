#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')

## MamaResult\.FAMA Property

Gets the array of Following Adaptive Moving Average \(FAMA\) values\.

```csharp
public double[] FAMA { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
FAMA is a slower\-moving average that follows MAMA\. The relationship between
MAMA and FAMA can be used to generate trading signals:
\- When MAMA crosses above FAMA, it may signal a buy opportunity
\- When MAMA crosses below FAMA, it may signal a sell opportunity