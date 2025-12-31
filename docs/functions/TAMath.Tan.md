#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Tan Method

| Overloads | |
| :--- | :--- |
| [Tan\(int, int, double\[\]\)](TAMath.Tan.md#TechnicalAnalysis.Functions.TAMath.Tan(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Tan\(int, int, double\[\]\)') | Calculates the trigonometric tangent for each element in the input array\. |
| [Tan\(int, int, float\[\]\)](TAMath.Tan.md#TechnicalAnalysis.Functions.TAMath.Tan(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Tan\(int, int, float\[\]\)') | Calculates the trigonometric tangent for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,double[])'></a>

## TAMath\.Tan\(int, int, double\[\]\) Method

Calculates the trigonometric tangent for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.TanResult Tan(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(in radians\) to calculate the tangent for\.

#### Returns
[TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult')  
A [TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult') containing the calculated tangent values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The tangent function takes input values in radians and is defined as tan\(x\) = sin\(x\) / cos\(x\)\.
The function is undefined at odd multiples of π/2 \(90°, 270°, etc\.\) where it approaches infinity\.
In technical analysis, tangent functions may be used in advanced cycle analysis and angular calculations\.
To convert degrees to radians, multiply by π/180\.

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,float[])'></a>

## TAMath\.Tan\(int, int, float\[\]\) Method

Calculates the trigonometric tangent for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.TanResult Tan(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Tan(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values \(in radians\) to calculate the tangent for\.

#### Returns
[TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult')  
A [TanResult](TanResult.md 'TechnicalAnalysis\.Functions\.TanResult') containing the calculated tangent values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.