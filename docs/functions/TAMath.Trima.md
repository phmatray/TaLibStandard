#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Trima Method

| Overloads | |
| :--- | :--- |
| [Trima\(int, int, double\[\], int\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, double\[\], int\)') | Calculates the Triangular Moving Average \(TRIMA\) for the specified range of data\. |
| [Trima\(int, int, float\[\], int\)](TAMath.Trima.md#TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Trima\(int, int, float\[\], int\)') | Calculates the Triangular Moving Average \(TRIMA\) for float input data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int)'></a>

## TAMath\.Trima\(int, int, double\[\], int\) Method

Calculates the Triangular Moving Average \(TRIMA\) for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, double[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the TRIMA calculation\. Default is 30\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

### Remarks
The Triangular Moving Average \(TRIMA\) is a double\-smoothed simple moving average that places
the most weight on the middle portion of the data\. It is calculated by averaging a simple
moving average\. This creates a smoother line that is less responsive to short\-term fluctuations
but better at identifying longer\-term trends\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int)'></a>

## TAMath\.Trima\(int, int, float\[\], int\) Method

Calculates the Triangular Moving Average \(TRIMA\) for float input data\.

```csharp
public static TechnicalAnalysis.Functions.TrimaResult Trima(int startIdx, int endIdx, float[] real, int timePeriod=30);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Trima(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the TRIMA calculation\. Default is 30\.

#### Returns
[TrimaResult](TrimaResult.md 'TechnicalAnalysis\.Functions\.TrimaResult')  
A TrimaResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.