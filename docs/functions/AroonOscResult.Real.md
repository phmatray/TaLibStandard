#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AroonOscResult](AroonOscResult.md 'TechnicalAnalysis\.Functions\.AroonOscResult')

## AroonOscResult\.Real Property

Gets the array of Aroon Oscillator values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')  
An array of doubles representing the oscillator values, ranging from \-100 to \+100\. 
Positive values indicate upward trend strength, negative values indicate downward 
trend strength, and values near zero suggest no clear trend\. The magnitude indicates 
trend strength, with values above \+50 or below \-50 indicating strong trends\.