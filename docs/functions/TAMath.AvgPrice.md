#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAMath](TAMath.md 'TechnicalAnalysis\.Functions\.TAMath')

## TAMath\.AvgPrice Method

| Overloads | |
| :--- | :--- |
| [AvgPrice\(int, int, double\[\], double\[\], double\[\], double\[\]\)](TAMath.AvgPrice.md#TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]) 'TechnicalAnalysis\.Functions\.TAMath\.AvgPrice\(int, int, double\[\], double\[\], double\[\], double\[\]\)') | Calculates the average price of a security for each period\. |
| [AvgPrice\(int, int, float\[\], float\[\], float\[\], float\[\]\)](TAMath.AvgPrice.md#TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]) 'TechnicalAnalysis\.Functions\.TAMath\.AvgPrice\(int, int, float\[\], float\[\], float\[\], float\[\]\)') | Calculates the average price of a security for each period using float arrays\. |

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[])'></a>

## TAMath\.AvgPrice\(int, int, double\[\], double\[\], double\[\], double\[\]\) Method

Calculates the average price of a security for each period\.

```csharp
public static TechnicalAnalysis.Functions.AvgPriceResult AvgPrice(int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).open'></a>

`open` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).high'></a>

`high` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).low'></a>

`low` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,double[],double[],double[],double[]).close'></a>

`close` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult')  
An [AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult') object containing the calculated average price values
and associated metadata\.

### Remarks
The average price is calculated as \(Open \+ High \+ Low \+ Close\) / 4 for each period\.
This provides a single representative price value that considers all four price points
within a trading period\. It is often used as a smoothed price input for other technical
indicators or as a simple representation of the period's trading activity\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[])'></a>

## TAMath\.AvgPrice\(int, int, float\[\], float\[\], float\[\], float\[\]\) Method

Calculates the average price of a security for each period using float arrays\.

```csharp
public static TechnicalAnalysis.Functions.AvgPriceResult AvgPrice(int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation range\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).open'></a>

`open` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of opening prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).high'></a>

`high` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of high prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).low'></a>

`low` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of low prices\.

<a name='TechnicalAnalysis.Functions.TAMath.AvgPrice(int,int,float[],float[],float[],float[]).close'></a>

`close` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Array of closing prices\.

#### Returns
[AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult')  
An [AvgPriceResult](AvgPriceResult.md 'TechnicalAnalysis\.Functions\.AvgPriceResult') object containing the calculated average price values
and associated metadata\.

### Remarks
This overload accepts float arrays and converts them to double arrays before performing the calculation\.
The average price is calculated as \(Open \+ High \+ Low \+ Close\) / 4 for each period\.