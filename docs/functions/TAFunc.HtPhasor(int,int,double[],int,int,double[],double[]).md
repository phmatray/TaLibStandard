#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtPhasor\(int, int, double\[\], int, int, double\[\], double\[\]\) Method

Calculates the Hilbert Transform \- Phasor Components\.

```csharp
public static TechnicalAnalysis.Common.RetCode HtPhasor(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outInPhase, ref double[] outQuadrature);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).outInPhase'></a>

`outInPhase` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the In\-Phase component values\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtPhasor(int,int,double[],int,int,double[],double[]).outQuadrature'></a>

`outQuadrature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Quadrature component values\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Hilbert Transform \- Phasor Components indicator decomposes price data into two 
perpendicular components: In\-Phase \(I\) and Quadrature \(Q\)\. These components represent 
the real and imaginary parts of the analytic signal derived from the price series\.

How it works:
\- Uses the Hilbert Transform to convert real\-valued price data into complex\-valued analytic signals
\- The In\-Phase component represents the original detrended price
\- The Quadrature component is 90 degrees out of phase with the In\-Phase component
\- Together, these components can be used to determine the instantaneous phase and amplitude

What it measures:
\- The cyclical nature of price movements
\- The current position within a price cycle
\- The dominant cycle period in the price data

How to interpret:
\- The relationship between In\-Phase and Quadrature indicates the current phase angle
\- Phase angle = arctan\(Q/I\), which shows position within the current cycle
\- Can be used to identify cycle turning points when phase angle changes rapidly
\- The magnitude sqrt\(I² \+ Q²\) represents the cycle amplitude

Common use cases:
\- Identifying market cycles and their turning points
\- Determining the dominant cycle period
\- Generating trading signals based on phase transitions
\- Used as input for other Hilbert Transform indicators \(HT\_SINE, HT\_TRENDMODE\)

Limitations and considerations:
\- Requires sufficient historical data \(minimum 32 bars \+ unstable period\)
\- Works best with cyclic market behavior
\- May produce false signals in strongly trending markets
\- The indicator has an unstable period during which values may be unreliable
\- Not suitable for markets with irregular or non\-cyclic price movements