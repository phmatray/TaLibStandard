#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MidPoint Method

| Overloads | |
| :--- | :--- |
| [MidPoint\(int, int, double\[\], int\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, double\[\], int\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\)\. |
| [MidPoint\(int, int, float\[\], int\)](TAMath.MidPoint.md#TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MidPoint\(int, int, float\[\], int\)') | Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int)'></a>

## TAMath\.MidPoint\(int, int, double\[\], int\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\)\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, double[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for calculating the midpoint \(default: 14\)\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
The MIDPOINT function calculates the midpoint between the highest and lowest values within a moving window:
\(Highest Value \+ Lowest Value\) / 2\. This indicator is useful for identifying the center of the price range
and can be used as a simple trend\-following indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int)'></a>

## TAMath\.MidPoint\(int, int, float\[\], int\) Method

Calculates the midpoint value over a specified time period \(MIDPOINT\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MidPointResult MidPoint(int startIdx, int endIdx, float[] real, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MidPoint(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for calculating the midpoint \(default: 14\)\.

#### Returns
[MidPointResult](MidPointResult.md 'TechnicalAnalysis\.Functions\.MidPointResult')  
A MidPointResult containing the midpoint values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.