# D3.js Integration for TaLibStandard Demo

## Overview
This document describes the D3.js integration that replaced ApexCharts in the TaLibStandard Blazor WebAssembly demo application.

## Changes Made

### 1. Removed ApexCharts
- Removed ApexCharts.Blazor NuGet package from Demo.BlazorWasm.csproj
- Removed ApexCharts imports from _Imports.razor
- Removed ApexCharts JavaScript files from index.html

### 2. Added D3.js
- Added D3.js v7 via CDN in index.html
- Created `/wwwroot/js/d3-charts.js` with comprehensive charting functions

### 3. New Components
- **D3CandlestickChart.razor**: A feature-rich candlestick chart component with support for:
  - Interactive candlestick visualization with tooltips
  - Technical indicators overlay (SMA, EMA, etc.)
  - Bollinger Bands and other band indicators
  - Secondary indicators (RSI, MACD, ATR, OBV)
  - Pattern recognition markers
  - Volume chart
  - Responsive design

### 4. New Pages
- **IndicatorsD3.razor**: A new page demonstrating D3.js charts with technical indicators
- Accessible via `/indicators-d3` route

## Features

### Candlestick Chart
- OHLC candlesticks with color coding (green for bullish, red for bearish)
- Interactive tooltips showing date, OHLC values, and volume
- Automatic scaling and date formatting
- Pattern markers for detected candlestick patterns

### Technical Indicators
- **Overlay Indicators**: SMA, EMA displayed on the main chart
- **Band Indicators**: Bollinger Bands with customizable colors and fill
- **Secondary Indicators**: RSI, MACD, ATR, OBV in separate chart panels
- **MACD**: Includes signal line and histogram
- **RSI**: Shows overbought/oversold levels (70/30)

### Flexibility
- Full control over chart appearance and behavior
- Easy to extend with new indicators
- Customizable colors, stroke widths, and opacity
- Responsive design that works on different screen sizes

## Usage

### Basic Candlestick Chart
```razor
<D3CandlestickChart 
    Title="Stock Chart"
    StockData="@stockData"
    ShowVolume="true"
    Width="900"
    Height="500" />
```

### With Indicators
```razor
<D3CandlestickChart 
    Title="Stock Chart with Indicators"
    StockData="@stockData"
    Indicators="@indicators"
    Bands="@bands"
    SecondaryIndicators="@secondaryIndicators"
    ShowVolume="true"
    Width="900"
    Height="500" />
```

## JavaScript API

The D3 charts are powered by `/wwwroot/js/d3-charts.js` which provides:
- `createCandlestickChart`: Main chart creation
- `addIndicator`: Add line indicators
- `addBands`: Add band indicators (upper/lower)
- `addPatternMarkers`: Mark candlestick patterns
- `createSecondaryIndicator`: Create separate indicator panels
- `addSignalLine`: Add signal lines to indicators
- `addHistogram`: Add histogram bars (for MACD)
- `dispose`: Clean up charts

## Benefits over ApexCharts
1. **Full Control**: Complete control over chart rendering and behavior
2. **Customization**: Easy to add custom indicators and visualizations
3. **Performance**: Direct SVG manipulation for better performance
4. **Integration**: Better integration with TaLibStandard indicators
5. **No Dependencies**: Uses only D3.js, reducing bundle size

## Future Enhancements
- Zoom and pan functionality
- Crosshair cursor
- Drawing tools (trend lines, fibonacci retracements)
- Real-time data updates
- Export to image/PDF
- More chart types (line, area, etc.)