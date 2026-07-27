#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.Empty Property

Gets the empty price series\.

```csharp
public static TechnicalAnalysis.Functions.PriceSeries Empty { get; }
```

#### Property Value
[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')  

A series of zero bars carrying no components at all. Equivalent to
`default(PriceSeries)`, which is what makes it a usable pre-roll state for a field that
is filled in later.

<b>It carries no high, low or volume, so the indicators that need them throw.</b>[Sma\(this PriceSeries, int\)](OverlapStudyIndicators.Sma(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.Sma\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)'), [Ema\(this PriceSeries, int\)](OverlapStudyIndicators.Ema(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.Ema\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)'),
            [BollingerBands\(this PriceSeries, int, double, double, MAType\)](OverlapStudyIndicators.BollingerBands(thisPriceSeries,int,double,double,MAType).md 'TechnicalAnalysis\.Functions\.OverlapStudyIndicators\.BollingerBands\(this TechnicalAnalysis\.Functions\.PriceSeries, int, double, double, TechnicalAnalysis\.Common\.MAType\)'), [Rsi\(this PriceSeries, int\)](MomentumIndicators.Rsi(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Rsi\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)')
            and [Macd\(this PriceSeries, int, int, int\)](MomentumIndicators.Macd(thisPriceSeries,int,int,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Macd\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, int\)') need only closes and return an empty result;
            [Atr\(this PriceSeries, int\)](VolatilityIndicators.Atr(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.VolatilityIndicators\.Atr\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)'), [Adx\(this PriceSeries, int\)](MomentumIndicators.Adx(thisPriceSeries,int).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Adx\(this TechnicalAnalysis\.Functions\.PriceSeries, int\)') and
            [Stoch\(this PriceSeries, int, int, MAType, int, MAType\)](MomentumIndicators.Stoch(thisPriceSeries,int,int,MAType,int,MAType).md 'TechnicalAnalysis\.Functions\.MomentumIndicators\.Stoch\(this TechnicalAnalysis\.Functions\.PriceSeries, int, int, TechnicalAnalysis\.Common\.MAType, int, TechnicalAnalysis\.Common\.MAType\)') raise [System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException') because
            component availability is checked before emptiness, and
            [Obv\(this PriceSeries\)](VolumeIndicators.Obv(thisPriceSeries).md 'TechnicalAnalysis\.Functions\.VolumeIndicators\.Obv\(this TechnicalAnalysis\.Functions\.PriceSeries\)') raises it for the missing volumes. A feed that must
            answer every indicator while it has no bars yet is
            `PriceSeries.FromOhlcv([], [], [], [], [])` — the components are then present and
            merely empty.