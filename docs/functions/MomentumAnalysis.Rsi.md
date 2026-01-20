#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[MomentumAnalysis](MomentumAnalysis.md 'TechnicalAnalysis\.Functions\.MomentumAnalysis')

## MomentumAnalysis\.Rsi Method

| Overloads | |
| :--- | :--- |
| [Rsi\(\)](MomentumAnalysis.Rsi.md#TechnicalAnalysis.Functions.MomentumAnalysis.Rsi() 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Rsi\(\)') | Calculates the Relative Strength Index \(RSI\) with default period of 14\. |
| [Rsi\(int\)](MomentumAnalysis.Rsi.md#TechnicalAnalysis.Functions.MomentumAnalysis.Rsi(int) 'TechnicalAnalysis\.Functions\.MomentumAnalysis\.Rsi\(int\)') | Calculates the Relative Strength Index \(RSI\) with a custom period\. |

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Rsi()'></a>

## MomentumAnalysis\.Rsi\(\) Method

Calculates the Relative Strength Index \(RSI\) with default period of 14\.

```csharp
public TechnicalAnalysis.Functions.MomentumRsiResult Rsi();
```

#### Returns
[MomentumRsiResult](MomentumRsiResult.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult')  
A MomentumRsiResult containing the calculated RSI values\.

### Remarks
The RSI is a momentum oscillator that measures the speed and magnitude of price changes\.
A 14\-period RSI is the standard setting recommended by its creator, J\. Welles Wilder\.

Interpretation:
\- RSI above 70: Potentially overbought
\- RSI below 30: Potentially oversold
\- RSI at 50: Neutral momentum
\- RSI crossing above 30: Potential buy signal
\- RSI crossing below 70: Potential sell signal

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Rsi(int)'></a>

## MomentumAnalysis\.Rsi\(int\) Method

Calculates the Relative Strength Index \(RSI\) with a custom period\.

```csharp
public TechnicalAnalysis.Functions.MomentumRsiResult Rsi(int period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.MomentumAnalysis.Rsi(int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the RSI calculation\. Valid range: 2 to 100000\. Standard is 14\.

#### Returns
[MomentumRsiResult](MomentumRsiResult.md 'TechnicalAnalysis\.Functions\.MomentumRsiResult')  
A MomentumRsiResult containing the calculated RSI values\.

### Remarks
The RSI compares the magnitude of recent gains to recent losses to determine
overbought and oversold conditions\. RSI values range from 0 to 100\.

Key points:
\- Shorter periods \(9\-11\) are more sensitive and generate more signals
\- Longer periods \(21\-25\) are smoother and generate fewer signals
\- Divergences between price and RSI can indicate potential reversals
\- RSI can remain in overbought/oversold territory for extended periods during strong trends

Common uses:
\- 9 RSI: Short\-term trading
\- 14 RSI: Standard setting
\- 25 RSI: Longer\-term analysis