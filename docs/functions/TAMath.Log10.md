#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Log10 Method

| Overloads | |
| :--- | :--- |
| [Log10\(int, int, double\[\]\)](TAMath.Log10.md#TechnicalAnalysis.Functions.TAMath.Log10(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Log10\(int, int, double\[\]\)') | Calculates the base\-10 logarithm for each element in the input array\. |
| [Log10\(int, int, float\[\]\)](TAMath.Log10.md#TechnicalAnalysis.Functions.TAMath.Log10(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Log10\(int, int, float\[\]\)') | Calculates the base\-10 logarithm for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,double[])'></a>

## TAMath\.Log10\(int, int, double\[\]\) Method

Calculates the base\-10 logarithm for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.Log10Result Log10(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values to calculate the base\-10 logarithm for\.

#### Returns
[Log10Result](Log10Result.md 'TechnicalAnalysis\.Functions\.Log10Result')  
A [Log10Result](Log10Result.md 'TechnicalAnalysis\.Functions\.Log10Result') containing the calculated base\-10 logarithm values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The base\-10 logarithm \(common logarithm\) is frequently used in finance and technical analysis
for scaling data and analyzing order of magnitude changes\. For example, log10\(100\) = 2 and log10\(1000\) = 3\.
This function is undefined for negative values and zero, which may result in NaN or negative infinity\.

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,float[])'></a>

## TAMath\.Log10\(int, int, float\[\]\) Method

Calculates the base\-10 logarithm for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.Log10Result Log10(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Log10(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values to calculate the base\-10 logarithm for\.

#### Returns
[Log10Result](Log10Result.md 'TechnicalAnalysis\.Functions\.Log10Result')  
A [Log10Result](Log10Result.md 'TechnicalAnalysis\.Functions\.Log10Result') containing the calculated base\-10 logarithm values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.