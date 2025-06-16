#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Trima Method

| Overloads | |
| :--- | :--- |
| [Trima\(int, int, double\[\], int\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, double\[\], int\)') | Calculates the Triangular Moving Average \(TRIMA\) for the specified range of data\. |
| [Trima\(int, int, double\[\]\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, double\[\]\)') | Calculates the Triangular Moving Average \(TRIMA\) using a default period of 30\. |
| [Trima\(int, int, float\[\], int\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, float\[\], int\)') | Calculates the Triangular Moving Average \(TRIMA\) for float input data\. |
| [Trima\(int, int, float\[\]\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, float\[\]\)') | Calculates the Triangular Moving Average \(TRIMA\) for float input data using a default period of 30\. |

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int)'></a>

## TAMath\.Trima\(int, int, double\[\], int\) Method

Calculates the Triangular Moving Average \(TRIMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the TRIMA calculation\. Default is 30\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

### Remarks
The Triangular Moving Average \(TRIMA\) is a double\-smoothed simple moving average that places
the most weight on the middle portion of the data\. It is calculated by averaging a simple
moving average\. This creates a smoother line that is less responsive to short\-term fluctuations
but better at identifying longer\-term trends\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[])'></a>

## TAMath\.Trima\(int, int, double\[\]\) Method

Calculates the Triangular Moving Average \(TRIMA\) using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int)'></a>

## TAMath\.Trima\(int, int, float\[\], int\) Method

Calculates the Triangular Moving Average \(TRIMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the TRIMA calculation\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[])'></a>

## TAMath\.Trima\(int, int, float\[\]\) Method

Calculates the Triangular Moving Average \(TRIMA\) for float input data using a default period of 30\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.