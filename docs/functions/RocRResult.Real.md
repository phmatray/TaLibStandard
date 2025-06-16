#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')

## RocRResult\.Real Property

Gets the array of Rate of Change Ratio values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
Values represent the ratio of current price to past price:
\- Values above 1\.0 indicate the current price is higher than n periods ago
\- Values below 1\.0 indicate the current price is lower than n periods ago
\- A value of 1\.0 indicates no change in price
\- The further from 1\.0, the greater the momentum