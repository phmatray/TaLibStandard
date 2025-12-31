#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common').[ValidationHelper](ValidationHelper.md 'TechnicalAnalysis\.Common\.ValidationHelper')

## ValidationHelper\.ValidateSingleInputIndicator\(int, int, double\[\], double\[\], Nullable\<int\>, int, int\) Method

Performs comprehensive validation for single\-input indicators\.

```csharp
public static TechnicalAnalysis.Common.RetCode ValidateSingleInputIndicator(int startIdx, int endIdx, double[]? inReal, double[]? outReal, System.Nullable<int> optInTimePeriod=null, int minPeriod=2, int maxPeriod=100000);
```
#### Parameters

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).startIdx'></a>

`startIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index for the calculation\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).endIdx'></a>

`endIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index for the calculation\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).inReal'></a>

`inReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Input array of price data\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).outReal'></a>

`outReal` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Output array for indicator values\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).optInTimePeriod'></a>

`optInTimePeriod` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Optional time period parameter\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).minPeriod'></a>

`minPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Minimum allowed period \(default: 2\)\.

<a name='TechnicalAnalysis.Common.ValidationHelper.ValidateSingleInputIndicator(int,int,double[],double[],System.Nullable_int_,int,int).maxPeriod'></a>

`maxPeriod` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Maximum allowed period \(default: 100000\)\.

#### Returns
[RetCode](RetCode.md 'TechnicalAnalysis\.Common\.RetCode')  
[Success](RetCode.md#TechnicalAnalysis.Common.RetCode.Success 'TechnicalAnalysis\.Common\.RetCode\.Success') if all validations pass;
            appropriate error code otherwise\.