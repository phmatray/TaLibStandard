#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumAnalysis](MomentumAnalysis.md 'TechnicalAnalysis\.Functions\.MomentumAnalysis')

## MomentumAnalysis\.Macd Method

| Overloads | |
| :--- | :--- |
| [Macd\(\)](MomentumAnalysis.Macd.md#TechnicalAnalysis.Functions.MomentumAnalysis.Macd() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Macd\(\)') | Calculates the Moving Average Convergence Divergence \(MACD\) with default periods \(12, 26, 9\)\. |
| [Macd\(int, int, int\)](MomentumAnalysis.Macd.md#TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Macd\(int, int, int\)') | Calculates the Moving Average Convergence Divergence \(MACD\) with custom periods\. |

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Macd()'></a>

## MomentumAnalysis\.Macd\(\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) with default periods \(12, 26, 9\)\.

```csharp
public TechnicalAnalysis.Functions.MomentumMacdResult Macd();
```

#### Returns
[MomentumMacdResult](MomentumMacdResult.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult')  
A MomentumMacdResult containing the calculated MACD line, signal line, and histogram values\.

### Remarks
MACD is a trend\-following momentum indicator that shows the relationship between two moving averages\.
The standard settings are 12\-period fast EMA, 26\-period slow EMA, and 9\-period signal line\.

Interpretation:
\- MACD line crosses above signal line: Bullish signal
\- MACD line crosses below signal line: Bearish signal
\- MACD crosses above zero: Bullish momentum
\- MACD crosses below zero: Bearish momentum
\- Histogram expanding: Increasing momentum
\- Histogram contracting: Decreasing momentum

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int)'></a>

## MomentumAnalysis\.Macd\(int, int, int\) Method

Calculates the Moving Average Convergence Divergence \(MACD\) with custom periods\.

```csharp
public TechnicalAnalysis.Functions.MomentumMacdResult Macd(int fastPeriod, int slowPeriod, int signalPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int).fastPeriod'></a>

`fastPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the fast EMA\. Valid range: 2 to 100000\. Typical: 12\.

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int).slowPeriod'></a>

`slowPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the slow EMA\. Valid range: 2 to 100000\. Typical: 26\.

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Macd(int,int,int).signalPeriod'></a>

`signalPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the signal line EMA\. Valid range: 1 to 100000\. Typical: 9\.

#### Returns
[MomentumMacdResult](MomentumMacdResult.md 'TechnicalAnalysis\.Functions\.MomentumMacdResult')  
A MomentumMacdResult containing the calculated MACD line, signal line, and histogram values\.

### Remarks
MACD consists of three components:
\- MACD Line = Fast EMA \- Slow EMA
\- Signal Line = EMA of MACD Line
\- MACD Histogram = MACD Line \- Signal Line

Key points:
\- Shorter periods make MACD more sensitive and generate more signals
\- Longer periods make MACD smoother and generate fewer signals
\- Divergences between price and MACD can indicate potential reversals
\- MACD works best in trending markets

Popular variations:
\- Fast settings \(5, 13, 5\): More responsive, more false signals
\- Standard settings \(12, 26, 9\): Balanced approach
\- Slow settings \(19, 39, 9\): More reliable, slower to react