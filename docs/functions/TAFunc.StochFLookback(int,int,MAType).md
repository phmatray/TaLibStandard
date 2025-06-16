#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.StochFLookback\(int, int, MAType\) Method

Calculates the lookback period for the Fast Stochastic Oscillator function\.

```csharp
public static int StochFLookback(int optInFastKPeriod, int optInFastDPeriod, TechnicalAnalysis.Common.MAType optInFastDMAType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.StochFLookback(int,int,TechnicalAnalysis.Common.MAType).optInFastKPeriod'></a>

`optInFastKPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for Fast %K calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochFLookback(int,int,TechnicalAnalysis.Common.MAType).optInFastDPeriod'></a>

`optInFastDPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

Number of periods for Fast %D calculation\.

<a name='TechnicalAnalysis.Functions.TAFunc.StochFLookback(int,int,TechnicalAnalysis.Common.MAType).optInFastDMAType'></a>

`optInFastDMAType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

Moving average type for Fast %D calculation\.

#### Returns
[System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')  
The minimum number of data points required, or \-1 for invalid parameters\.