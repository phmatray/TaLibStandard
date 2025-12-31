#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## AdOscResult Class

Represents the result of the Chaikin Accumulation/Distribution Oscillator \(A/D Oscillator\) calculation\.

```csharp
public record AdOscResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.AdOscResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.indicatorresult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; AdOscResult

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

### Remarks
The Chaikin A/D Oscillator is a momentum indicator that measures the difference between 
fast and slow exponential moving averages of the Accumulation/Distribution Line\. 
It helps identify changes in the momentum of accumulation or distribution, providing 
early signals of potential trend changes\. Positive values indicate bullish momentum, 
while negative values indicate bearish momentum\.

| Constructors | |
| :--- | :--- |
| [AdOscResult\(RetCode, int, int, double\[\]\)](AdOscResult.AdOscResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.AdOscResult\.AdOscResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](AdOscResult.Real.md 'TechnicalAnalysis\.Functions\.AdOscResult\.Real') | Gets the array of Chaikin A/D Oscillator values\. |
