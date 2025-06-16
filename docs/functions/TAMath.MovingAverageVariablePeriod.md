#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MovingAverageVariablePeriod Method

| Overloads | |
| :--- | :--- |
| [MovingAverageVariablePeriod\(int, int, double\[\], double\[\], int, int, MAType\)](TAMath.MovingAverageVariablePeriod.md#TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverageVariablePeriod\(int, int, double\[\], double\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates a moving average with variable period lengths \(MAVP\)\. |
| [MovingAverageVariablePeriod\(int, int, double\[\], double\[\]\)](TAMath.MovingAverageVariablePeriod.md#TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverageVariablePeriod\(int, int, double\[\], double\[\]\)') | Calculates a moving average with variable period lengths \(MAVP\) using default parameters\. |
| [MovingAverageVariablePeriod\(int, int, float\[\], float\[\], int, int, MAType\)](TAMath.MovingAverageVariablePeriod.md#TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverageVariablePeriod\(int, int, float\[\], float\[\], int, int, TechnicalAnalysis\.Common\.MAType\)') | Calculates a moving average with variable period lengths \(MAVP\) using float arrays\. |
| [MovingAverageVariablePeriod\(int, int, float\[\], float\[\]\)](TAMath.MovingAverageVariablePeriod.md#TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MovingAverageVariablePeriod\(int, int, float\[\], float\[\]\)') | Calculates a moving average with variable period lengths \(MAVP\) using float arrays and default parameters\. |

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MovingAverageVariablePeriod\(int, int, double\[\], double\[\], int, int, MAType\) Method

Calculates a moving average with variable period lengths \(MAVP\)\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageVariablePeriodResult MovingAverageVariablePeriod(int startIdx, int endIdx, double[] real, double[] periods, int minPeriod, int maxPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).periods'></a>

`periods` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array specifying the period to use for each corresponding value in the real array\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).minPeriod'></a>

`minPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The minimum allowed period value\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The maximum allowed period value\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate\.

#### Returns
[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')  
A MovingAverageVariablePeriodResult containing the calculated values\.

### Remarks
The MAVP indicator allows for dynamic period lengths at each data point, enabling adaptive smoothing
based on market conditions or other criteria\. The period array determines the lookback period for
each corresponding element in the real array\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[])'></a>

## TAMath\.MovingAverageVariablePeriod\(int, int, double\[\], double\[\]\) Method

Calculates a moving average with variable period lengths \(MAVP\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageVariablePeriodResult MovingAverageVariablePeriod(int startIdx, int endIdx, double[] real, double[] periods);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,double[],double[]).periods'></a>

`periods` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array specifying the period to use for each corresponding value in the real array\.

#### Returns
[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')  
A MovingAverageVariablePeriodResult containing the calculated values\.

### Remarks
This overload uses default values: minPeriod=2, maxPeriod=30, and MAType=SMA\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType)'></a>

## TAMath\.MovingAverageVariablePeriod\(int, int, float\[\], float\[\], int, int, MAType\) Method

Calculates a moving average with variable period lengths \(MAVP\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageVariablePeriodResult MovingAverageVariablePeriod(int startIdx, int endIdx, float[] real, float[] periods, int minPeriod, int maxPeriod, TechnicalAnalysis.Common.MAType maType);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).periods'></a>

`periods` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array specifying the period to use for each corresponding value in the real array\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).minPeriod'></a>

`minPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The minimum allowed period value\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The maximum allowed period value\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[],int,int,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.MAType 'TechnicalAnalysis\.Common\.MAType')

The type of moving average to calculate\.

#### Returns
[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')  
A MovingAverageVariablePeriodResult containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
The conversion may result in minor precision differences\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[])'></a>

## TAMath\.MovingAverageVariablePeriod\(int, int, float\[\], float\[\]\) Method

Calculates a moving average with variable period lengths \(MAVP\) using float arrays and default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MovingAverageVariablePeriodResult MovingAverageVariablePeriod(int startIdx, int endIdx, float[] real, float[] periods);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of real values\.

<a name='TechnicalAnalysis.Functions.TAMath.MovingAverageVariablePeriod(int,int,float[],float[]).periods'></a>

`periods` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array specifying the period to use for each corresponding value in the real array\.

#### Returns
[MovingAverageVariablePeriodResult](MovingAverageVariablePeriodResult.md 'TechnicalAnalysis\.Functions\.MovingAverageVariablePeriodResult')  
A MovingAverageVariablePeriodResult containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
Uses default values: minPeriod=2, maxPeriod=30, and MAType=SMA\.