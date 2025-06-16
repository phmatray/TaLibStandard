#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sinh Method

| Overloads | |
| :--- | :--- |
| [Sinh\(int, int, double\[\]\)](TAMath.Sinh.md#TechnicalAnalysis.Functions.TAMath.Sinh(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sinh\(int, int, double\[\]\)') | Calculates the hyperbolic sine for each element in the input array\. |
| [Sinh\(int, int, float\[\]\)](TAMath.Sinh.md#TechnicalAnalysis.Functions.TAMath.Sinh(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sinh\(int, int, float\[\]\)') | Calculates the hyperbolic sine for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,double[])'></a>

## TAMath\.Sinh\(int, int, double\[\]\) Method

Calculates the hyperbolic sine for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SinhResult Sinh(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the hyperbolic sine for\.

#### Returns
[SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult')  
A [SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult') containing the calculated hyperbolic sine values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The hyperbolic sine function is defined as sinh\(x\) = \(e^x \- e^\(\-x\)\) / 2\.
Unlike the regular sine function, sinh is not bounded and can produce values ranging from
negative infinity to positive infinity\. In technical analysis, hyperbolic functions are
sometimes used in advanced mathematical models and transformations\.

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,float[])'></a>

## TAMath\.Sinh\(int, int, float\[\]\) Method

Calculates the hyperbolic sine for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.SinhResult Sinh(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Sinh(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the hyperbolic sine for\.

#### Returns
[SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult')  
A [SinhResult](SinhResult.md 'TechnicalAnalysis\.Functions\.SinhResult') containing the calculated hyperbolic sine values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.