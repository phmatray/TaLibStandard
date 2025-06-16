#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.HtDcPhase Method

| Overloads | |
| :--- | :--- |
| [HtDcPhase\(int, int, double\[\]\)](TAMath.HtDcPhase.md#TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtDcPhase\(int, int, double\[\]\)') | Calculates the Hilbert Transform \- Dominant Cycle Phase for the input price data\. |
| [HtDcPhase\(int, int, float\[\]\)](TAMath.HtDcPhase.md#TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.HtDcPhase\(int, int, float\[\]\)') | Calculates the Hilbert Transform \- Dominant Cycle Phase for the input price data\. |

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,double[])'></a>

## TAMath\.HtDcPhase\(int, int, double\[\]\) Method

Calculates the Hilbert Transform \- Dominant Cycle Phase for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult')  
An HtDcPhaseResult containing the calculated dominant cycle phase values\.

### Remarks
The Hilbert Transform \- Dominant Cycle Phase measures the phase angle of the 
dominant market cycle\. The phase ranges from 0 to 360 degrees, indicating 
where the current price is within the identified cycle\. This helps traders 
identify cycle tops and bottoms and can be used for timing entries and exits\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,float[])'></a>

## TAMath\.HtDcPhase\(int, int, float\[\]\) Method

Calculates the Hilbert Transform \- Dominant Cycle Phase for the input price data\.

```csharp
public static TechnicalAnalysis.Functions.HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.HtDcPhase(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input price data\.

#### Returns
[HtDcPhaseResult](HtDcPhaseResult.md 'TechnicalAnalysis\.Functions\.HtDcPhaseResult')  
An HtDcPhaseResult containing the calculated dominant cycle phase values\.

### Remarks
This overload accepts float input and converts it to double for calculation\.