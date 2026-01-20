#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## CandleIndicator\<T\> Class

Represents an abstract base class for candlestick pattern recognition indicators\.

```csharp
public abstract class CandleIndicator<T>
    where T : IFloatingPoint<T>
```
#### Type parameters

<a name='TechnicalAnalysis.Common.CandleIndicator_T_.T'></a>

`T`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CandleIndicator\<T\>

| Constructors | |
| :--- | :--- |
| [CandleIndicator\(T\[\], T\[\], T\[\], T\[\]\)](CandleIndicator_T_.CandleIndicator(T[],T[],T[],T[]).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.CandleIndicator\(T\[\], T\[\], T\[\], T\[\]\)') | Initializes a new instance of the CandleIndicator class\. |

| Properties | |
| :--- | :--- |
| [Close](CandleIndicator_T_.Close.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.Close') | An array of close prices\. |
| [High](CandleIndicator_T_.High.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.High') | An array of high prices\. |
| [Low](CandleIndicator_T_.Low.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.Low') | An array of low prices\. |
| [Open](CandleIndicator_T_.Open.md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.Open') | An array of open prices\. |

| Methods | |
| :--- | :--- |
| [GetCandleAverage\(CandleSettingType, T, int\)](CandleIndicator_T_.GetCandleAverage(CandleSettingType,T,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleAverage\(TechnicalAnalysis\.Common\.CandleSettingType, T, int\)') | Gets the candle average of the specified candle setting at a specific index\. |
| [GetCandleAvgPeriod\(CandleSettingType\)](CandleIndicator_T_.GetCandleAvgPeriod(CandleSettingType).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleAvgPeriod\(TechnicalAnalysis\.Common\.CandleSettingType\)') | Gets the average period of the specified candle setting\. |
| [GetCandleColor\(int\)](CandleIndicator_T_.GetCandleColor(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleColor\(int\)') | Gets the color of the candle at a specific index\. |
| [GetCandleFactor\(CandleSettingType\)](CandleIndicator_T_.GetCandleFactor(CandleSettingType).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleFactor\(TechnicalAnalysis\.Common\.CandleSettingType\)') | Gets the factor of the specified candle setting\. |
| [GetCandleGapDown\(int, int\)](CandleIndicator_T_.GetCandleGapDown(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleGapDown\(int, int\)') | Checks if there is a candle gap down between two candles\. |
| [GetCandleGapUp\(int, int\)](CandleIndicator_T_.GetCandleGapUp(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleGapUp\(int, int\)') | Checks if there is a candle gap up between two candles\. |
| [GetCandleMaxAvgPeriod\(CandleSettingType\[\]\)](CandleIndicator_T_.GetCandleMaxAvgPeriod(CandleSettingType[]).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleMaxAvgPeriod\(TechnicalAnalysis\.Common\.CandleSettingType\[\]\)') | Gets the maximum average period among the specified candle settings\. |
| [GetCandleRange\(CandleSettingType, int\)](CandleIndicator_T_.GetCandleRange(CandleSettingType,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleRange\(TechnicalAnalysis\.Common\.CandleSettingType, int\)') | Gets the candle range of the specified candle setting at a specific index\. |
| [GetCandleRangeType\(CandleSettingType\)](CandleIndicator_T_.GetCandleRangeType(CandleSettingType).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetCandleRangeType\(TechnicalAnalysis\.Common\.CandleSettingType\)') | Gets the range type of the specified candle setting\. |
| [GetHighLowRange\(int\)](CandleIndicator_T_.GetHighLowRange(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetHighLowRange\(int\)') | Gets the high\-low range of the candle at a specific index\. |
| [GetLookback\(\)](CandleIndicator_T_.GetLookback().md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetLookback\(\)') | Returns the lookback period for the indicator\. |
| [GetLowerShadow\(int\)](CandleIndicator_T_.GetLowerShadow(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetLowerShadow\(int\)') | Gets the lower shadow of the candle at a specific index\. |
| [GetPatternRecognition\(int\)](CandleIndicator_T_.GetPatternRecognition(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetPatternRecognition\(int\)') | Checks if the pattern is recognized at a specific index\. |
| [GetRealBody\(int\)](CandleIndicator_T_.GetRealBody(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetRealBody\(int\)') | Gets the real body of the candle at a specific index\. |
| [GetRealBodyGapDown\(int, int\)](CandleIndicator_T_.GetRealBodyGapDown(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetRealBodyGapDown\(int, int\)') | Checks if there is a real body gap down between two candles\. |
| [GetRealBodyGapUp\(int, int\)](CandleIndicator_T_.GetRealBodyGapUp(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetRealBodyGapUp\(int, int\)') | Checks if there is a real body gap up between two candles\. |
| [GetUpperShadow\(int\)](CandleIndicator_T_.GetUpperShadow(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.GetUpperShadow\(int\)') | Gets the upper shadow of the candle at a specific index\. |
| [IsColorGreen\(int\)](CandleIndicator_T_.IsColorGreen(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.IsColorGreen\(int\)') | |
| [IsColorOpposite\(int, int\)](CandleIndicator_T_.IsColorOpposite(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.IsColorOpposite\(int, int\)') | |
| [IsColorRed\(int\)](CandleIndicator_T_.IsColorRed(int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.IsColorRed\(int\)') | |
| [IsColorSame\(int, int\)](CandleIndicator_T_.IsColorSame(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.IsColorSame\(int, int\)') | |
| [PrepareOutput\(int, int\)](CandleIndicator_T_.PrepareOutput(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.PrepareOutput\(int, int\)') | Prepares the output variables\. |
| [ValidateIndices\(int, int\)](CandleIndicator_T_.ValidateIndices(int,int).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.ValidateIndices\(int, int\)') | Validates the specified indices\. |
| [ValidateParameters\(T\)](CandleIndicator_T_.ValidateParameters(T).md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.ValidateParameters\(T\)') | Validates the specified parameters\. |
| [ValidatePriceArrays\(\)](CandleIndicator_T_.ValidatePriceArrays().md 'TechnicalAnalysis\.Common\.CandleIndicator\<T\>\.ValidatePriceArrays\(\)') | Validates the price arrays\. |
