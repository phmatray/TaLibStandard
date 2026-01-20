#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## PriceData Class

Encapsulates price data for technical analysis operations\.

```csharp
public record PriceData
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.IEquatable](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable 'System\.IEquatable') &#129106; PriceData

| Constructors | |
| :--- | :--- |
| [PriceData\(double\[\], double\[\], double\[\], double\[\], double\[\]\)](PriceData.PriceData(double[],double[],double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.PriceData\.PriceData\(double\[\], double\[\], double\[\], double\[\], double\[\]\)') | Encapsulates price data for technical analysis operations\. |

| Properties | |
| :--- | :--- |
| [Close](PriceData.Close.md 'TechnicalAnalysis\.Functions\.PriceData\.Close') | Array of closing prices\. |
| [High](PriceData.High.md 'TechnicalAnalysis\.Functions\.PriceData\.High') | Array of high prices\. |
| [Length](PriceData.Length.md 'TechnicalAnalysis\.Functions\.PriceData\.Length') | Gets the number of data points in the price series\. |
| [Low](PriceData.Low.md 'TechnicalAnalysis\.Functions\.PriceData\.Low') | Array of low prices\. |
| [Open](PriceData.Open.md 'TechnicalAnalysis\.Functions\.PriceData\.Open') | Array of opening prices\. |
| [Volume](PriceData.Volume.md 'TechnicalAnalysis\.Functions\.PriceData\.Volume') | Optional array of volume data\. |

| Methods | |
| :--- | :--- |
| [FromClose\(double\[\]\)](PriceData.FromClose(double[]).md 'TechnicalAnalysis\.Functions\.PriceData\.FromClose\(double\[\]\)') | Creates a PriceData instance from closing prices only\. |
| [FromOHLC\(double\[\], double\[\], double\[\], double\[\]\)](PriceData.FromOHLC(double[],double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.PriceData\.FromOHLC\(double\[\], double\[\], double\[\], double\[\]\)') | Creates a PriceData instance without volume data\. |
| [FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\)](PriceData.FromOHLCV(double[],double[],double[],double[],double[]).md 'TechnicalAnalysis\.Functions\.PriceData\.FromOHLCV\(double\[\], double\[\], double\[\], double\[\], double\[\]\)') | Creates a PriceData instance with volume data\. |
