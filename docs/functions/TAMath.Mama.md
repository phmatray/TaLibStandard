#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Mama Method

| Overloads | |
| :--- | :--- |
| [Mama\(int, int, double\[\]\)](TAMath.Mama.md#TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mama\(int, int, double\[\]\)') | Calculates the MESA Adaptive Moving Average \(MAMA\) using default parameters\. |
| [Mama\(int, int, double\[\], double, double\)](TAMath.Mama.md#TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double) 'TechnicalAnalysis\.Functions\.TAMath\.Mama\(int, int, double\[\], double, double\)') | Calculates the MESA Adaptive Moving Average \(MAMA\) for the input price data\. |
| [Mama\(int, int, float\[\]\)](TAMath.Mama.md#TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Mama\(int, int, float\[\]\)') | Calculates the MESA Adaptive Moving Average \(MAMA\) using default parameters\. |
| [Mama\(int, int, float\[\], double, double\)](TAMath.Mama.md#TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double) 'TechnicalAnalysis\.Functions\.TAMath\.Mama\(int, int, float\[\], double, double\)') | Calculates the MESA Adaptive Moving Average \(MAMA\) for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[])'></a>

## TAMath\.Mama\(int, int, double\[\]\) Method

Calculates the MESA Adaptive Moving Average \(MAMA\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MamaResult Mama(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[]).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')  
A MamaResult containing the MAMA and FAMA values\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double)'></a>

## TAMath\.Mama\(int, int, double\[\], double, double\) Method

Calculates the MESA Adaptive Moving Average \(MAMA\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.MamaResult Mama(int startIdx, int endIdx, double[] real, double fastLimit, double slowLimit);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double).fastLimit'></a>

`fastLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The fast limit parameter for adaptation speed \(default: 0\.5\)\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,double[],double,double).slowLimit'></a>

`slowLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The slow limit parameter for adaptation speed \(default: 0\.05\)\.

#### Returns
[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')  
A MamaResult containing the MAMA and FAMA \(Following Adaptive Moving Average\) values\.

### Remarks
MESA Adaptive Moving Average automatically adjusts its smoothing factor based on 
the dominant market cycle measured by the Hilbert Transform\. MAMA closely follows 
price in trending markets and provides smooth results in cycling markets\. FAMA 
\(Following Adaptive Moving Average\) is a complementary indicator that can be used 
for crossover signals\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[])'></a>

## TAMath\.Mama\(int, int, float\[\]\) Method

Calculates the MESA Adaptive Moving Average \(MAMA\) using default parameters\.

```csharp
public static TechnicalAnalysis.Functions.MamaResult Mama(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[]).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

#### Returns
[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')  
A MamaResult containing the MAMA and FAMA values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double)'></a>

## TAMath\.Mama\(int, int, float\[\], double, double\) Method

Calculates the MESA Adaptive Moving Average \(MAMA\) for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.MamaResult Mama(int startIdx, int endIdx, float[] real, double fastLimit, double slowLimit);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The input price data\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double).fastLimit'></a>

`fastLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The fast limit parameter for adaptation speed\.

<a name='TechnicalAnalysis.Functions.TAMath.Mama(int,int,float[],double,double).slowLimit'></a>

`slowLimit` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The slow limit parameter for adaptation speed\.

#### Returns
[MamaResult](MamaResult.md 'TechnicalAnalysis\.Functions\.MamaResult')  
A MamaResult containing the MAMA and FAMA values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.