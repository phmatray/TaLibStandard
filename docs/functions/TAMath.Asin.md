#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Asin Method

| Overloads | |
| :--- | :--- |
| [Asin\(int, int, double\[\]\)](TAMath.Asin.md#TechnicalAnalysis.Functions.TAMath.Asin(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Asin\(int, int, double\[\]\)') | Calculates the arcsine \(inverse sine\) of each element in the input array\. |
| [Asin\(int, int, float\[\]\)](TAMath.Asin.md#TechnicalAnalysis.Functions.TAMath.Asin(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Asin\(int, int, float\[\]\)') | Calculates the arcsine \(inverse sine\) of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,double[])'></a>

## TAMath\.Asin\(int, int, double\[\]\) Method

Calculates the arcsine \(inverse sine\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.AsinResult Asin(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[AsinResult](AsinResult.md 'TechnicalAnalysis\.Functions\.AsinResult')  
An AsinResult containing the calculated arcsine values in radians\.

### Remarks
This function computes the arcsine \(inverse sine\) for each element in the input array\.
The input values must be in the range \[\-1, 1\], otherwise the result will be NaN\.
The output values are in radians in the range \[\-π/2, π/2\]\.

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,float[])'></a>

## TAMath\.Asin\(int, int, float\[\]\) Method

Calculates the arcsine \(inverse sine\) of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.AsinResult Asin(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Asin(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input array of values\.

#### Returns
[AsinResult](AsinResult.md 'TechnicalAnalysis\.Functions\.AsinResult')  
An AsinResult containing the calculated arcsine values in radians\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.