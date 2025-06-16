#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sqrt Method

| Overloads | |
| :--- | :--- |
| [Sqrt\(int, int, double\[\]\)](TAMath.Sqrt.md#TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sqrt\(int, int, double\[\]\)') | Calculates the square root for each element in the input array\. |
| [Sqrt\(int, int, float\[\]\)](TAMath.Sqrt.md#TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sqrt\(int, int, float\[\]\)') | Calculates the square root for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,double[])'></a>

## TAMath\.Sqrt\(int, int, double\[\]\) Method

Calculates the square root for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SqrtResult Sqrt(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the square root for\.

#### Returns
[SqrtResult](SqrtResult.md 'TechnicalAnalysis\.Functions\.SqrtResult')  
A [SqrtResult](SqrtResult.md 'TechnicalAnalysis\.Functions\.SqrtResult') containing the calculated square root values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The square root function returns the positive square root of each input value\.
This function is undefined for negative values, which will result in NaN\.
In technical analysis, square roots are commonly used in volatility calculations,
such as in the calculation of standard deviation and related indicators\.

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,float[])'></a>

## TAMath\.Sqrt\(int, int, float\[\]\) Method

Calculates the square root for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SqrtResult Sqrt(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sqrt(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the square root for\.

#### Returns
[SqrtResult](SqrtResult.md 'TechnicalAnalysis\.Functions\.SqrtResult')  
A [SqrtResult](SqrtResult.md 'TechnicalAnalysis\.Functions\.SqrtResult') containing the calculated square root values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.