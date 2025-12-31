#### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md 'Atypical\.TechnicalAnalysis\.Functions')
### [TechnicalAnalysis\.Functions](Atypical.TechnicalAnalysis.Functions.md#TechnicalAnalysis.Functions 'TechnicalAnalysis\.Functions').[ZigZagResult](ZigZagResult.md 'TechnicalAnalysis\.Functions\.ZigZagResult')

## ZigZagResult\.Real Property

Gets the array of Zig Zag values\.

```csharp
public double[] Real { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

### Remarks
The array contains values only at significant reversal points \(peaks and troughs\)\.
Intermediate values may be zero or interpolated depending on the implementation\.
Note that the Zig Zag indicator repaints \- the last leg can change as new data arrives,
making it unsuitable for real\-time trading signals but useful for historical analysis\.