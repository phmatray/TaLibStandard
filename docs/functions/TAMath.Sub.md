#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sub Method

| Overloads | |
| :--- | :--- |
| [Sub\(int, int, double\[\], double\[\]\)](TAMath.Sub.md#TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sub\(int, int, double\[\], double\[\]\)') | Performs element\-wise subtraction of two input arrays\. |
| [Sub\(int, int, float\[\], float\[\]\)](TAMath.Sub.md#TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Sub\(int, int, float\[\], float\[\]\)') | Performs element\-wise subtraction of two input arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[])'></a>

## TAMath\.Sub\(int, int, double\[\], double\[\]\) Method

Performs element\-wise subtraction of two input arrays\.

```csharp
public static TechnicalAnalysis.Functions.SubResult Sub(int startIdx, int endIdx, double[] real0, double[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[]).real0'></a>

`real0` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The first input array \(minuend\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,double[],double[]).real1'></a>

`real1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The second input array \(subtrahend\)\.

#### Returns
[SubResult](SubResult.md 'TechnicalAnalysis\.Functions\.SubResult')  
A SubResult containing the calculated values where each element is real0\[i\] \- real1\[i\]\.

### Remarks
This function performs vector subtraction by subtracting corresponding elements of the second array from the first array\.
The operation is performed for each index i in the range \[startIdx, endIdx\]\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[])'></a>

## TAMath\.Sub\(int, int, float\[\], float\[\]\) Method

Performs element\-wise subtraction of two input arrays\.

```csharp
public static TechnicalAnalysis.Functions.SubResult Sub(int startIdx, int endIdx, float[] real0, float[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[]).real0'></a>

`real0` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The first input array \(minuend\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Sub(int,int,float[],float[]).real1'></a>

`real1` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The second input array \(subtrahend\)\.

#### Returns
[SubResult](SubResult.md 'TechnicalAnalysis\.Functions\.SubResult')  
A SubResult containing the calculated values where each element is real0\[i\] \- real1\[i\]\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.