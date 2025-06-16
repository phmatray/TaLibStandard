#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.RocP Method

| Overloads | |
| :--- | :--- |
| [RocP\(int, int, double\[\], int\)](TAMath.RocP.md#TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocP\(int, int, double\[\], int\)') | Calculates the Rate of Change Percentage \(ROCP\) indicator for the specified range of data\. |
| [RocP\(int, int, double\[\]\)](TAMath.RocP.md#TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.RocP\(int, int, double\[\]\)') | Calculates the Rate of Change Percentage \(ROCP\) indicator using a default period of 10\. |
| [RocP\(int, int, float\[\], int\)](TAMath.RocP.md#TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocP\(int, int, float\[\], int\)') | Calculates the Rate of Change Percentage \(ROCP\) indicator for float input data\. |
| [RocP\(int, int, float\[\]\)](TAMath.RocP.md#TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.RocP\(int, int, float\[\]\)') | Calculates the Rate of Change Percentage \(ROCP\) indicator for float input data using a default period of 10\. |

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int)'></a>

## TAMath\.RocP\(int, int, double\[\], int\) Method

Calculates the Rate of Change Percentage \(ROCP\) indicator for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.RocPResult RocP(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the ROCP calculation\. Default is 10\.

#### Returns
[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')  
A RocPResult object containing the calculated values and metadata\.

### Remarks
The Rate of Change Percentage \(ROCP\) indicator is similar to ROC but expresses the rate of change
as a decimal fraction rather than a percentage\. The formula is: ROCP = \(current price \- price n 
periods ago\) / price n periods ago\. For example, a 10% increase would be represented as 0\.1\.
This momentum oscillator helps identify the velocity of price changes and potential trend reversals\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[])'></a>

## TAMath\.RocP\(int, int, double\[\]\) Method

Calculates the Rate of Change Percentage \(ROCP\) indicator using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocPResult RocP(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')  
A RocPResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int)'></a>

## TAMath\.RocP\(int, int, float\[\], int\) Method

Calculates the Rate of Change Percentage \(ROCP\) indicator for float input data\.

```csharp
public static TechnicalAnalysis.Functions.RocPResult RocP(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the ROCP calculation\.

#### Returns
[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')  
A RocPResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[])'></a>

## TAMath\.RocP\(int, int, float\[\]\) Method

Calculates the Rate of Change Percentage \(ROCP\) indicator for float input data using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocPResult RocP(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.RocP(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[RocPResult](RocPResult.md 'TechnicalAnalysis\.Functions\.RocPResult')  
A RocPResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.