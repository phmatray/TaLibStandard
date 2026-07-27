#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.Create\(RetCode, int, int, double\[\], int\) Method

Creates a bar\-aligned series from the raw metadata of a TA\-Lib call\. This is the only point
in the library at which raw TA\-Lib alignment metadata enters the type system\.

```csharp
public static TechnicalAnalysis.Functions.IndicatorSeries Create(TechnicalAnalysis.Common.RetCode retCode, int begIdx, int nbElement, double[] values, int barCount);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).retCode'></a>

`retCode` [TechnicalAnalysis\.Common\.RetCode](https://learn.microsoft.com/en-us/dotnet/api/technicalanalysis.common.retcode 'TechnicalAnalysis\.Common\.RetCode')

The return code reported by the TA\-Lib call\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).begIdx'></a>

`begIdx` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

TA\-Lib's `BegIdx`: the BAR index described by output array element `0`\. It is not
examined at all when [nbElement](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).nbElement 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.nbElement') is zero, because TA\-Lib reports
`BegIdx == 0` in that state and the value is meaningless\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).nbElement'></a>

`nbElement` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

TA\-Lib's `NBElement`: the number of elements it actually wrote, starting at ARRAY index
`0`\. This is a count, not an index\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).values'></a>

`values` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The raw output array\. Its first [nbElement](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).nbElement 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.nbElement') elements are \<b\>copied\</b\>, so
the caller keeps sole ownership of the array it passed and may mutate it afterwards without
affecting the series that was handed back\. That is what makes the immutability of this type
unconditional rather than a convention the caller has to honour\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).barCount'></a>

`barCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of bars in the source price series\.

#### Returns
[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')  
A series in which every position is addressed by BAR index\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[values](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).values 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.values') is `null`\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[begIdx](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).begIdx 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.begIdx'), [nbElement](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).nbElement 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.nbElement') or [barCount](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).barCount 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.barCount') is negative\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[nbElement](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).nbElement 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.nbElement') exceeds the length of [values](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).values 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.values'), or
            `begIdx + nbElement` exceeds [barCount](IndicatorSeries.Create(RetCode,int,int,double[],int).md#TechnicalAnalysis.Functions.IndicatorSeries.Create(TechnicalAnalysis.Common.RetCode,int,int,double[],int).barCount 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Create\(TechnicalAnalysis\.Common\.RetCode, int, int, double\[\], int\)\.barCount')\. The second check enforces
            TA\-Lib's own invariant: the last described bar is `begIdx + nbElement - 1`, which must
            fall inside the source series\. A result that violates it is misaligned at its source, and
            clamping it here would produce a silently shifted series — precisely the failure this type
            exists to prevent — so it is surfaced loudly instead\.