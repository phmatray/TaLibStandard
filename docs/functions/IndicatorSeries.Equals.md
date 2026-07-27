#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

## IndicatorSeries\.Equals Method

| Overloads | |
| :--- | :--- |
| [Equals\(object\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(object) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(object\)') | Determines whether this series equals the given object\. |
| [Equals\(IndicatorSeries\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(TechnicalAnalysis\.Functions\.IndicatorSeries\)') | Determines whether this series equals another\. |

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Equals(object)'></a>

## IndicatorSeries\.Equals\(object\) Method

Determines whether this series equals the given object\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when [obj](IndicatorSeries.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(object).obj 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(object\)\.obj') is an [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries') equal to this
            one under [Equals\(IndicatorSeries\)](IndicatorSeries.Equals.md#TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries) 'TechnicalAnalysis\.Functions\.IndicatorSeries\.Equals\(TechnicalAnalysis\.Functions\.IndicatorSeries\)'); otherwise `false`\.

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries)'></a>

## IndicatorSeries\.Equals\(IndicatorSeries\) Method

Determines whether this series equals another\.

```csharp
public bool Equals(TechnicalAnalysis.Functions.IndicatorSeries other);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.IndicatorSeries.Equals(TechnicalAnalysis.Functions.IndicatorSeries).other'></a>

`other` [IndicatorSeries](IndicatorSeries.md 'TechnicalAnalysis\.Functions\.IndicatorSeries')

The series to compare with\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when both series share the same backing array \<i\>by reference\</i\> and agree on
            their first bar, value count, bar count and return code\.

### Remarks
This does \<b\>not\</b\> compare values\. Two series computed separately from identical inputs
are not equal, because they wrap different arrays\. Equality exists so that this value type
satisfies CA1815 and so that [AsOf\(int\)](IndicatorSeries.AsOf(int).md 'TechnicalAnalysis\.Functions\.IndicatorSeries\.AsOf\(int\)') can be recognised as the identity when it
narrows nothing; it is not a numeric comparison\.