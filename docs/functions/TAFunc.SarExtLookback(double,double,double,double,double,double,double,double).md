#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.SarExtLookback\(double, double, double, double, double, double, double, double\) Method

Calculates the lookback period for the Extended Parabolic SAR function\.

```csharp
public static int SarExtLookback(double optInStartValue, double optInOffsetOnReverse, double optInAccelerationInitLong, double optInAccelerationLong, double optInAccelerationMaxLong, double optInAccelerationInitShort, double optInAccelerationShort, double optInAccelerationMaxShort);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInStartValue'></a>

`optInStartValue` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Initial SAR value \(ignored for lookback calculation\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInOffsetOnReverse'></a>

`optInOffsetOnReverse` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Percentage offset added when SAR reverses\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationInitLong'></a>

`optInAccelerationInitLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Initial acceleration factor for long positions\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationLong'></a>

`optInAccelerationLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Acceleration increment for long positions\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationMaxLong'></a>

`optInAccelerationMaxLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Maximum acceleration factor for long positions\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationInitShort'></a>

`optInAccelerationInitShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Initial acceleration factor for short positions\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationShort'></a>

`optInAccelerationShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Acceleration increment for short positions\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExtLookback(double,double,double,double,double,double,double,double).optInAccelerationMaxShort'></a>

`optInAccelerationMaxShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Maximum acceleration factor for short positions\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The minimum number of data points required \(1\), or \-1 for invalid parameters\.