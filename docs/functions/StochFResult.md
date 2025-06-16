#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## StochFResult Class

Represents the result of the Fast Stochastic \(StochF\) indicator calculation\.
The Fast Stochastic is a momentum indicator that provides a more responsive version of the standard Stochastic Oscillator\.

```csharp
public record StochFResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.StochFResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; StochFResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [StochFResult\(RetCode, int, int, double\[\], double\[\]\)](StochFResult.StochFResult(RetCode,int,int,double[],double[]).md 'TechnicalAnalysis\.Functions\.StochFResult\.StochFResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], double\[\]\)') | Initializes a new instance of the [StochFResult](StochFResult.md 'TechnicalAnalysis\.Functions\.StochFResult') class\. |

| Properties | |
| :--- | :--- |
| [FastD](StochFResult.FastD.md 'TechnicalAnalysis\.Functions\.StochFResult\.FastD') | Gets the array of Fast %D values \(signal line\)\. This is a moving average of the Fast %K line, used to smooth out the indicator and generate signals\. Crossovers between %K and %D can indicate potential buy or sell opportunities\. |
| [FastK](StochFResult.FastK.md 'TechnicalAnalysis\.Functions\.StochFResult\.FastK') | Gets the array of Fast %K values\. Values range from 0 to 100, calculated as: 100 × \(Close \- Lowest Low\) / \(Highest High \- Lowest Low\)\. This raw stochastic value is more sensitive to price changes than the slow version\. |
