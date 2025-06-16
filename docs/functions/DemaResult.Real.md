#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[DemaResult](DemaResult.md 'TechnicalAnalysis\.Functions\.DemaResult')

## DemaResult\.Real Property

Gets the array of double exponential moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of double values representing the Double Exponential Moving Average at each data point\.
DEMA values are calculated as: 2 \* EMA \- EMA\(EMA\), which reduces the lag inherent in
traditional moving averages\.