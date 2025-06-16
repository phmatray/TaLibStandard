#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')

## AroonResult\.AroonDown Property

Gets the array of Aroon Down values\.

```csharp
public double[] AroonDown { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the Aroon Down line, ranging from 0 to 100\. 
High values \(70\-100\) indicate that a low was recently reached and a downtrend 
may be in place\. Low values \(0\-30\) indicate that it has been a long time since 
a low was reached\.