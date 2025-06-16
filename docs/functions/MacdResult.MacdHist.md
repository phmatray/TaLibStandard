#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MacdResult](MacdResult.md 'TechnicalAnalysis\.Functions\.MacdResult')

## MacdResult\.MacdHist Property

Gets the array of MACD histogram values\.

```csharp
public double[] MacdHist { get; }
```

#### Property Value
[System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')  
An array of double values representing the MACD histogram, calculated as the difference
between the MACD line and the signal line\. Positive values indicate bullish momentum,
while negative values indicate bearish momentum\.