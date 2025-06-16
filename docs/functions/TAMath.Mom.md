#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Mom Method

| Overloads | |
| :--- | :--- |
| [Mom\(int, int, double\[\], int\)](TAMath.Mom.md#TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Mom\(int, int, double\[\], int\)') | Calculates the Momentum indicator for the specified range of data\. |
| [Mom\(int, int, double\[\]\)](TAMath.Mom.md#TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mom\(int, int, double\[\]\)') | Calculates the Momentum indicator using a default period of 10\. |
| [Mom\(int, int, float\[\], int\)](TAMath.Mom.md#TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Mom\(int, int, float\[\], int\)') | Calculates the Momentum indicator for float input data\. |
| [Mom\(int, int, float\[\]\)](TAMath.Mom.md#TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mom\(int, int, float\[\]\)') | Calculates the Momentum indicator for float input data using a default period of 10\. |

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int)'></a>

## TAMath\.Mom\(int, int, double\[\], int\) Method

Calculates the Momentum indicator for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.MomResult Mom(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the momentum calculation\. Default is 10\.

#### Returns
[MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult')  
A MomResult object containing the calculated values and metadata\.

### Remarks
The Momentum indicator measures the rate of change in price over a specified period\.
It is calculated as the difference between the current price and the price n periods ago\.
Positive values indicate upward momentum, while negative values indicate downward momentum\.
The indicator is useful for identifying the strength and direction of price trends\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[])'></a>

## TAMath\.Mom\(int, int, double\[\]\) Method

Calculates the Momentum indicator using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.MomResult Mom(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult')  
A MomResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int)'></a>

## TAMath\.Mom\(int, int, float\[\], int\) Method

Calculates the Momentum indicator for float input data\.

```csharp
public static TechnicalAnalysis.Functions.MomResult Mom(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the momentum calculation\.

#### Returns
[MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult')  
A MomResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[])'></a>

## TAMath\.Mom\(int, int, float\[\]\) Method

Calculates the Momentum indicator for float input data using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.MomResult Mom(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mom(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[MomResult](MomResult.md 'TechnicalAnalysis\.Functions\.MomResult')  
A MomResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.