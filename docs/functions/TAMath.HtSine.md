#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtSine Method

| Overloads | |
| :--- | :--- |
| [HtSine\(int, int, double\[\]\)](TAMath.HtSine.md#TechnicalAnalysis.Functions.TAMath.HtSine(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtSine\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- SineWave indicator for the input price data\. |
| [HtSine\(int, int, float\[\]\)](TAMath.HtSine.md#TechnicalAnalysis.Functions.TAMath.HtSine(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtSine\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- SineWave indicator for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,double[])'></a>

## TAMath\.HtSine\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- SineWave indicator for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtSineResult HtSine(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult')  
An HtSineResult containing the sine and lead sine values\.

### Remarks
The Hilbert Transform \- SineWave indicator generates two outputs: Sine and LeadSine\.
The Sine line shows the current phase position in the dominant cycle, while the 
LeadSine is advanced by 45 degrees\. When Sine crosses above LeadSine, it suggests 
a cycle bottom, and when Sine crosses below LeadSine, it suggests a cycle top\.
This indicator is most effective in cycling markets\.

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,float[])'></a>

## TAMath\.HtSine\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- SineWave indicator for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtSineResult HtSine(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtSine(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtSineResult](HtSineResult.md 'TechnicalAnalysis\.Functions\.HtSineResult')  
An HtSineResult containing the sine and lead sine values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.