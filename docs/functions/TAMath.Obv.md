#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Obv Method

| Overloads | |
| :--- | :--- |
| [Obv\(int, int, double\[\], double\[\]\)](TAMath.Obv.md#TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Obv\(int, int, double\[\], double\[\]\)') | Calculates the On Balance Volume \(OBV\) indicator\. |
| [Obv\(int, int, float\[\], float\[\]\)](TAMath.Obv.md#TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Obv\(int, int, float\[\], float\[\]\)') | Calculates the On Balance Volume \(OBV\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[])'></a>

## TAMath\.Obv\(int, int, double\[\], double\[\]\) Method

Calculates the On Balance Volume \(OBV\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.ObvResult Obv(int startIdx, int endIdx, double[] real, double[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,double[],double[]).volume'></a>

`volume` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[ObvResult](ObvResult.md 'TechnicalAnalysis\.Functions\.ObvResult')  
An ObvResult object containing the calculated OBV values\.

### Remarks
On Balance Volume \(OBV\) is a momentum indicator that uses volume flow to predict changes in stock price\.
Joseph Granville first developed the OBV metric in the 1963 book "Granville's New Key to Stock Market Profits"\.

The OBV is calculated by adding volume on up days and subtracting volume on down days\. The theory is that 
volume precedes price movement, so if a security is seeing an increasing OBV, it is a signal that volume is 
increasing on upward price moves\. This is interpreted as a bullish signal\. Conversely, if OBV is decreasing 
while prices are rising, it may indicate that the trend is not sustainable\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[])'></a>

## TAMath\.Obv\(int, int, float\[\], float\[\]\) Method

Calculates the On Balance Volume \(OBV\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.ObvResult Obv(int startIdx, int endIdx, float[] real, float[] volume);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of prices \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Obv(int,int,float[],float[]).volume'></a>

`volume` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of trading volumes\.

#### Returns
[ObvResult](ObvResult.md 'TechnicalAnalysis\.Functions\.ObvResult')  
An ObvResult object containing the calculated OBV values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the OBV indicator\.