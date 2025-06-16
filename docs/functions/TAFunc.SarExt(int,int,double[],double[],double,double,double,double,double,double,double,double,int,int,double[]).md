#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[TAFunc](TAFunc.md 'TechnicalAnalysis\.Functions\.TAFunc')

## TAFunc\.SarExt\(int, int, double\[\], double\[\], double, double, double, double, double, double, double, double, int, int, double\[\]\) Method

Calculates the Parabolic SAR \- Extended \(Enhanced SAR with additional parameters for better control\)\.

```csharp
public static TechnicalAnalysis.Common.RetCode SarExt(int startIdx, int endIdx, in double[] inHigh, in double[] inLow, in double optInStartValue, in double optInOffsetOnReverse, double optInAccelerationInitLong, double optInAccelerationLong, in double optInAccelerationMaxLong, double optInAccelerationInitShort, double optInAccelerationShort, in double optInAccelerationMaxShort, ref int outBegIdx, ref int outNBElement, ref double[] outReal);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).startIdx'></a>

`startIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The starting index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).endIdx'></a>

`endIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The ending index for the calculation within the input arrays\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).inHigh'></a>

`inHigh` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of high prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).inLow'></a>

`inLow` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Input array of low prices\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInStartValue'></a>

`optInStartValue` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Initial SAR value\. Use 0 for automatic, positive for long, negative for short\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInOffsetOnReverse'></a>

`optInOffsetOnReverse` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Percentage offset added when SAR reverses\. Typical value: 0\.0\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationInitLong'></a>

`optInAccelerationInitLong` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Initial acceleration factor for long positions\. Typical value: 0\.02\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationLong'></a>

`optInAccelerationLong` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Acceleration increment for long positions\. Typical value: 0\.02\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationMaxLong'></a>

`optInAccelerationMaxLong` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Maximum acceleration factor for long positions\. Typical value: 0\.20\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationInitShort'></a>

`optInAccelerationInitShort` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Initial acceleration factor for short positions\. Typical value: 0\.02\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationShort'></a>

`optInAccelerationShort` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Acceleration increment for short positions\. Typical value: 0\.02\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).optInAccelerationMaxShort'></a>

`optInAccelerationMaxShort` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')

Maximum acceleration factor for short positions\. Typical value: 0\.20\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).outBegIdx'></a>

`outBegIdx` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The index of the first valid output value\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).outNBElement'></a>

`outNBElement` [System\.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System\.Int32')

The number of valid output elements\.

<a name='TechnicalAnalysis.Functions.TAFunc.SarExt(int,int,double[],double[],double,double,double,double,double,double,double,double,int,int,double[]).outReal'></a>

`outReal` [System\.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System\.Double')[\[\]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System\.Array')

Output array for the SAR values \(negative values indicate short position\)\.

#### Returns
[TechnicalAnalysis\.Common\.RetCode](https://docs.microsoft.com/en-us/dotnet/api/TechnicalAnalysis.Common.RetCode 'TechnicalAnalysis\.Common\.RetCode')  
A RetCode indicating the success or failure of the calculation\.

### Remarks
Extended Parabolic SAR provides enhanced control over the standard SAR indicator\.

Key enhancements:
\- Separate acceleration parameters for long and short positions
\- Customizable starting value and direction
\- Optional offset on reversal for reduced whipsaws
\- Negative output values indicate short positions

StartValue parameter:
\- 0: Automatic detection based on price movement
\- Positive: Start with long position at specified SAR value
\- Negative: Start with short position at absolute SAR value

Output interpretation:
\- Positive values: Long position \(SAR below price\)
\- Negative values: Short position \(SAR above price\)
\- Magnitude represents the actual SAR level

The offset parameter adds a percentage buffer when SAR reverses,
helping to reduce false signals in choppy markets\.

This extended version is particularly useful for:
\- Asymmetric market conditions \(different behavior in uptrends vs downtrends\)
\- Fine\-tuning entry/exit levels
\- Reducing whipsaws through the offset parameter