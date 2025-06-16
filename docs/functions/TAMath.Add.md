#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Add Method

| Overloads | |
| :--- | :--- |
| [Add\(int, int, double\[\], double\[\]\)](TAMath.Add.md#TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Add\(int, int, double\[\], double\[\]\)') | Performs element\-wise addition of two input arrays\. |
| [Add\(int, int, float\[\], float\[\]\)](TAMath.Add.md#TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Add\(int, int, float\[\], float\[\]\)') | Performs element\-wise addition of two input arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[])'></a>

## TAMath\.Add\(int, int, double\[\], double\[\]\) Method

Performs element\-wise addition of two input arrays\.

```csharp
public static TechnicalAnalysis.Functions.AddResult Add(int startIdx, int endIdx, double[] real0, double[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[]).real0'></a>

`real0` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The first input array of values\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,double[],double[]).real1'></a>

`real1` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The second input array of values\.

#### Returns
[AddResult](AddResult.md 'TechnicalAnalysis\.Functions\.AddResult')  
An AddResult containing the calculated values where each element is real0\[i\] \+ real1\[i\]\.

### Remarks
This function performs vector addition by adding corresponding elements from two arrays\.
The operation is performed for each index i in the range \[startIdx, endIdx\]\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[])'></a>

## TAMath\.Add\(int, int, float\[\], float\[\]\) Method

Performs element\-wise addition of two input arrays\.

```csharp
public static TechnicalAnalysis.Functions.AddResult Add(int startIdx, int endIdx, float[] real0, float[] real1);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[]).real0'></a>

`real0` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The first input array of values\.

<a name='TechnicalAnalysis.Functions.TAMath.Add(int,int,float[],float[]).real1'></a>

`real1` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The second input array of values\.

#### Returns
[AddResult](AddResult.md 'TechnicalAnalysis\.Functions\.AddResult')  
An AddResult containing the calculated values where each element is real0\[i\] \+ real1\[i\]\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This may result in a minor performance overhead due to the conversion process\.