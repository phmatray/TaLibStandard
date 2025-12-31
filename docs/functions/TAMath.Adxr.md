#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Adxr Method

| Overloads | |
| :--- | :--- |
| [Adxr\(int, int, double\[\], double\[\], double\[\], int\)](TAMath.Adxr.md#TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Adxr\(int, int, double\[\], double\[\], double\[\], int\)') | Calculates the Average Directional Movement Index Rating \(ADXR\) indicator\. |
| [Adxr\(int, int, float\[\], float\[\], float\[\], int\)](TAMath.Adxr.md#TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Adxr\(int, int, float\[\], float\[\], float\[\], int\)') | Calculates the Average Directional Movement Index Rating \(ADXR\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int)'></a>

## TAMath\.Adxr\(int, int, double\[\], double\[\], double\[\], int\) Method

Calculates the Average Directional Movement Index Rating \(ADXR\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.AdxrResult Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,double[],double[],double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the calculation \(default: 14\)\.

#### Returns
[AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult')  
An AdxrResult object containing the calculated ADXR values\.

### Remarks
The Average Directional Movement Index Rating \(ADXR\) is a smoothed version of the ADX indicator\.
It is calculated as the average of the current ADX value and the ADX value from a specified number 
of periods ago \(typically half the ADX period\)\.

ADXR = \(ADX\[today\] \+ ADX\[n periods ago\]\) / 2

The ADXR provides a smoother representation of trend strength compared to ADX, making it useful for:
\- Filtering out short\-term fluctuations in trend strength
\- Confirming longer\-term trend conditions
\- Reducing false signals in choppy markets

Like ADX, ADXR values indicate:
\- Below 25: Weak or absent trend
\- 25\-50: Strong trend
\- Above 50: Very strong trend

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int)'></a>

## TAMath\.Adxr\(int, int, float\[\], float\[\], float\[\], int\) Method

Calculates the Average Directional Movement Index Rating \(ADXR\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AdxrResult Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod=14);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Adxr(int,int,float[],float[],float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods for the calculation \(default: 14\)\.

#### Returns
[AdxrResult](AdxrResult.md 'TechnicalAnalysis\.Functions\.AdxrResult')  
An AdxrResult object containing the calculated ADXR values\.

### Remarks
This is a float overload that converts input arrays to double arrays before processing\.
See the double array overload for a detailed description of the ADXR indicator\.