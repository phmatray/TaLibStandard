#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Acos Method

| Overloads | |
| :--- | :--- |
| [Acos\(int, int, double\[\]\)](TAMath.Acos.md#TechnicalAnalysis.Functions.TAMath.Acos(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Acos\(int, int, double\[\]\)') | Calculates the arc cosine \(inverse cosine\) of input values\. |
| [Acos\(int, int, float\[\]\)](TAMath.Acos.md#TechnicalAnalysis.Functions.TAMath.Acos(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Acos\(int, int, float\[\]\)') | Calculates the arc cosine \(inverse cosine\) of input values\. |

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,double[])'></a>

## TAMath\.Acos\(int, int, double\[\]\) Method

Calculates the arc cosine \(inverse cosine\) of input values\.

```csharp
public static TechnicalAnalysis.Functions.AcosResult Acos(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of values \(must be between \-1 and 1\)\.

#### Returns
[AcosResult](AcosResult.md 'TechnicalAnalysis\.Functions\.AcosResult')  
An AcosResult containing the calculated arc cosine values in radians and calculation metadata\.

### Remarks
The arc cosine function:
\- Returns the angle whose cosine is the input value
\- Input values must be in the range \[\-1, 1\]
\- Output values are in radians, ranging from 0 to π
\- Invalid input values \(outside \[\-1, 1\]\) will result in NaN

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,float[])'></a>

## TAMath\.Acos\(int, int, float\[\]\) Method

Calculates the arc cosine \(inverse cosine\) of input values\.

```csharp
public static TechnicalAnalysis.Functions.AcosResult Acos(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input array\.

<a name='TechnicalAnalysis.Functions.TAMath.Acos(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of values \(must be between \-1 and 1\)\.

#### Returns
[AcosResult](AcosResult.md 'TechnicalAnalysis\.Functions\.AcosResult')  
An AcosResult containing the calculated arc cosine values in radians and calculation metadata\.

### Remarks
This overload accepts float arrays and internally converts them to double arrays for calculation\.
See the double array overload for detailed behavior description\.