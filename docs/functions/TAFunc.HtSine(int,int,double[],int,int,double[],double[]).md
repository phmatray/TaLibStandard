#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.HtSine\(int, int, double\[\], int, int, double\[\], double\[\]\) Method

Calculates the Hilbert Transform \- Sine Wave indicator\.

```csharp
public static TechnicalAnalysis.Common.RetCode HtSine(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outSine, ref double[] outLeadSine);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).outSine'></a>

`outSine` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Sine Wave values\.

<a name='TechnicalAnalysis.Functions.TAFunc.HtSine(int,int,double[],int,int,double[],double[]).outLeadSine'></a>

`outLeadSine` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the Lead Sine Wave values \(45 degrees phase lead\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The Hilbert Transform \- Sine Wave indicator was developed by John Ehlers and uses digital signal 
processing techniques to measure market cycles\. It generates two outputs:

1\. Sine Wave: Oscillates between \-1 and \+1, representing the current phase of the detected cycle
2\. Lead Sine: A sine wave with a 45\-degree phase lead, used for early cycle detection

How it works:
\- Applies the Hilbert Transform to decompose price into cycle components
\- Calculates the dominant cycle period using phase accumulation
\- Generates sine waves based on the instantaneous phase
\- The crossing of Sine and Lead Sine indicates cycle turning points

Interpretation:
\- When Sine crosses above Lead Sine: Potential cycle bottom \(buy signal\)
\- When Sine crosses below Lead Sine: Potential cycle top \(sell signal\)
\- Indicator works best in cycling \(ranging\) markets
\- May produce false signals in strongly trending markets

Common use cases:
\- Identifying market cycles and their turning points
\- Distinguishing between trending and cycling market conditions
\- Timing entries and exits in range\-bound markets
\- Confirming other oscillator signals

Limitations:
\- Requires significant historical data \(lookback period of 63\+ bars\)
\- Less effective in strongly trending markets
\- Subject to whipsaws during transitions between trends and cycles
\- Best used in conjunction with trend indicators for filtering

The indicator uses advanced mathematics including:
\- Weighted Moving Average \(WMA\) for smoothing
\- Hilbert Transform for cycle decomposition
\- Phase accumulation for period detection
\- Trigonometric calculations for sine wave generation