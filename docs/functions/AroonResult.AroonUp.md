#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[AroonResult](AroonResult.md 'TechnicalAnalysis\.Functions\.AroonResult')

## AroonResult\.AroonUp Property

Gets the array of Aroon Up values\.

```csharp
public double[] AroonUp { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of doubles representing the Aroon Up line, ranging from 0 to 100\. 
High values \(70\-100\) indicate that a high was recently reached and an uptrend 
may be in place\. Low values \(0\-30\) indicate that it has been a long time since 
a high was reached\.