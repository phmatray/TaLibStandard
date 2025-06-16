#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.MedPrice Method

| Overloads | |
| :--- | :--- |
| [MedPrice\(int, int, double\[\], double\[\]\)](TAMath.MedPrice.md#TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.MedPrice\(int, int, double\[\], double\[\]\)') | Calculates the median price of a security for each period\. |
| [MedPrice\(int, int, float\[\], float\[\]\)](TAMath.MedPrice.md#TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.MedPrice\(int, int, float\[\], float\[\]\)') | Calculates the median price of a security for each period using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[])'></a>

## TAMath\.MedPrice\(int, int, double\[\], double\[\]\) Method

Calculates the median price of a security for each period\.

```csharp
public static TechnicalAnalysis.Functions.MedPriceResult MedPrice(int startIdx, int endIdx, double[] high, double[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult')  
A [MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult') object containing the calculated median price values
and associated metadata\.

### Remarks
The median price is calculated as \(High \+ Low\) / 2 for each period\. This provides
a simple mid\-point price that represents the center of the trading range for each period\.
It is often used as a simplified price input for other indicators or as a basic
representation of price levels that filters out opening and closing price gaps\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[])'></a>

## TAMath\.MedPrice\(int, int, float\[\], float\[\]\) Method

Calculates the median price of a security for each period using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.MedPriceResult MedPrice(int startIdx, int endIdx, float[] high, float[] low);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.MedPrice(int,int,float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

#### Returns
[MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult')  
A [MedPriceResult](MedPriceResult.md 'TechnicalAnalysis\.Functions\.MedPriceResult') object containing the calculated median price values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The median price is calculated as \(High \+ Low\) / 2 for each period\.