#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Exp Method

| Overloads | |
| :--- | :--- |
| [Exp\(int, int, double\[\]\)](TAMath.Exp.md#TechnicalAnalysis.Functions.TAMath.Exp(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Exp\(int, int, double\[\]\)') | Calculates the exponential \(e raised to the power\) of each element in the input array\. |
| [Exp\(int, int, float\[\]\)](TAMath.Exp.md#TechnicalAnalysis.Functions.TAMath.Exp(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Exp\(int, int, float\[\]\)') | Calculates the exponential \(e raised to the power\) of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,double[])'></a>

## TAMath\.Exp\(int, int, double\[\]\) Method

Calculates the exponential \(e raised to the power\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.ExpResult Exp(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values\.

#### Returns
[ExpResult](ExpResult.md 'TechnicalAnalysis\.Functions\.ExpResult')  
An ExpResult containing the calculated exponential values\.

### Remarks
This function computes e^x for each element x in the input array, where e is Euler's number \(approximately 2\.71828\)\.
The exponential function is the inverse of the natural logarithm\.
Large positive input values may result in overflow, while large negative values approach zero\.

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,float[])'></a>

## TAMath\.Exp\(int, int, float\[\]\) Method

Calculates the exponential \(e raised to the power\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.ExpResult Exp(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Exp(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values\.

#### Returns
[ExpResult](ExpResult.md 'TechnicalAnalysis\.Functions\.ExpResult')  
An ExpResult containing the calculated exponential values\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.