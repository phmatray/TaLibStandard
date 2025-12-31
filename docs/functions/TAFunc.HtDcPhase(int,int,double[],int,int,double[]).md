#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtDcPhase\(int, int, double\[\], int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Dominant Cycle Phase\.

```csharp
public static TechnicalAnalysis.Common.RetCode HtDcPhase(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index of the output values\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of output values generated\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtDcPhase(int,int,double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array to store the calculated dominant cycle phase values in degrees\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Hilbert Transform \- Dominant Cycle Phase is part of John Ehlers' suite of cycle analysis indicators\.
This indicator measures the phase angle of the dominant market cycle at each point in time\.

Key characteristics:
\- Output values range from \-45 to 315 degrees
\- The phase advances through a full 360\-degree cycle as the dominant cycle completes
\- Rapid phase changes can indicate cycle turning points
\- Phase discontinuities \(jumps from 315 to \-45\) mark cycle completions

How it works:
1\. Applies a 4\-period weighted moving average for smoothing
2\. Uses the Hilbert Transform to decompose the signal into quadrature components
3\. Calculates the instantaneous phase from the quadrature components
4\. Applies adaptive smoothing based on the measured dominant cycle period

Common use cases:
\- Identifying market cycle turning points
\- Confirming trend changes when phase crosses certain thresholds
\- Timing entries and exits based on cycle position
\- Combining with HtDcPeriod to understand both cycle length and position

Limitations:
\- Requires significant historical data \(minimum 63 bars plus unstable period\)
\- Most effective in cyclic markets; less reliable in strong trending conditions
\- Subject to lag due to smoothing operations
\- Phase measurements can be noisy in choppy or low\-volatility markets