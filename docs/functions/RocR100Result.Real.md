#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result')

## RocR100Result\.Real Property

Gets the array of Rate of Change Ratio 100 scale values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

### Remarks
Values oscillate around 100:
\- Values above 100 indicate the current price is higher than n periods ago
\- Values below 100 indicate the current price is lower than n periods ago
\- A value of 100 indicates no change in price
\- For example, a value of 110 means the price has increased by 10%