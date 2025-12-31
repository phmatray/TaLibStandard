#### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md 'Atypical\.TechnicalAnalysis\.Common')
### [TechnicalAnalysis\.Common](Atypical.TechnicalAnalysis.Common.md#TechnicalAnalysis.Common 'TechnicalAnalysis\.Common')

## RetCode Enum

Represents the return codes for various functions in the TechnicalAnalysis library\.

```csharp
public enum RetCode
```
### Fields

<a name='TechnicalAnalysis.Common.RetCode.Success'></a>

`Success` 0

Operation completed successfully\.

<a name='TechnicalAnalysis.Common.RetCode.BadParam'></a>

`BadParam` 2

Bad parameter provided\.

<a name='TechnicalAnalysis.Common.RetCode.OutOfRangeStartIndex'></a>

`OutOfRangeStartIndex` 12

Start index is out of range\.

<a name='TechnicalAnalysis.Common.RetCode.OutOfRangeEndIndex'></a>

`OutOfRangeEndIndex` 13

End index is out of range\.

<a name='TechnicalAnalysis.Common.RetCode.InternalError'></a>

`InternalError` 5000

Internal error occurred\.

### Remarks
This enum contains only the error codes that are actively used in the library\.
Legacy error codes from the original TA\-Lib C library that are not applicable
to this \.NET implementation have been removed\.