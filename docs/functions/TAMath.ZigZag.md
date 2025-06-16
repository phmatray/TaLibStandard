#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.ZigZag Method

| Overloads | |
| :--- | :--- |
| [ZigZag\(int, int, double\[\], double\[\], double\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, double\[\], double\[\], double\)') | Calculates the ZigZag indicator which filters out minor price movements to identify significant trends\. |
| [ZigZag\(int, int, double\[\], double\[\]\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, double\[\], double\[\]\)') | Calculates the ZigZag indicator using a default deviation of 5\.0%\. |
| [ZigZag\(int, int, float\[\], float\[\], double\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, float\[\], float\[\], double\)') | Calculates the ZigZag indicator for float arrays\. |
| [ZigZag\(int, int, float\[\], float\[\]\)](TAMath.ZigZag.md#TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.ZigZag\(int, int, float\[\], float\[\]\)') | Calculates the ZigZag indicator for float arrays using a default deviation of 5\.0%\. |

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double)'></a>

## TAMath\.ZigZag\(int, int, double\[\], double\[\], double\) Method

Calculates the ZigZag indicator which filters out minor price movements to identify significant trends\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, double[] high, double[] low, double deviation);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[],double).deviation'></a>

`deviation` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

The minimum percentage deviation required to form a new ZigZag line \(default: 5\.0\)\.

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.

### Remarks
The ZigZag indicator is used to filter out market noise and identify significant price movements\.
It connects significant tops and bottoms in the price data, ignoring smaller movements that don't
meet the specified deviation threshold\. The indicator is primarily used to identify chart patterns
and for Elliott Wave analysis\. Note that ZigZag repaints \- the last leg may change as new data
comes in, making it unsuitable for real\-time trading signals\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[])'></a>

## TAMath\.ZigZag\(int, int, double\[\], double\[\]\) Method

Calculates the ZigZag indicator using a default deviation of 5\.0%\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double)'></a>

## TAMath\.ZigZag\(int, int, float\[\], float\[\], double\) Method

Calculates the ZigZag indicator for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low, double deviation);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[],double).deviation'></a>

`deviation` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

The minimum percentage deviation required to form a new ZigZag line \(default: 5\.0\)\.

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[])'></a>

## TAMath\.ZigZag\(int, int, float\[\], float\[\]\) Method

Calculates the ZigZag indicator for float arrays using a default deviation of 5\.0%\.

```csharp
public static TechnicalAnalysis.Functions.ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.ZigZag(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')  
A ZigZagResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.