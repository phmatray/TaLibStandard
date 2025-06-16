#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.AdOsc Method

| Overloads | |
| :--- | :--- |
| [AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\], int, int\)](TAMath.AdOsc.md#TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int) 'TechnicalAnalysis\.Functions\.TAMath\.AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\], int, int\)') | Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\)\. |
| [AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\]\)](TAMath.AdOsc.md#TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\]\)') | Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) with default periods\. |
| [AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\], int, int\)](TAMath.AdOsc.md#TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int) 'TechnicalAnalysis\.Functions\.TAMath\.AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\], int, int\)') | Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) using float arrays\. |
| [AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\]\)](TAMath.AdOsc.md#TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\]\)') | Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) using float arrays with default periods\. |

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int)'></a>

## TAMath\.AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\], int, int\) Method

Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\)\.

```csharp
public static TechnicalAnalysis.Functions.AdOscResult AdOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume, int fastPeriod, int slowPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).volume'></a>

`volume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The period for the fast exponential moving average \(default: 3\)\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[],int,int).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The period for the slow exponential moving average \(default: 10\)\.

#### Returns
[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')  
An AdOscResult object containing the calculated oscillator values\.

### Remarks
The Chaikin Oscillator is created by subtracting a 10\-period exponential moving average 
of the Accumulation/Distribution line from a 3\-period exponential moving average of the A/D line\.
This oscillator measures the momentum of the Accumulation/Distribution line by plotting the difference 
between the fast and slow exponential moving averages\. It is used to identify bullish and bearish 
divergences that can signal potential trend reversals\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[])'></a>

## TAMath\.AdOsc\(int, int, double\[\], double\[\], double\[\], double\[\]\) Method

Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) with default periods\.

```csharp
public static TechnicalAnalysis.Functions.AdOscResult AdOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')  
An AdOscResult object containing the calculated oscillator values\.

### Remarks
This overload uses default values of 3 for the fast period and 10 for the slow period\.
See the main overload for a detailed description of the ADOSC indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int)'></a>

## TAMath\.AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\], int, int\) Method

Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AdOscResult AdOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume, int fastPeriod, int slowPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).volume'></a>

`volume` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The period for the fast exponential moving average\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[],int,int).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The period for the slow exponential moving average\.

#### Returns
[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')  
An AdOscResult object containing the calculated oscillator values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the ADOSC indicator\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[])'></a>

## TAMath\.AdOsc\(int, int, float\[\], float\[\], float\[\], float\[\]\) Method

Calculates the Chaikin Accumulation/Distribution Oscillator \(ADOSC\) using float arrays with default periods\.

```csharp
public static TechnicalAnalysis.Functions.AdOscResult AdOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AdOsc(int,int,float[],float[],float[],float[]).volume'></a>

`volume` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[AdOscResult](AdOscResult.md 'TechnicalAnalysis\.Functions\.AdOscResult')  
An AdOscResult object containing the calculated oscillator values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
Uses default values of 3 for the fast period and 10 for the slow period\.