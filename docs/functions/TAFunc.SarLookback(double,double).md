#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.SarLookback\(double, double\) Method

Returns the lookback period required for Parabolic SAR calculation\.

```csharp
public static int SarLookback(double optInAcceleration, double optInMaximum);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.SarLookback(double,double).optInAcceleration'></a>

`optInAcceleration` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Acceleration factor increment\. Must be non\-negative\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarLookback(double,double).optInMaximum'></a>

`optInMaximum` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Maximum acceleration factor\. Must be non\-negative\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
Always returns 1 if parameters are valid, or \-1 if parameters are invalid\.