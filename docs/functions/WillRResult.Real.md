#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[WillRResult](WillRResult.md 'TechnicalAnalysis\.Functions\.WillRResult')

## WillRResult\.Real Property

Gets the array of Williams' %R values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
Values range from \-100 to 0, where:
\- Values from \-20 to 0 indicate overbought conditions
\- Values from \-100 to \-80 indicate oversold conditions
\- The negative scale is traditional for Williams' %R \(inverse of other oscillators\)