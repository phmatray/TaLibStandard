#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Min Method

| Overloads | |
| :--- | :--- |
| [Min\(int, int, double\[\], int\)](TAMath.Min.md#TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Min\(int, int, double\[\], int\)') | Calculates the lowest value over a specified time period \(MIN\)\. |
| [Min\(int, int, float\[\], int\)](TAMath.Min.md#TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Min\(int, int, float\[\], int\)') | Calculates the lowest value over a specified time period \(MIN\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int)'></a>

## TAMath\.Min\(int, int, double\[\], int\) Method

Calculates the lowest value over a specified time period \(MIN\)\.

```csharp
public static TechnicalAnalysis.Functions.MinResult Min(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum value\.

#### Returns
[MinResult](MinResult.md 'TechnicalAnalysis\.Functions\.MinResult')  
A MinResult containing the minimum values over each rolling window\.

### Remarks
The MIN function identifies the lowest value within a moving window of the specified time period\.
This is useful for identifying support levels and tracking the lower boundaries of price movements\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int)'></a>

## TAMath\.Min\(int, int, float\[\], int\) Method

Calculates the lowest value over a specified time period \(MIN\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MinResult Min(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.Min(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the minimum value \(default: 30\)\.

#### Returns
[MinResult](MinResult.md 'TechnicalAnalysis\.Functions\.MinResult')  
A MinResult containing the minimum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.