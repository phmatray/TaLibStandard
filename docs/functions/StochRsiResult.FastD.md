#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[StochRsiResult](StochRsiResult.md 'TechnicalAnalysis\.Functions\.StochRsiResult')

## StochRsiResult\.FastD Property

Gets the array of %D values \(smoothed %K\)\.
This is typically a 3\-period moving average of %K, providing a smoother signal line\.
Values range from 0 to 100, with readings above 80 indicating overbought and below 20 indicating oversold\.

```csharp
public double[] FastD { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')