#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Asin\(int, int, double\[\], int, int, double\[\]\) Method

Calculates the arc sine \(inverse sine\) of input values\.

```csharp
public static TechnicalAnalysis.Common.RetCode Asin(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of values\. Values must be in the range \[\-1, 1\]\.

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Asin(int,int,double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array containing the arc sine values in radians\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The arc sine function returns the angle whose sine is the input value\.

Mathematical properties:
\- Input domain: \[\-1, 1\]
\- Output range: \[\-π/2, π/2\] radians or \[\-90°, 90°\]
\- asin\(0\) = 0
\- asin\(1\) = π/2
\- asin\(\-1\) = \-π/2

Common uses in trading:
\- Cycle analysis and phase calculations
\- Advanced harmonic pattern recognition
\- Signal processing and frequency analysis
\- Converting normalized oscillator values to angular measurements

Note: Input values outside \[\-1, 1\] will result in NaN \(Not a Number\)\.