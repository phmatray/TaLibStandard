#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Atan Method

| Overloads | |
| :--- | :--- |
| [Atan\(int, int, double\[\]\)](TAMath.Atan.md#TechnicalAnalysis.Functions.TAMath.Atan(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Atan\(int, int, double\[\]\)') | Calculates the arctangent \(inverse tangent\) of each element in the input array\. |
| [Atan\(int, int, float\[\]\)](TAMath.Atan.md#TechnicalAnalysis.Functions.TAMath.Atan(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Atan\(int, int, float\[\]\)') | Calculates the arctangent \(inverse tangent\) of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,double[])'></a>

## TAMath\.Atan\(int, int, double\[\]\) Method

Calculates the arctangent \(inverse tangent\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.AtanResult Atan(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[AtanResult](AtanResult.md 'TechnicalAnalysis\.Functions\.AtanResult')  
An AtanResult containing the calculated arctangent values in radians\.

### Remarks
This function computes the arctangent \(inverse tangent\) for each element in the input array\.
The input values can be any real number\.
The output values are in radians in the range \[\-π/2, π/2\]\.

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,float[])'></a>

## TAMath\.Atan\(int, int, float\[\]\) Method

Calculates the arctangent \(inverse tangent\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.AtanResult Atan(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Atan(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[AtanResult](AtanResult.md 'TechnicalAnalysis\.Functions\.AtanResult')  
An AtanResult containing the calculated arctangent values in radians\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.