#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Floor Method

| Overloads | |
| :--- | :--- |
| [Floor\(int, int, double\[\]\)](TAMath.Floor.md#TechnicalAnalysis.Functions.TAMath.Floor(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Floor\(int, int, double\[\]\)') | Calculates the vector floor function for each element in the input array\. |
| [Floor\(int, int, float\[\]\)](TAMath.Floor.md#TechnicalAnalysis.Functions.TAMath.Floor(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Floor\(int, int, float\[\]\)') | Calculates the vector floor function for each element in the input array\. |

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,double[])'></a>

## TAMath\.Floor\(int, int, double\[\]\) Method

Calculates the vector floor function for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.FloorResult Floor(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the floor for\.

#### Returns
[FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult')  
A [FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult') containing the calculated floor values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
The floor function returns the largest integer less than or equal to each value in the input array\.
For example, floor\(2\.8\) returns 2\.0, and floor\(\-2\.3\) returns \-3\.0\.
This is useful for rounding down values to the nearest integer in technical analysis calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,float[])'></a>

## TAMath\.Floor\(int, int, float\[\]\) Method

Calculates the vector floor function for each element in the input array\.

```csharp
public static TechnicalAnalysis.Functions.FloorResult Floor(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the array\.

<a name='TechnicalAnalysis.Functions.TAMath.Floor(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of real values to calculate the floor for\.

#### Returns
[FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult')  
A [FloorResult](FloorResult.md 'TechnicalAnalysis\.Functions\.FloorResult') containing the calculated floor values, 
along with the starting index of the result and the number of elements generated\.

### Remarks
This overload accepts float values for convenience and internally converts them to double precision
before performing the calculation\. This may result in minor precision differences compared to 
using double values directly\.