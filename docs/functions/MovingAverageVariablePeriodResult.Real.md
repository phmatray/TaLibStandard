#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')

## MovingAverageVariablePeriodResult\.Real Property

Gets the array of variable period moving average values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
Each value is calculated using a different period based on the input period array\.
This adaptive approach allows the indicator to:
\- Respond quickly during volatile periods \(shorter periods\)
\- Smooth more during stable periods \(longer periods\)
\- Adjust to changing market conditions automatically