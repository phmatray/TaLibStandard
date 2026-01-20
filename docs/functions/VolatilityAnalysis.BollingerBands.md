#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[VolatilityAnalysis](VolatilityAnalysis.md 'TechnicalAnalysis\.Functions\.VolatilityAnalysis')

## VolatilityAnalysis\.BollingerBands Method

| Overloads | |
| :--- | :--- |
| [BollingerBands\(\)](VolatilityAnalysis.BollingerBands.md#TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands() 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.BollingerBands\(\)') | Calculates Bollinger Bands with default settings \(20 period, 2\.0 standard deviations, SMA\)\. |
| [BollingerBands\(int, double, double, MAType\)](VolatilityAnalysis.BollingerBands.md#TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType) 'TechnicalAnalysis\.Functions\.VolatilityAnalysis\.BollingerBands\(int, double, double, TechnicalAnalysis\.Common\.MAType\)') | Calculates Bollinger Bands with custom settings\. |

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands()'></a>

## VolatilityAnalysis\.BollingerBands\(\) Method

Calculates Bollinger Bands with default settings \(20 period, 2\.0 standard deviations, SMA\)\.

```csharp
public TechnicalAnalysis.Functions.VolatilityBollingerBandsResult BollingerBands();
```

#### Returns
[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')  
A VolatilityBollingerBandsResult containing the upper band, middle band, and lower band values\.

### Remarks
Bollinger Bands create an envelope around price based on standard deviations from a moving average\.
The standard settings are 20\-period SMA with ±2 standard deviations\.

Interpretation:
\- Price touching upper band: Potentially overbought
\- Price touching lower band: Potentially oversold
\- Bands expanding: Increasing volatility
\- Bands contracting: Decreasing volatility \(consolidation\)
\- Bollinger Squeeze: Very narrow bands often precede significant moves

Common uses:
\- Identifying overbought/oversold levels
\- Detecting volatility changes
\- Spotting potential reversals
\- Setting dynamic support/resistance levels

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType)'></a>

## VolatilityAnalysis\.BollingerBands\(int, double, double, MAType\) Method

Calculates Bollinger Bands with custom settings\.

```csharp
public TechnicalAnalysis.Functions.VolatilityBollingerBandsResult BollingerBands(int period, double nbDevUp, double nbDevDn, TechnicalAnalysis.Common.MAType maType=TechnicalAnalysis.Common.MAType.Sma);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType).period'></a>

`period` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Number of periods for the moving average calculation\. Valid range: 2 to 100000\. Typical: 20\.

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType).nbDevUp'></a>

`nbDevUp` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Number of standard deviations for the upper band\. Valid range: \-3\.0e37 to 3\.0e37\. Typical: 2\.0\.

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType).nbDevDn'></a>

`nbDevDn` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Number of standard deviations for the lower band\. Valid range: \-3\.0e37 to 3\.0e37\. Typical: 2\.0\.

<a name='TechnicalAnalysis.Functions.VolatilityAnalysis.BollingerBands(int,double,double,TechnicalAnalysis.Common.MAType).maType'></a>

`maType` [TechnicalAnalysis\.Common\.MAType](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.matype 'TechnicalAnalysis\.Common\.MAType')

Type of moving average to use \(SMA, EMA, etc\.\)\. Default: SMA\.

#### Returns
[VolatilityBollingerBandsResult](VolatilityBollingerBandsResult.md 'TechnicalAnalysis\.Functions\.VolatilityBollingerBandsResult')  
A VolatilityBollingerBandsResult containing the upper band, middle band, and lower band values\.

### Remarks
Bollinger Bands consist of three lines:
\- Upper Band = Moving Average \+ \(Standard Deviation × nbDevUp\)
\- Middle Band = Moving Average \(typically 20\-period SMA\)
\- Lower Band = Moving Average \- \(Standard Deviation × nbDevDn\)

Key points:
\- Shorter periods \(10\-15\) are more reactive and generate more signals
\- Longer periods \(30\-50\) are smoother and generate fewer signals
\- Higher deviation values \(2\.5\-3\.0\) create wider bands \(fewer touches\)
\- Lower deviation values \(1\.5\-1\.8\) create narrower bands \(more touches\)
\- Different MA types \(EMA vs SMA\) affect band sensitivity

Advanced concepts:
\- Band width can be calculated as \(Upper Band \- Lower Band\) / Middle Band
\- %B indicator = \(Close \- Lower Band\) / \(Upper Band \- Lower Band\)
\- Price can remain at band extremes during strong trends
\- M\-top and W\-bottom patterns form at the bands

Popular variations:
\- Conservative \(20, 2\.5, 2\.5\): Wider bands, fewer signals
\- Standard \(20, 2\.0, 2\.0\): Balanced approach
\- Aggressive \(20, 1\.5, 1\.5\): Narrower bands, more signals
\- Short\-term \(10, 1\.9, 1\.9\): For day trading