#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.Roc Method

| Overloads | |
| :--- | :--- |
| [Roc\(int, int, double\[\], int\)](TAMath.Roc.md#TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Roc\(int, int, double\[\], int\)') | Calculates the Rate of Change \(ROC\) indicator for the specified range of data\. |
| [Roc\(int, int, double\[\]\)](TAMath.Roc.md#TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.Roc\(int, int, double\[\]\)') | Calculates the Rate of Change \(ROC\) indicator using a default period of 10\. |
| [Roc\(int, int, float\[\], int\)](TAMath.Roc.md#TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.Roc\(int, int, float\[\], int\)') | Calculates the Rate of Change \(ROC\) indicator for float input data\. |
| [Roc\(int, int, float\[\]\)](TAMath.Roc.md#TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.Roc\(int, int, float\[\]\)') | Calculates the Rate of Change \(ROC\) indicator for float input data using a default period of 10\. |

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int)'></a>

## TAMath\.Roc\(int, int, double\[\], int\) Method

Calculates the Rate of Change \(ROC\) indicator for the specified range of data\.

```csharp
public static TechnicalAnalysis.Functions.RocResult Roc(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the ROC calculation\. Default is 10\.

#### Returns
[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')  
A RocResult object containing the calculated values and metadata\.

### Remarks
The Rate of Change \(ROC\) indicator measures the percentage change in price between the current
price and the price n periods ago\. The formula is: ROC = \(\(current price \- price n periods ago\) / 
price n periods ago\) \* 100\. This momentum oscillator is useful for identifying overbought and
oversold conditions, as well as confirming price trends and spotting divergences\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[])'></a>

## TAMath\.Roc\(int, int, double\[\]\) Method

Calculates the Rate of Change \(ROC\) indicator using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocResult Roc(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values\.

#### Returns
[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')  
A RocResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int)'></a>

## TAMath\.Roc\(int, int, float\[\], int\) Method

Calculates the Rate of Change \(ROC\) indicator for float input data\.

```csharp
public static TechnicalAnalysis.Functions.RocResult Roc(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the ROC calculation\.

#### Returns
[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')  
A RocResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[])'></a>

## TAMath\.Roc\(int, int, float\[\]\) Method

Calculates the Rate of Change \(ROC\) indicator for float input data using a default period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocResult Roc(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.Roc(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

The input data array containing price values as floats\.

#### Returns
[RocResult](RocResult.md 'TechnicalAnalysis\.Functions\.RocResult')  
A RocResult object containing the calculated values and metadata\.

### Remarks
This overload converts the float array to double array before performing the calculation,
as the underlying TAFunc library operates on double precision values\.