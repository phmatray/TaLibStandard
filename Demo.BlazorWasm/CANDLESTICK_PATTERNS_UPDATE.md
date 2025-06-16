# Candlestick Patterns Page Update

## Overview
The Candlestick Patterns page has been updated with a chip-based selection system that allows users to enable/disable individual patterns organized by groups (Common, Reversal, Continuation, Complex, and Rare).

## Key Features

### 1. Pattern Selection with MudChipSet
- Multi-selection chip set for pattern selection
- Patterns organized into 5 categories:
  - **Common**: Doji, Hammer, Engulfing, Harami, Shooting Star, etc.
  - **Reversal**: Morning Star, Evening Star, Three White Soldiers, etc.
  - **Continuation**: Rising/Falling Three Methods, Tasuki Gap, etc.
  - **Complex**: Abandoned Baby, Three Line Strike, Breakaway, etc.
  - **Rare**: Concealing Baby Swallow, Unique Three River, etc.

### 2. Visual Organization
- Each pattern group has a distinct color:
  - Common: Primary (Blue)
  - Reversal: Secondary (Purple)
  - Continuation: Tertiary (Pink)
  - Complex: Warning (Orange)
  - Rare: Error (Red)

### 3. User Controls
- **Select All**: Selects all patterns across all groups
- **Clear All**: Deselects all patterns
- Pattern count display showing how many patterns are selected
- By default, only 3 common patterns are enabled (Doji, Hammer, Engulfing)

### 4. Pattern Detection
- Users can select specific patterns to detect
- Only selected patterns will be analyzed and displayed
- Results show both a summary and detailed pattern information

### 5. Chart Integration
- Uses the new D3.js candlestick chart component
- Pattern markers displayed on the chart
- Summary card shows pattern counts
- Detailed table shows date, pattern name, signal, and price

## Technical Implementation

### Pattern Structure
```csharp
private class PatternInfo
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public bool IsEnabled { get; set; }
}
```

### State Management
- `_enabledPatterns`: HashSet tracking selected pattern names
- `_selectedChips`: Collection bound to MudChipSet for UI state
- Two-way synchronization between chip selection and enabled patterns

### Future Enhancements
1. **Expand Pattern Detection**: Currently only 3 patterns are implemented in the service. All 61 available patterns should be added.
2. **Pattern Filtering**: Add ability to filter by signal type (Bullish/Bearish)
3. **Pattern Information**: Add tooltips or info buttons explaining each pattern
4. **Group Selection**: Add buttons to select/deselect entire groups
5. **Save Preferences**: Remember user's pattern selections between sessions

## Usage
1. Select patterns by clicking on the chips
2. Enter a stock symbol and number of days
3. Click "Detect Selected Patterns"
4. View results in the chart and tables below

## Note
The TechnicalAnalysisService currently only implements 3 patterns (Doji, Hammer, Engulfing). To fully utilize the pattern selection feature, the service needs to be updated to support all 61 available candlestick patterns in the TaLibStandard library.