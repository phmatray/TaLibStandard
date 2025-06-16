#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ceil Method

| Overloads | |
| :--- | :--- |
| [Ceil\(int, int, double\[\]\)](TAMath.Ceil.md#TechnicalAnalysis.Functions.TAMath.Ceil(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ceil\(int, int, double\[\]\)') | Calculates the ceiling \(smallest integer greater than or equal to\) of each element in the input array\. |
| [Ceil\(int, int, float\[\]\)](TAMath.Ceil.md#TechnicalAnalysis.Functions.TAMath.Ceil(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ceil\(int, int, float\[\]\)') | Calculates the ceiling \(smallest integer greater than or equal to\) of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,double[])'></a>

## TAMath\.Ceil\(int, int, double\[\]\) Method

Calculates the ceiling \(smallest integer greater than or equal to\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CeilResult Ceil(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[CeilResult](CeilResult.md 'TechnicalAnalysis\.Functions\.CeilResult')  
A CeilResult containing the calculated ceiling values\.

### Remarks
This function computes the ceiling for each element in the input array\.
The ceiling function rounds each value up to the nearest integer\.
For example: ceil\(1\.1\) = 2, ceil\(\-1\.1\) = \-1, ceil\(5\.0\) = 5\.

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,float[])'></a>

## TAMath\.Ceil\(int, int, float\[\]\) Method

Calculates the ceiling \(smallest integer greater than or equal to\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CeilResult Ceil(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ceil(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[CeilResult](CeilResult.md 'TechnicalAnalysis\.Functions\.CeilResult')  
A CeilResult containing the calculated ceiling values\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.