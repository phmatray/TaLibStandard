#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sin Method

| Overloads | |
| :--- | :--- |
| [Sin\(int, int, double\[\]\)](TAMath.Sin.md#TechnicalAnalysis.Functions.TAMath.Sin(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sin\(int, int, double\[\]\)') | Calculates the trigonometric sine for each element in the input array\. |
| [Sin\(int, int, float\[\]\)](TAMath.Sin.md#TechnicalAnalysis.Functions.TAMath.Sin(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sin\(int, int, float\[\]\)') | Calculates the trigonometric sine for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,double[])'></a>

## TAMath\.Sin\(int, int, double\[\]\) Method

Calculates the trigonometric sine for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SinResult Sin(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(in radians\) to calculate the sine for\.

#### Returns
[SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult')  
A [SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult') containing the calculated sine values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The sine function takes input values in radians and returns values in the range \[\-1, 1\]\.
In technical analysis, trigonometric functions are often used in cycle analysis and
for generating oscillating indicators\. To convert degrees to radians, multiply by π/180\.

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,float[])'></a>

## TAMath\.Sin\(int, int, float\[\]\) Method

Calculates the trigonometric sine for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SinResult Sin(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sin(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values \(in radians\) to calculate the sine for\.

#### Returns
[SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult')  
A [SinResult](SinResult.md 'TechnicalAnalysis\.Functions\.SinResult') containing the calculated sine values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.