#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.TypPrice Method

| Overloads | |
| :--- | :--- |
| [TypPrice\(int, int, double\[\], double\[\], double\[\]\)](TAMath.TypPrice.md#TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.TypPrice\(int, int, double\[\], double\[\], double\[\]\)') | Calculates the typical price of a security for each period\. |
| [TypPrice\(int, int, float\[\], float\[\], float\[\]\)](TAMath.TypPrice.md#TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.TypPrice\(int, int, float\[\], float\[\], float\[\]\)') | Calculates the typical price of a security for each period using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[])'></a>

## TAMath\.TypPrice\(int, int, double\[\], double\[\], double\[\]\) Method

Calculates the typical price of a security for each period\.

```csharp
public static TechnicalAnalysis.Functions.TypPriceResult TypPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]).high'></a>

`high` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]).low'></a>

`low` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,double[],double[],double[]).close'></a>

`close` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult')  
A [TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult') object containing the calculated typical price values
and associated metadata\.

### Remarks
The typical price is calculated as \(High \+ Low \+ Close\) / 3 for each period\. This price
is considered more representative than just the closing price as it takes into account
the period's trading range\. It is commonly used as input for other technical indicators
such as Money Flow Index and Commodity Channel Index\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[])'></a>

## TAMath\.TypPrice\(int, int, float\[\], float\[\], float\[\]\) Method

Calculates the typical price of a security for each period using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.TypPriceResult TypPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]).high'></a>

`high` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]).low'></a>

`low` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.TypPrice(int,int,float[],float[],float[]).close'></a>

`close` [System\.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System\.Single')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Array of closing prices\.

#### Returns
[TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult')  
A [TypPriceResult](TypPriceResult.md 'TechnicalAnalysis\.Functions\.TypPriceResult') object containing the calculated typical price values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The typical price is calculated as \(High \+ Low \+ Close\) / 3 for each period\.