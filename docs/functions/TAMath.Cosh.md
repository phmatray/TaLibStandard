#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Cosh Method

| Overloads | |
| :--- | :--- |
| [Cosh\(int, int, double\[\]\)](TAMath.Cosh.md#TechnicalAnalysis.Functions.TAMath.Cosh(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Cosh\(int, int, double\[\]\)') | Calculates the hyperbolic cosine of each element in the input array\. |
| [Cosh\(int, int, float\[\]\)](TAMath.Cosh.md#TechnicalAnalysis.Functions.TAMath.Cosh(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Cosh\(int, int, float\[\]\)') | Calculates the hyperbolic cosine of each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,double[])'></a>

## TAMath\.Cosh\(int, int, double\[\]\) Method

Calculates the hyperbolic cosine of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CoshResult Cosh(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values\.

#### Returns
[CoshResult](CoshResult.md 'TechnicalAnalysis\.Functions\.CoshResult')  
A CoshResult containing the calculated hyperbolic cosine values\.

### Remarks
This function computes the hyperbolic cosine for each element in the input array\.
The hyperbolic cosine is defined as cosh\(x\) = \(e^x \+ e^\-x\) / 2\.
The output values are always greater than or equal to 1\.
Large input values may result in overflow\.

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,float[])'></a>

## TAMath\.Cosh\(int, int, float\[\]\) Method

Calculates the hyperbolic cosine of each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.CoshResult Cosh(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Cosh(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input array of values\.

#### Returns
[CoshResult](CoshResult.md 'TechnicalAnalysis\.Functions\.CoshResult')  
A CoshResult containing the calculated hyperbolic cosine values\.

### Remarks
This overload accepts a float array and converts it to a double array before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.