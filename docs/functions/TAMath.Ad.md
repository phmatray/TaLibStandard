#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Ad Method

| Overloads | |
| :--- | :--- |
| [Ad\(int, int, double\[\], double\[\], double\[\], double\[\]\)](TAMath.Ad.md#TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ad\(int, int, double\[\], double\[\], double\[\], double\[\]\)') | Calculates the Accumulation/Distribution \(A/D\) indicator\. |
| [Ad\(int, int, float\[\], float\[\], float\[\], float\[\]\)](TAMath.Ad.md#TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Ad\(int, int, float\[\], float\[\], float\[\], float\[\]\)') | Calculates the Accumulation/Distribution \(A/D\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[])'></a>

## TAMath\.Ad\(int, int, double\[\], double\[\], double\[\], double\[\]\) Method

Calculates the Accumulation/Distribution \(A/D\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.AdResult Ad(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,double[],double[],double[],double[]).volume'></a>

`volume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[AdResult](AdResult.md 'TechnicalAnalysis\.Functions\.AdResult')  
An AdResult object containing the calculated values\.

### Remarks
The Accumulation/Distribution indicator is a cumulative indicator that uses volume and price to assess whether 
a stock is being accumulated or distributed\. The A/D measure seeks to identify divergences between the stock 
price and volume flow\. This provides insight into how strong a trend is\. If the price is rising but the 
indicator is falling, then it suggests that buying volume may not be enough to support the price rise and 
a price decline could be forthcoming\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[])'></a>

## TAMath\.Ad\(int, int, float\[\], float\[\], float\[\], float\[\]\) Method

Calculates the Accumulation/Distribution \(A/D\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AdResult Ad(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Ad(int,int,float[],float[],float[],float[]).volume'></a>

`volume` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[AdResult](AdResult.md 'TechnicalAnalysis\.Functions\.AdResult')  
An AdResult object containing the calculated values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the A/D indicator\.