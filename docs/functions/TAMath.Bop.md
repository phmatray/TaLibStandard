#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Bop Method

| Overloads | |
| :--- | :--- |
| [Bop\(int, int, double\[\], double\[\], double\[\], double\[\]\)](TAMath.Bop.md#TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Bop\(int, int, double\[\], double\[\], double\[\], double\[\]\)') | Calculates the Balance of Power \(BOP\) indicator\. |
| [Bop\(int, int, float\[\], float\[\], float\[\], float\[\]\)](TAMath.Bop.md#TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Bop\(int, int, float\[\], float\[\], float\[\], float\[\]\)') | Calculates the Balance of Power \(BOP\) indicator using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[])'></a>

## TAMath\.Bop\(int, int, double\[\], double\[\], double\[\], double\[\]\) Method

Calculates the Balance of Power \(BOP\) indicator\.

```csharp
public static TechnicalAnalysis.Functions.BopResult Bop(int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult')  
A [BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult') object containing the calculated Balance of Power values
and associated metadata\.

### Remarks
The Balance of Power indicator measures the strength of buyers versus sellers by assessing
the ability of each to push price to an extreme level\. BOP = \(Close \- Open\) / \(High \- Low\)\.
Values range from \-1 to \+1, where positive values indicate buying pressure and negative values
indicate selling pressure\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[])'></a>

## TAMath\.Bop\(int, int, float\[\], float\[\], float\[\], float\[\]\) Method

Calculates the Balance of Power \(BOP\) indicator using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.BopResult Bop(int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).open'></a>

`open` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.Bop(int,int,float[],float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult')  
A [BopResult](BopResult.md 'TechnicalAnalysis\.Functions\.BopResult') object containing the calculated Balance of Power values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The Balance of Power indicator measures the strength of buyers versus sellers by assessing
the ability of each to push price to an extreme level\.