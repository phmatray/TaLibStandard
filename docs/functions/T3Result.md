#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## T3Result Class

Represents the result of calculating the T3 Moving Average indicator\.

```csharp
public record T3Result : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.T3Result>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; T3Result

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
T3 is a smoothed moving average developed by Tim Tillson\. It incorporates multiple
exponential smoothing techniques to produce a moving average that is both smooth
and responsive, with minimal lag compared to traditional moving averages\.

| Constructors | |
| :--- | :--- |
| [T3Result\(RetCode, int, int, double\[\]\)](T3Result.T3Result(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.T3Result\.T3Result\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result') class\. |

| Properties | |
| :--- | :--- |
| [Real](T3Result.Real.md 'TechnicalAnalysis\.Functions\.T3Result\.Real') | Gets the array of T3 moving average values\. |
