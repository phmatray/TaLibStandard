#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.WclPrice Method

| Overloads | |
| :--- | :--- |
| [WclPrice\(int, int, double\[\], double\[\], double\[\]\)](TAMath.WclPrice.md#TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.WclPrice\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the weighted close price of a security for each period\. |
| [WclPrice\(int, int, float\[\], float\[\], float\[\]\)](TAMath.WclPrice.md#TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.WclPrice\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the weighted close price of a security for each period using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[])'></a>

## TAMath\.WclPrice\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the weighted close price of a security for each period\.

```csharp
public static TechnicalAnalysis.Functions.WclPriceResult WclPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult')  
A [WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult') object containing the calculated weighted close price values
and associated metadata\.

### Remarks
The weighted close price is calculated as \(High \+ Low \+ Close \* 2\) / 4 for each period\.
This formula gives extra weight to the closing price, recognizing its importance as the
final agreed\-upon value for the period\. It is often used as an alternative to typical
price when more emphasis on the closing price is desired in technical analysis\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[])'></a>

## TAMath\.WclPrice\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the weighted close price of a security for each period using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.WclPriceResult WclPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.WclPrice(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult')  
A [WclPriceResult](WclPriceResult.md 'TechnicalAnalysis\.Functions\.WclPriceResult') object containing the calculated weighted close price values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The weighted close price is calculated as \(High \+ Low \+ Close \* 2\) / 4 for each period\.