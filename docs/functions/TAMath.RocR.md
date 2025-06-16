#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.RocR Method

| Overloads | |
| :--- | :--- |
| [RocR\(int, int, double\[\], int\)](TAMath.RocR.md#TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocR\(int, int, double\[\], int\)') | Calculates the Rate of Change Ratio \(ROCR\) which measures price momentum as a ratio\. |
| [RocR\(int, int, double\[\]\)](TAMath.RocR.md#TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[]) 'TechnicalAnalysis\.Functions\.TAMath\.RocR\(int, int, double\[\]\)') | Calculates the Rate of Change Ratio \(ROCR\) using a default time period of 10\. |
| [RocR\(int, int, float\[\], int\)](TAMath.RocR.md#TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocR\(int, int, float\[\], int\)') | Calculates the Rate of Change Ratio \(ROCR\) for float arrays\. |
| [RocR\(int, int, float\[\]\)](TAMath.RocR.md#TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[]) 'TechnicalAnalysis\.Functions\.TAMath\.RocR\(int, int, float\[\]\)') | Calculates the Rate of Change Ratio \(ROCR\) for float arrays using a default time period of 10\. |

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int)'></a>

## TAMath\.RocR\(int, int, double\[\], int\) Method

Calculates the Rate of Change Ratio \(ROCR\) which measures price momentum as a ratio\.

```csharp
public static TechnicalAnalysis.Functions.RocRResult RocR(int startIdx, int endIdx, double[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 10\)\.

#### Returns
[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')  
A RocRResult object containing the calculated values and metadata\.

### Remarks
The Rate of Change Ratio \(ROCR\) is a momentum oscillator that measures the ratio of the current
price to the price n periods ago\. It is calculated as: \(Current Price / Price n periods ago\)\.
Values above 1\.0 indicate upward momentum, while values below 1\.0 indicate downward momentum\.
This differs from ROC which expresses the change as a percentage\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[])'></a>

## TAMath\.RocR\(int, int, double\[\]\) Method

Calculates the Rate of Change Ratio \(ROCR\) using a default time period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocRResult RocR(int startIdx, int endIdx, double[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,double[]).real'></a>

`real` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(typically closing prices\)\.

#### Returns
[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')  
A RocRResult object containing the calculated values and metadata\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int)'></a>

## TAMath\.RocR\(int, int, float\[\], int\) Method

Calculates the Rate of Change Ratio \(ROCR\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.RocRResult RocR(int startIdx, int endIdx, float[] real, int timePeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of periods to use in the calculation \(default: 10\)\.

#### Returns
[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')  
A RocRResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[])'></a>

## TAMath\.RocR\(int, int, float\[\]\) Method

Calculates the Rate of Change Ratio \(ROCR\) for float arrays using a default time period of 10\.

```csharp
public static TechnicalAnalysis.Functions.RocRResult RocR(int startIdx, int endIdx, float[] real);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR(int,int,float[]).real'></a>

`real` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of input values \(typically closing prices\)\.

#### Returns
[RocRResult](RocRResult.md 'TechnicalAnalysis\.Functions\.RocRResult')  
A RocRResult object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.