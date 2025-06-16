#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## LinearRegAngleResult Class

Represents the result of the Linear Regression Angle \(LINEARREG\_ANGLE\) calculation\.
This indicator calculates the angle of the linear regression line in degrees, providing insight
into the strength and direction of the trend over a specified period\.

```csharp
public record LinearRegAngleResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.LinearRegAngleResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; LinearRegAngleResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[LinearRegAngleResult](LinearRegAngleResult.md 'TechnicalAnalysis\.Functions\.LinearRegAngleResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [LinearRegAngleResult\(RetCode, int, int, double\[\]\)](LinearRegAngleResult.LinearRegAngleResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.LinearRegAngleResult\.LinearRegAngleResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [LinearRegAngleResult](LinearRegAngleResult.md 'TechnicalAnalysis\.Functions\.LinearRegAngleResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](LinearRegAngleResult.Real.md 'TechnicalAnalysis\.Functions\.LinearRegAngleResult\.Real') | Gets the array of linear regression angle values in degrees\. Positive angles indicate an upward trend, negative angles indicate a downward trend\. The magnitude of the angle reflects the steepness of the trend\. |
