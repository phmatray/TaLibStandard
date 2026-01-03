#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.Tanh\(int, int, double\[\], int, int, double\[\]\) Method

Calculates the hyperbolic tangent of input values\.

```csharp
public static TechnicalAnalysis.Common.RetCode Tanh(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of values\.

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.Tanh(int,int,double[],int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array containing the hyperbolic tangent of each input value\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
The hyperbolic tangent function is defined as:
tanh\(x\) = sinh\(x\) / cosh\(x\) = \(e^x \- e^\(\-x\)\) / \(e^x \+ e^\(\-x\)\)

Mathematical properties:
\- Input domain: All real numbers
\- Output range: \(\-1, 1\)
\- tanh\(0\) = 0
\- tanh\(\-x\) = \-tanh\(x\) \(odd function\)
\- As x → ∞, tanh\(x\) → 1
\- As x → \-∞, tanh\(x\) → \-1

Common uses in technical analysis:
\- Normalizing unbounded indicators to \[\-1, 1\] range
\- Creating sigmoid\-like transformations
\- Neural network activation functions in AI\-based trading
\- Smoothing extreme values while preserving direction
\- Alternative to RSI\-style normalization

The S\-shaped curve of tanh makes it useful for creating bounded
oscillators from unbounded indicators\.