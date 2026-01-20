#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[MathHelper](MathHelper.md 'TechnicalAnalysis\.Common\.MathHelper')

## MathHelper\.ApplyMathFunction\(int, int, double\[\], int, int, double\[\], Func\<double,double\>\) Method

Applies a mathematical function element\-wise to an input array\.

```csharp
public static TechnicalAnalysis.Common.RetCode ApplyMathFunction(int startIdx, int endIdx, in double[] inReal, ref int outBegIdx, ref int outNBElement, ref double[] outReal, Func<double,double> mathFunction);
```
#### Parameters

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of values\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).outNBElement'></a>

`outNBElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for the transformed values\.

<a name='TechnicalAnalysis.Common.MathHelper.ApplyMathFunction(int,int,double[],int,int,double[],Func_double,double_).mathFunction'></a>

`mathFunction` [System\.Func](https://learn.microsoft.com/en-us/dotnet/api/system.func 'System\.Func')

The mathematical function to apply to each element\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if the calculation succeeds;
             appropriate error code otherwise\.

### Remarks
This method provides a generic template for mathematical transformation indicators
that don't require historical data \(lookback period = 0\)\. It handles:
\- Index range validation
\- Array null checking
\- Element\-wise function application
\- Output parameter setup

Example usage:

```csharp
public static RetCode Sin(...) =>
    MathHelper.ApplyMathFunction(startIdx, endIdx, inReal,
        ref outBegIdx, ref outNBElement, ref outReal, Math.Sin);
```

This pattern reduces code duplication across 15\+ mathematical function indicators\.