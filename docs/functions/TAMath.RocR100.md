#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.RocR100 Method

| Overloads | |
| :--- | :--- |
| [RocR100\(int, int, double\[\], int\)](TAMath.RocR100.md#TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocR100\(int, int, double\[\], int\)') | Calculates the Rate of Change Ratio 100 scale \(ROCR100\) which measures price momentum as a percentage\. |
| [RocR100\(int, int, float\[\], int\)](TAMath.RocR100.md#TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int) 'TechnicalAnalysis\.Functions\.TAMath\.RocR100\(int, int, float\[\], int\)') | Calculates the Rate of Change Ratio 100 scale \(ROCR100\) for float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int)'></a>

## TAMath\.RocR100\(int, int, double\[\], int\) Method

Calculates the Rate of Change Ratio 100 scale \(ROCR100\) which measures price momentum as a percentage\.

```csharp
public static TechnicalAnalysis.Functions.RocR100Result RocR100(int startIdx, int endIdx, double[] real, int timePeriod=10);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int).real'></a>

`real` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,double[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 10\)\.

#### Returns
[RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result')  
A RocR100Result object containing the calculated values and metadata\.

### Remarks
The Rate of Change Ratio 100 scale \(ROCR100\) is a momentum oscillator that measures the percentage
change in price from n periods ago, scaled by 100\. It is calculated as: \(\(Current Price / Price n periods ago\) \* 100\)\.
Values above 100 indicate upward momentum, while values below 100 indicate downward momentum\.
A value of 100 indicates no change\. This is essentially ROCR multiplied by 100 for easier interpretation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int)'></a>

## TAMath\.RocR100\(int, int, float\[\], int\) Method

Calculates the Rate of Change Ratio 100 scale \(ROCR100\) for float arrays\.

```csharp
public static TechnicalAnalysis.Functions.RocR100Result RocR100(int startIdx, int endIdx, float[] real, int timePeriod=10);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int).real'></a>

`real` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of input values \(typically closing prices\)\.

<a name='TechnicalAnalysis.Functions.TAMath.RocR100(int,int,float[],int).timePeriod'></a>

`timePeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of periods to use in the calculation \(default: 10\)\.

#### Returns
[RocR100Result](RocR100Result.md 'TechnicalAnalysis\.Functions\.RocR100Result')  
A RocR100Result object containing the calculated values and metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
This ensures compatibility with data sources that provide float precision while maintaining accuracy
in the calculations\.