#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

## PriceSeries\.Equals Method

| Overloads | |
| :--- | :--- |
| [Equals\(object\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(object) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(object\)') | Determines whether this price series equals the given object\. |
| [Equals\(PriceSeries\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(TechnicalAnalysis\.Functions\.PriceSeries\)') | Determines whether this price series equals another\. |

<a name='TechnicalAnalysis.Functions.PriceSeries.Equals(object)'></a>

## PriceSeries\.Equals\(object\) Method

Determines whether this price series equals the given object\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when [obj](PriceSeries.md#TechnicalAnalysis.Functions.PriceSeries.Equals(object).obj 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(object\)\.obj') is a [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries') equal to this one
            under [Equals\(PriceSeries\)](PriceSeries.Equals.md#TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries) 'TechnicalAnalysis\.Functions\.PriceSeries\.Equals\(TechnicalAnalysis\.Functions\.PriceSeries\)'); otherwise `false`\.

<a name='TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries)'></a>

## PriceSeries\.Equals\(PriceSeries\) Method

Determines whether this price series equals another\.

```csharp
public bool Equals(TechnicalAnalysis.Functions.PriceSeries other);
```
#### Parameters

<a name='TechnicalAnalysis.Functions.PriceSeries.Equals(TechnicalAnalysis.Functions.PriceSeries).other'></a>

`other` [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')

The series to compare with\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when both series share every component array \<i\>by reference\</i\> and expose the
            same number of bars\.

### Remarks
This does not compare prices\. Two series built from identical inputs are not equal, because
the factories copy and therefore hold different arrays\. Equality exists so that this value
type satisfies CA1815\.