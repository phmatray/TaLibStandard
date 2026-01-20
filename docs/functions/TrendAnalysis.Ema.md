#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrendAnalysis](TrendAnalysis.md 'TechnicalAnalysis\.Functions\.TrendAnalysis')

## TrendAnalysis\.Ema Method

| Overloads | |
| :--- | :--- |
| [Ema\(\)](TrendAnalysis.Ema.md#TechnicalAnalysis.Functions.TrendAnalysis.Ema() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Ema\(\)') | Calculates the Exponential Moving Average \(EMA\) with default period of 20\. |
| [Ema\(int\)](TrendAnalysis.Ema.md#TechnicalAnalysis.Functions.TrendAnalysis.Ema(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Ema\(int\)') | Calculates the Exponential Moving Average \(EMA\) with a custom period\. |

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Ema()'></a>

## TrendAnalysis\.Ema\(\) Method

Calculates the Exponential Moving Average \(EMA\) with default period of 20\.

```csharp
public TechnicalAnalysis.Functions.TrendEmaResult Ema();
```

#### Returns
[TrendEmaResult](TrendEmaResult.md 'TechnicalAnalysis\.Functions\.TrendEmaResult')  
A TrendEmaResult containing the calculated EMA values\.

### Remarks
The EMA reacts more quickly to recent price changes than the SMA\.
A 20\-period EMA is commonly used for short to medium\-term trend identification\.
Price above EMA suggests an uptrend; price below EMA suggests a downtrend\.

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Ema(int)'></a>

## TrendAnalysis\.Ema\(int\) Method

Calculates the Exponential Moving Average \(EMA\) with a custom period\.

```csharp
public TechnicalAnalysis.Functions.TrendEmaResult Ema(int period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Ema(int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the EMA calculation\. Common values: 12, 20, 26, 50, 200\.

#### Returns
[TrendEmaResult](TrendEmaResult.md 'TechnicalAnalysis\.Functions\.TrendEmaResult')  
A TrendEmaResult containing the calculated EMA values\.

### Remarks
The EMA gives more weight to recent prices, making it more responsive to price changes\.
Shorter periods \(12\-20\) are more responsive; longer periods \(50\-200\) are smoother\.

Common uses:
\- 12 EMA: Very short\-term trend
\- 20 EMA: Short\-term trend
\- 50 EMA: Intermediate trend
\- 200 EMA: Long\-term trend