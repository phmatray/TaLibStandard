#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')

## T3Result\.Real Property

Gets the array of T3 moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of double values representing the T3 Moving Average at each data point\.
The T3 uses a volume factor to control the amount of smoothing, providing
an excellent balance between smoothness and responsiveness\.