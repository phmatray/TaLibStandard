#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.T3 Method

| Overloads | |
| :--- | :--- |
| [T3\(int, int, double\[\]\)](TAMath.T3.md#TechnicalAnalysis.Functions.TAMath.T3(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.T3\(int, int, double\[\]\)') | Calculates the T3 Triple Exponential Moving Average using default parameters \(period=5, vFactor=0\.7\)\. |
| [T3\(int, int, double\[\], int, double\)](TAMath.T3.md#TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.T3\(int, int, double\[\], int, double\)') | Calculates the T3 Triple Exponential Moving Average for the specified range of data\. |
| [T3\(int, int, float\[\]\)](TAMath.T3.md#TechnicalAnalysis.Functions.TAMath.T3(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.T3\(int, int, float\[\]\)') | Calculates the T3 Triple Exponential Moving Average for float input data using default parameters\. |
| [T3\(int, int, float\[\], int, double\)](TAMath.T3.md#TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double) 'TechnicalAnalysis\.Functions\.TAMath\.T3\(int, int, float\[\], int, double\)') | Calculates the T3 Triple Exponential Moving Average for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[])'></a>

## TAMath\.T3\(int, int, double\[\]\) Method

Calculates the T3 Triple Exponential Moving Average using default parameters \(period=5, vFactor=0\.7\)\.

```csharp
public static TechnicalAnalysis.Functions.T3Result T3(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

#### Returns
[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')  
A T3Result object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double)'></a>

## TAMath\.T3\(int, int, double\[\], int, double\) Method

Calculates the T3 Triple Exponential Moving Average for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.T3Result T3(int startIdx, int endIdx, double[] real, int timePeriod, double vFactor);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the T3 calculation\. Default is 5\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,double[],int,double).vFactor'></a>

`vFactor` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The volume factor \(0\-1\) that controls the smoothing\. Default is 0\.7\.

#### Returns
[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')  
A T3Result object containing the calculated values and metadata\.

### Remarks
The T3 Triple Exponential Moving Average is a type of moving average developed by Tim Tillson\.
It incorporates multiple exponential moving averages and includes a volume factor to provide
better smoothing with reduced lag\. The vFactor parameter controls the amount of smoothing,
where higher values \(closer to 1\) provide more smoothing but may introduce more lag\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[])'></a>

## TAMath\.T3\(int, int, float\[\]\) Method

Calculates the T3 Triple Exponential Moving Average for float input data using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.T3Result T3(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')  
A T3Result object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.
Uses default parameters: period=5, vFactor=0\.7\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double)'></a>

## TAMath\.T3\(int, int, float\[\], int, double\) Method

Calculates the T3 Triple Exponential Moving Average for float input data\.

```csharp
public static TechnicalAnalysis.Functions.T3Result T3(int startIdx, int endIdx, float[] real, int timePeriod, double vFactor);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the T3 calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.T3(int,int,float[],int,double).vFactor'></a>

`vFactor` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The volume factor \(0\-1\) that controls the smoothing\.

#### Returns
[T3Result](T3Result.md 'TechnicalAnalysis\.Functions\.T3Result')  
A T3Result object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.