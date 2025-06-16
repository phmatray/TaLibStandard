#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## ObvResult Class

Represents the result of the On Balance Volume \(OBV\) indicator calculation\.

```csharp
public record ObvResult : TechnicalAnalysis.Common.IndicatorResult, System.IEquatable<TechnicalAnalysis.Functions.ObvResult>
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [TechnicalAnalysis\.Common\.IndicatorResult](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.IndicatorResult 'TechnicalAnalysis\.Common\.IndicatorResult') &#129106; ObvResult

Implements [System\.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')[ObvResult](ObvResult.md 'TechnicalAnalysis\.Functions\.ObvResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System\.IEquatable\`1')

### Remarks
OBV is a momentum indicator that uses volume flow to predict changes in stock price\. 
It maintains a running total of volume, adding volume on up days and subtracting 
volume on down days\. The theory is that volume precedes price movement, so if a 
security is seeing increasing OBV, it is a signal that volume is supporting the 
price movement\. Divergences between OBV and price can signal potential reversals\.

| Constructors | |
| :--- | :--- |
| [ObvResult\(RetCode, int, int, double\[\]\)](ObvResult.ObvResult(RetCode,int,int,double[]).md 'TechnicalAnalysis\.Functions\.ObvResult\.ObvResult\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\]\)') | Initializes a new instance of the [ObvResult](ObvResult.md 'TechnicalAnalysis\.Functions\.ObvResult') class\. |

| Properties | |
| :--- | :--- |
| [Real](ObvResult.Real.md 'TechnicalAnalysis\.Functions\.ObvResult\.Real') | Gets the array of On Balance Volume values\. |
