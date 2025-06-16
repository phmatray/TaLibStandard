#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.TrueRange Method

| Overloads | |
| :--- | :--- |
| [TrueRange\(int, int, double\[\], double\[\], double\[\]\)](TAMath.TrueRange.md#TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.TrueRange\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the True Range \(TRANGE\) indicator\. |
| [TrueRange\(int, int, float\[\], float\[\], float\[\]\)](TAMath.TrueRange.md#TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.TrueRange\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the True Range \(TRANGE\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[])'></a>

## TAMath\.TrueRange\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the True Range \(TRANGE\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.TrueRangeResult TrueRange(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult')  
A TrueRangeResult object containing the calculated values\.

### Remarks
True Range is the greatest of the following:
\- Current high minus current low
\- Absolute value of current high minus previous close
\- Absolute value of current low minus previous close

True Range captures volatility from gaps and limit moves\. It is a component of the Average True Range \(ATR\) indicator\.
Unlike the traditional range calculation, True Range accounts for gaps between trading sessions\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[])'></a>

## TAMath\.TrueRange\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the True Range \(TRANGE\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.TrueRangeResult TrueRange(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TrueRange(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

An array of closing prices\.

#### Returns
[TrueRangeResult](TrueRangeResult.md 'TechnicalAnalysis\.Functions\.TrueRangeResult')  
A TrueRangeResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.