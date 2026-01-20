#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TrendAnalysis](TrendAnalysis.md 'TechnicalAnalysis\.Functions\.TrendAnalysis')

## TrendAnalysis\.Adx Method

| Overloads | |
| :--- | :--- |
| [Adx\(\)](TrendAnalysis.Adx.md#TechnicalAnalysis.Functions.TrendAnalysis.Adx() 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Adx\(\)') | Calculates the Average Directional Index \(ADX\) with default period of 14\. |
| [Adx\(int\)](TrendAnalysis.Adx.md#TechnicalAnalysis.Functions.TrendAnalysis.Adx(int) 'TechnicalAnalysis\.Functions\.TrendAnalysis\.Adx\(int\)') | Calculates the Average Directional Index \(ADX\) with a custom period\. |

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Adx()'></a>

## TrendAnalysis\.Adx\(\) Method

Calculates the Average Directional Index \(ADX\) with default period of 14\.

```csharp
public TechnicalAnalysis.Functions.TrendAdxResult Adx();
```

#### Returns
[TrendAdxResult](TrendAdxResult.md 'TechnicalAnalysis\.Functions\.TrendAdxResult')  
A TrendAdxResult containing the calculated ADX values\.

### Remarks
The ADX measures trend strength regardless of direction\.
A 14\-period ADX is the standard setting recommended by its creator, Welles Wilder\.

Interpretation:
\- ADX below 20: Weak or no trend \(range\-bound market\)
\- ADX 20\-25: Emerging trend
\- ADX above 25: Strong trend
\- ADX above 40: Very strong trend
\- ADX above 50: Extremely strong trend

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Adx(int)'></a>

## TrendAnalysis\.Adx\(int\) Method

Calculates the Average Directional Index \(ADX\) with a custom period\.

```csharp
public TechnicalAnalysis.Functions.TrendAdxResult Adx(int period);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TrendAnalysis.Adx(int).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the ADX calculation\. Valid range: 2 to 100000\. Standard is 14\.

#### Returns
[TrendAdxResult](TrendAdxResult.md 'TechnicalAnalysis\.Functions\.TrendAdxResult')  
A TrendAdxResult containing the calculated ADX values\.

### Remarks
The ADX quantifies trend strength without indicating direction\.
It requires High, Low, and Close price data\.

Key points:
\- Higher ADX values indicate stronger trends
\- Lower ADX values indicate weaker trends or consolidation
\- ADX does not indicate if the trend is bullish or bearish
\- Rising ADX suggests strengthening trend; falling ADX suggests weakening trend
\- Crossovers of ADX with threshold levels \(20, 25, 40\) provide trading signals