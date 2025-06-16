#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TemaResult](TemaResult.md 'TechnicalAnalysis\.Functions\.TemaResult')

## TemaResult\.Real Property

Gets the array of triple exponential moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of double values representing the Triple Exponential Moving Average at each data point\.
TEMA values are calculated using a combination of three EMAs to minimize lag while
maintaining smoothness in the indicator line\.