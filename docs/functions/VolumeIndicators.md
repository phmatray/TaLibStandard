#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions')

## VolumeIndicators Class

Fluent volume indicators\.

```csharp
public static class VolumeIndicators
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → VolumeIndicators

### Remarks
The class name is TA\-Lib's own function group and never appears at a call site: these are
extension methods on [PriceSeries](PriceSeries.md 'TechnicalAnalysis\.Functions\.PriceSeries')\.

| Methods | |
| :--- | :--- |
| [Obv\(this PriceSeries\)](VolumeIndicators.Obv(thisPriceSeries).md 'TechnicalAnalysis\.Functions\.VolumeIndicators\.Obv\(this TechnicalAnalysis\.Functions\.PriceSeries\)') | Computes on\-balance volume: the running total of volume, signed by the direction of the close\. |
