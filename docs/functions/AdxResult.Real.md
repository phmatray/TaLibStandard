#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AdxResult](AdxResult.md 'TechnicalAnalysis\.Functions\.AdxResult')

## AdxResult\.Real Property

Gets the array of calculated ADX values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
ADX values range from 0 to 100, where:
\- Values below 20 indicate a weak trend
\- Values between 20\-25 indicate the beginning of a trend
\- Values above 25 indicate a strong trend
\- Values above 40 indicate a very strong trend