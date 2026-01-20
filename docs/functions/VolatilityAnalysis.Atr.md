#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityAnalysis](VolatilityAnalysis.md 'TechnicalAnalysis\.Functions\.VolatilityAnalysis')

## VolatilityAnalysis\.Atr Method

| Overloads | |
| :--- | :--- |
| [Atr\(\)](VolatilityAnalysis.Atr.md#TechnicalAnalysis.Functions.VolatilityAnalysis.Atr() 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.Atr\(\)') | Calculates the Average True Range \(ATR\) with default period of 14\. |
| [Atr\(int\)](VolatilityAnalysis.Atr.md#TechnicalAnalysis.Functions.VolatilityAnalysis.Atr(int) 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.Atr\(int\)') | Calculates the Average True Range \(ATR\) with a custom period\. |

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.Atr()'></a>

## VolatilityAnalysis\.Atr\(\) Method

Calculates the Average True Range \(ATR\) with default period of 14\.

```csharp
public TechnicalAnalysis.Functions.VolatilityAtrResult Atr();
```

#### Returns
[VolatilityAtrResult](VolatilityAtrResult.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult')  
A VolatilityAtrResult containing the calculated ATR values\.

### Remarks
ATR measures volatility by calculating the average of the True Range over a specified period\.
A 14\-period ATR is the standard setting recommended by its creator, J\. Welles Wilder\.

Interpretation:
\- Higher ATR values indicate higher volatility
\- Lower ATR values indicate lower volatility
\- ATR is non\-directional \(doesn't indicate trend direction\)
\- Rising ATR suggests increasing volatility
\- Falling ATR suggests decreasing volatility

Common uses:
\- Stop\-loss placement: Often placed at 2\-3 ATR from entry
\- Position sizing: Inversely proportional to ATR for risk management
\- Breakout confirmation: Moves exceeding 1\-2 ATR can signal breakouts

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.Atr(int)'></a>

## VolatilityAnalysis\.Atr\(int\) Method

Calculates the Average True Range \(ATR\) with a custom period\.

```csharp
public TechnicalAnalysis.Functions.VolatilityAtrResult Atr(int period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.Atr(int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the ATR calculation\. Valid range: 1 to 100000\. Standard is 14\.

#### Returns
[VolatilityAtrResult](VolatilityAtrResult.md 'TechnicalAnalysis\.Functions\.VolatilityAtrResult')  
A VolatilityAtrResult containing the calculated ATR values\.

### Remarks
ATR measures market volatility by decomposing the entire range of an asset for that period\.
True Range is the greatest of:
\- Current High \- Current Low
\- \|Current High \- Previous Close\|
\- \|Current Low \- Previous Close\|

Key points:
\- Shorter periods \(5\-10\) are more reactive to price changes
\- Longer periods \(20\-50\) provide smoother volatility readings
\- ATR values are in the same units as the price
\- ATR does not indicate price direction, only volatility

Popular variations:
\- 7 ATR: Short\-term volatility
\- 14 ATR: Standard setting
\- 21 ATR: Intermediate\-term volatility