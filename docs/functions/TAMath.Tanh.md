#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Tanh Method

| Overloads | |
| :--- | :--- |
| [Tanh\(int, int, double\[\]\)](TAMath.Tanh.md#TechnicalAnalysis.Functions.TAMath.Tanh(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Tanh\(int, int, double\[\]\)') | Calculates the hyperbolic tangent for each element in the input array\. |
| [Tanh\(int, int, float\[\]\)](TAMath.Tanh.md#TechnicalAnalysis.Functions.TAMath.Tanh(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Tanh\(int, int, float\[\]\)') | Calculates the hyperbolic tangent for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,double[])'></a>

## TAMath\.Tanh\(int, int, double\[\]\) Method

Calculates the hyperbolic tangent for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.TanhResult Tanh(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the hyperbolic tangent for\.

#### Returns
[TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult')  
A [TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult') containing the calculated hyperbolic tangent values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The hyperbolic tangent function is defined as tanh\(x\) = sinh\(x\) / cosh\(x\) = \(e^x \- e^\(\-x\)\) / \(e^x \+ e^\(\-x\)\)\.
Unlike the regular tangent function, tanh is bounded and returns values in the range \[\-1, 1\]\.
This makes it useful as a normalization function in technical analysis and is commonly used
in neural networks and other machine learning applications for trading systems\.

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,float[])'></a>

## TAMath\.Tanh\(int, int, float\[\]\) Method

Calculates the hyperbolic tangent for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.TanhResult Tanh(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tanh(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the hyperbolic tangent for\.

#### Returns
[TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult')  
A [TanhResult](TanhResult.md 'TechnicalAnalysis\.Functions\.TanhResult') containing the calculated hyperbolic tangent values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.