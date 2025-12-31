#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## StochResult Class

Represents the result of the Stochastic Oscillator \(Stoch\) indicator calculation\.
The Stochastic Oscillator is a momentum indicator that shows the location of the close relative to the high\-low range over a set number of periods\.

```csharp
public record StochResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.StochResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; StochResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [StochResult\(RetCode, int, int, double\[\], double\[\]\)](StochResult.StochResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.StochResult\.StochResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [StochResult](StochResult.md 'TechnicalAnalysis\.Functions\.StochResult') class\. |

| Properties | |
| :--- | :--- |
| [SlowD](StochResult.SlowD.md 'TechnicalAnalysis\.Functions\.StochResult\.SlowD') | Gets the array of Slow %D values \(signal line\)\. This is a moving average of the Slow %K line, typically used to generate trading signals\. Buy signals often occur when %K crosses above %D, and sell signals when %K crosses below %D\. |
| [SlowK](StochResult.SlowK.md 'TechnicalAnalysis\.Functions\.StochResult\.SlowK') | Gets the array of Slow %K values\. Values range from 0 to 100\. Readings above 80 indicate overbought conditions, while readings below 20 indicate oversold conditions\. The Slow %K is a smoothed version of the Fast %K, reducing false signals\. |
