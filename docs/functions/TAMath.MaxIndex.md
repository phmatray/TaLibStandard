#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MaxIndex Method

| Overloads | |
| :--- | :--- |
| [MaxIndex\(int, int, double\[\], int\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, double\[\], int\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\)\. |
| [MaxIndex\(int, int, float\[\], int\)](TAMath.MaxIndex.md#TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.MaxIndex\(int, int, float\[\], int\)') | Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int)'></a>

## TAMath\.MaxIndex\(int, int, double\[\], int\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\)\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the maximum value\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
The MAXINDEX function returns the index \(position\) of the highest value within a moving window
of the specified time period\. This is useful for identifying exactly when maximum values occurred
in the data series\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int)'></a>

## TAMath\.MaxIndex\(int, int, float\[\], int\) Method

Calculates the index of the highest value over a specified time period \(MAXINDEX\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MaxIndex(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to look back for finding the maximum value \(default: 30\)\.

#### Returns
[MaxIndexResult](MaxIndexResult.md 'TechnicalAnalysis\.Functions\.MaxIndexResult')  
A MaxIndexResult containing the indices of maximum values over each rolling window\.

### Remarks
This overload accepts a float array and converts it to a double array before processing\.
The conversion may result in minor precision differences\.