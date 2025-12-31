#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Cos Method

| Overloads | |
| :--- | :--- |
| [Cos\(int, int, double\[\]\)](TAMath.Cos.md#TechnicalAnalysis.Functions.TAMath.Cos(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Cos\(int, int, double\[\]\)') | Calculates the trigonometric cosine of each element in the input array\. |
| [Cos\(int, int, float\[\]\)](TAMath.Cos.md#TechnicalAnalysis.Functions.TAMath.Cos(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Cos\(int, int, float\[\]\)') | Calculates the trigonometric cosine of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,double[])'></a>

## TAMath\.Cos\(int, int, double\[\]\) Method

Calculates the trigonometric cosine of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CosResult Cos(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values in radians\.

#### Returns
[CosResult](CosResult.md 'TechnicalAnalysis\.Functions\.CosResult')  
A CosResult containing the calculated cosine values\.

### Remarks
This function computes the cosine for each element in the input array\.
The input values are expected to be in radians\.
The output values will be in the range \[\-1, 1\]\.

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,float[])'></a>

## TAMath\.Cos\(int, int, float\[\]\) Method

Calculates the trigonometric cosine of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CosResult Cos(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cos(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values in radians\.

#### Returns
[CosResult](CosResult.md 'TechnicalAnalysis\.Functions\.CosResult')  
A CosResult containing the calculated cosine values\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.