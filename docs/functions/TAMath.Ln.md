#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ln Method

| Overloads | |
| :--- | :--- |
| [Ln\(int, int, double\[\]\)](TAMath.Ln.md#TechnicalAnalysis.Functions.TAMath.Ln(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ln\(int, int, double\[\]\)') | Calculates the natural logarithm \(base e\) for each element in the input array\. |
| [Ln\(int, int, float\[\]\)](TAMath.Ln.md#TechnicalAnalysis.Functions.TAMath.Ln(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ln\(int, int, float\[\]\)') | Calculates the natural logarithm \(base e\) for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,double[])'></a>

## TAMath\.Ln\(int, int, double\[\]\) Method

Calculates the natural logarithm \(base e\) for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.LnResult Ln(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values to calculate the natural logarithm for\.

#### Returns
[LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult')  
A [LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult') containing the calculated natural logarithm values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The natural logarithm is the logarithm to the base e \(approximately 2\.71828\)\.
This function is undefined for negative values and zero, which may result in NaN or negative infinity\.
In technical analysis, logarithmic transformations are often used to normalize data or analyze
percentage changes in price movements\.

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,float[])'></a>

## TAMath\.Ln\(int, int, float\[\]\) Method

Calculates the natural logarithm \(base e\) for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.LnResult Ln(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Ln(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of real values to calculate the natural logarithm for\.

#### Returns
[LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult')  
A [LnResult](LnResult.md 'TechnicalAnalysis\.Functions\.LnResult') containing the calculated natural logarithm values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.