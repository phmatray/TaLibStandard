#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.SarExt Method

| Overloads | |
| :--- | :--- |
| [SarExt\(int, int, double\[\], double\[\]\)](TAMath.SarExt.md#TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.SarExt\(int, int, double\[\], double\[\]\)') | Calculates the Parabolic SAR Extended \(SAREXT\) indicator using default parameters\. |
| [SarExt\(int, int, double\[\], double\[\], double, double, double, double, double, double, double, double\)](TAMath.SarExt.md#TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double) 'TechnicalAnalysis\.Functions\.TAMath\.SarExt\(int, int, double\[\], double\[\], double, double, double, double, double, double, double, double\)') | Calculates the Parabolic SAR Extended \(SAREXT\) indicator\. |
| [SarExt\(int, int, float\[\], float\[\]\)](TAMath.SarExt.md#TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.SarExt\(int, int, float\[\], float\[\]\)') | Calculates the Parabolic SAR Extended \(SAREXT\) indicator using float arrays and default parameters\. |
| [SarExt\(int, int, float\[\], float\[\], double, double, double, double, double, double, double, double\)](TAMath.SarExt.md#TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double) 'TechnicalAnalysis\.Functions\.TAMath\.SarExt\(int, int, float\[\], float\[\], double, double, double, double, double, double, double, double\)') | Calculates the Parabolic SAR Extended \(SAREXT\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[])'></a>

## TAMath\.SarExt\(int, int, double\[\], double\[\]\) Method

Calculates the Parabolic SAR Extended \(SAREXT\) indicator using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.SarExtResult SarExt(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

#### Returns
[SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult')  
A SarExtResult object containing the calculated values\.

### Remarks
Uses default values for all parameters with symmetric acceleration settings for long and short positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double)'></a>

## TAMath\.SarExt\(int, int, double\[\], double\[\], double, double, double, double, double, double, double, double\) Method

Calculates the Parabolic SAR Extended \(SAREXT\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.SarExtResult SarExt(int startIdx, int endIdx, double[] high, double[] low, double startValue, double offsetOnReverse, double accelerationInitLong, double accelerationLong, double accelerationMaxLong, double accelerationInitShort, double accelerationShort, double accelerationMaxShort);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).startValue'></a>

`startValue` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The starting value for the SAR \(default: 0\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).offsetOnReverse'></a>

`offsetOnReverse` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The offset on reverse \(default: 0\.0\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationInitLong'></a>

`accelerationInitLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The initial acceleration for long positions \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationLong'></a>

`accelerationLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration increment for long positions \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationMaxLong'></a>

`accelerationMaxLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration for long positions \(default: 0\.2\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationInitShort'></a>

`accelerationInitShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The initial acceleration for short positions \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationShort'></a>

`accelerationShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration increment for short positions \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double).accelerationMaxShort'></a>

`accelerationMaxShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration for short positions \(default: 0\.2\)\.

#### Returns
[SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult')  
A SarExtResult object containing the calculated values\.

### Remarks
The Parabolic SAR Extended is an enhanced version of the standard Parabolic SAR that allows
different acceleration parameters for long and short positions\. This provides more flexibility
in adapting the indicator to different market conditions and trading styles\.
The offset on reverse can be used to add a buffer when the SAR reverses direction\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[])'></a>

## TAMath\.SarExt\(int, int, float\[\], float\[\]\) Method

Calculates the Parabolic SAR Extended \(SAREXT\) indicator using float arrays and default parameters\.

```csharp
public static TechnicalAnalysis.Functions.SarExtResult SarExt(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

#### Returns
[SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult')  
A SarExtResult object containing the calculated values\.

### Remarks
Uses default values for all parameters with symmetric acceleration settings\.
This overload accepts float arrays and converts them to double arrays\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double)'></a>

## TAMath\.SarExt\(int, int, float\[\], float\[\], double, double, double, double, double, double, double, double\) Method

Calculates the Parabolic SAR Extended \(SAREXT\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.SarExtResult SarExt(int startIdx, int endIdx, float[] high, float[] low, double startValue, double offsetOnReverse, double accelerationInitLong, double accelerationLong, double accelerationMaxLong, double accelerationInitShort, double accelerationShort, double accelerationMaxShort);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).startValue'></a>

`startValue` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The starting value for the SAR\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).offsetOnReverse'></a>

`offsetOnReverse` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The offset on reverse\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationInitLong'></a>

`accelerationInitLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The initial acceleration for long positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationLong'></a>

`accelerationLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration increment for long positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationMaxLong'></a>

`accelerationMaxLong` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration for long positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationInitShort'></a>

`accelerationInitShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The initial acceleration for short positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationShort'></a>

`accelerationShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration increment for short positions\.

<a name='TechnicalAnalysis.Functions.TAMath.SarExt(int,int,float[],float[],double,double,double,double,double,double,double,double).accelerationMaxShort'></a>

`accelerationMaxShort` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration for short positions\.

#### Returns
[SarExtResult](SarExtResult.md 'TechnicalAnalysis\.Functions\.SarExtResult')  
A SarExtResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.