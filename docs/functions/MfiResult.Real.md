#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MfiResult](MfiResult.md 'TechnicalAnalysis\.Functions\.MfiResult')

## MfiResult\.Real Property

Gets the array of Money Flow Index values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the MFI values, ranging from 0 to 100\. 
Values above 80 suggest overbought conditions and potential selling opportunities, 
values below 20 suggest oversold conditions and potential buying opportunities\. 
Divergences between MFI and price action can signal potential trend reversals\.