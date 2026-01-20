#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrendAnalysis](TrendAnalysis.md 'TechnicalAnalysis\.Functions\.TrendAnalysis')

## TrendAnalysis\.Sma Method

| Overloads | |
| :--- | :--- |
| [Sma\(\)](TrendAnalysis.Sma.md#TechnicalAnalysis.Functions.TrendAnalysis.Sma() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Sma\(\)') | Calculates the Simple Moving Average \(SMA\) with default period of 50\. |
| [Sma\(int\)](TrendAnalysis.Sma.md#TechnicalAnalysis.Functions.TrendAnalysis.Sma(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Sma\(int\)') | Calculates the Simple Moving Average \(SMA\) with a custom period\. |

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Sma()'></a>

## TrendAnalysis\.Sma\(\) Method

Calculates the Simple Moving Average \(SMA\) with default period of 50\.

```csharp
public TechnicalAnalysis.Functions.TrendSmaResult Sma();
```

#### Returns
[TrendSmaResult](TrendSmaResult.md 'TechnicalAnalysis\.Functions\.TrendSmaResult')  
A TrendSmaResult containing the calculated SMA values\.

### Remarks
The SMA provides a smooth average of prices, less sensitive to short\-term fluctuations\.
A 50\-period SMA is commonly used for medium\-term trend identification\.
Price above SMA suggests an uptrend; price below SMA suggests a downtrend\.

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Sma(int)'></a>

## TrendAnalysis\.Sma\(int\) Method

Calculates the Simple Moving Average \(SMA\) with a custom period\.

```csharp
public TechnicalAnalysis.Functions.TrendSmaResult Sma(int period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Sma(int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the SMA calculation\. Common values: 20, 50, 100, 200\.

#### Returns
[TrendSmaResult](TrendSmaResult.md 'TechnicalAnalysis\.Functions\.TrendSmaResult')  
A TrendSmaResult containing the calculated SMA values\.

### Remarks
The SMA calculates the arithmetic mean of prices over the specified period\.
It provides smoother trend identification but lags more than the EMA\.

Common uses:
\- 20 SMA: Short\-term trend
\- 50 SMA: Medium\-term trend
\- 100 SMA: Intermediate trend
\- 200 SMA: Long\-term trend \(major support/resistance\)

Popular patterns:
\- Golden Cross: 50 SMA crosses above 200 SMA \(bullish\)
\- Death Cross: 50 SMA crosses below 200 SMA \(bearish\)