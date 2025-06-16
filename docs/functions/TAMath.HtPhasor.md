#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtPhasor Method

| Overloads | |
| :--- | :--- |
| [HtPhasor\(int, int, double\[\]\)](TAMath.HtPhasor.md#TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtPhasor\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- Phasor Components for the input price data\. |
| [HtPhasor\(int, int, float\[\]\)](TAMath.HtPhasor.md#TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtPhasor\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- Phasor Components for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,double[])'></a>

## TAMath\.HtPhasor\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Phasor Components for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtPhasorResult HtPhasor(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtPhasorResult](HtPhasorResult.md 'TechnicalAnalysis\.Functions\.HtPhasorResult')  
An HtPhasorResult containing the in\-phase and quadrature components\.

### Remarks
The Hilbert Transform \- Phasor Components breaks down the price data into two 
components: In\-Phase \(I\) and Quadrature \(Q\)\. These components represent the 
real and imaginary parts of the analytic signal\. They are used internally by 
other Hilbert Transform indicators and can help identify cycle characteristics 
in the market data\.

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,float[])'></a>

## TAMath\.HtPhasor\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- Phasor Components for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtPhasorResult HtPhasor(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtPhasor(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtPhasorResult](HtPhasorResult.md 'TechnicalAnalysis\.Functions\.HtPhasorResult')  
An HtPhasorResult containing the in\-phase and quadrature components\.

### Remarks
This overload accepts float input and converts it to double for calculation\.