#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumAnalysis](MomentumAnalysis.md 'TechnicalAnalysis\.Functions\.MomentumAnalysis')

## MomentumAnalysis\.Stoch Method

| Overloads | |
| :--- | :--- |
| [Stoch\(\)](MomentumAnalysis.Stoch.md#TechnicalAnalysis.Functions.MomentumAnalysis.Stoch() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Stoch\(\)') | Calculates the Stochastic Oscillator with default periods \(14, 3, 3\)\. |
| [Stoch\(int, int, int\)](MomentumAnalysis.Stoch.md#TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Stoch\(int, int, int\)') | Calculates the Stochastic Oscillator with custom periods\. |

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Stoch()'></a>

## MomentumAnalysis\.Stoch\(\) Method

Calculates the Stochastic Oscillator with default periods \(14, 3, 3\)\.

```csharp
public TechnicalAnalysis.Functions.MomentumStochResult Stoch();
```

#### Returns
[MomentumStochResult](MomentumStochResult.md 'TechnicalAnalysis\.Functions\.MomentumStochResult')  
A MomentumStochResult containing the calculated Slow %K and Slow %D values\.

### Remarks
The Stochastic Oscillator is a momentum indicator comparing closing price to the price range\.
The standard settings are 14\-period %K, 3\-period Slow %K smoothing, and 3\-period %D\.

Interpretation:
\- Stochastic above 80: Potentially overbought
\- Stochastic below 20: Potentially oversold
\- %K crosses above %D: Bullish signal
\- %K crosses below %D: Bearish signal
\- Divergences between price and Stochastic can indicate reversals

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int)'></a>

## MomentumAnalysis\.Stoch\(int, int, int\) Method

Calculates the Stochastic Oscillator with custom periods\.

```csharp
public TechnicalAnalysis.Functions.MomentumStochResult Stoch(int fastKPeriod, int slowKPeriod, int slowDPeriod);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int).fastKPeriod'></a>

`fastKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %K calculation\. Valid range: 1 to 100000\. Typical: 14\.

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int).slowKPeriod'></a>

`slowKPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Smoothing periods for %K \(to create Slow %K\)\. Valid range: 1 to 100000\. Typical: 3\.

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Stoch(int,int,int).slowDPeriod'></a>

`slowDPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for %D calculation\. Valid range: 1 to 100000\. Typical: 3\.

#### Returns
[MomentumStochResult](MomentumStochResult.md 'TechnicalAnalysis\.Functions\.MomentumStochResult')  
A MomentumStochResult containing the calculated Slow %K and Slow %D values\.

### Remarks
The Stochastic Oscillator calculation:
\- Fast %K = 100 × \(Close \- Lowest Low\) / \(Highest High \- Lowest Low\)
\- Slow %K = Moving Average of Fast %K
\- Slow %D = Moving Average of Slow %K

Key points:
\- Values range from 0 to 100
\- Requires High, Low, and Close price data
\- More responsive than RSI, generating more signals
\- Works well in range\-bound markets

Popular variations:
\- Fast Stochastic \(5, 3, 3\): Very sensitive, many signals
\- Standard Stochastic \(14, 3, 3\): Balanced approach
\- Slow Stochastic \(21, 5, 5\): Smoother, fewer signals