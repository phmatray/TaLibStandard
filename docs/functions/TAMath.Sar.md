#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Sar Method

| Overloads | |
| :--- | :--- |
| [Sar\(int, int, double\[\], double\[\], double, double\)](TAMath.Sar.md#TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double) 'TechnicalAnalysis\.Functions\.TAMath\.Sar\(int, int, double\[\], double\[\], double, double\)') | Calculates the Parabolic SAR \(Stop And Reverse\) indicator\. |
| [Sar\(int, int, float\[\], float\[\], double, double\)](TAMath.Sar.md#TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double) 'TechnicalAnalysis\.Functions\.TAMath\.Sar\(int, int, float\[\], float\[\], double, double\)') | Calculates the Parabolic SAR \(Stop And Reverse\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double)'></a>

## TAMath\.Sar\(int, int, double\[\], double\[\], double, double\) Method

Calculates the Parabolic SAR \(Stop And Reverse\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.SarResult Sar(int startIdx, int endIdx, double[] high, double[] low, double acceleration=0.02, double maximum=0.2);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).acceleration'></a>

`acceleration` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration factor \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,double[],double[],double,double).maximum'></a>

`maximum` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration factor \(default: 0\.2\)\.

#### Returns
[SarResult](SarResult.md 'TechnicalAnalysis\.Functions\.SarResult')  
A SarResult object containing the calculated values\.

### Remarks
The Parabolic SAR is a trend\-following indicator that provides entry and exit points\.
It appears as a series of dots placed either above or below the price bars\.
A dot below the price indicates a bullish signal, while a dot above indicates a bearish signal\.
The acceleration factor determines how quickly the SAR converges towards the price\.
The indicator is particularly effective in trending markets but can produce whipsaws in ranging markets\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double)'></a>

## TAMath\.Sar\(int, int, float\[\], float\[\], double, double\) Method

Calculates the Parabolic SAR \(Stop And Reverse\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.SarResult Sar(int startIdx, int endIdx, float[] high, float[] low, double acceleration=0.02, double maximum=0.2);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).acceleration'></a>

`acceleration` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The acceleration factor \(default: 0\.02\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Sar(int,int,float[],float[],double,double).maximum'></a>

`maximum` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum acceleration factor \(default: 0\.2\)\.

#### Returns
[SarResult](SarResult.md 'TechnicalAnalysis\.Functions\.SarResult')  
A SarResult object containing the calculated values\.

### Remarks
This overload accepts float arrays and converts them to double arrays before processing\.
This may result in a minor performance overhead due to the conversion process\.