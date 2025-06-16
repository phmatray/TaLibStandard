# TaLibStandard Blazor WebAssembly Demo

A comprehensive demo application showcasing the features of the TaLibStandard library using Blazor WebAssembly and MudBlazor.

## Features

- **Technical Indicators**: Interactive demo of various indicators (SMA, EMA, RSI, MACD, Bollinger Bands, ATR, OBV)
- **Candlestick Patterns**: Detection and visualization of candlestick patterns (Doji, Hammer, Engulfing)
- **Stock Analysis**: Comprehensive analysis combining multiple indicators and patterns
- **Math Functions**: Demonstration of mathematical functions included in the library

## Running the Demo

1. Navigate to the demo directory:
   ```bash
   cd Demo.BlazorWasm
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser and navigate to the URL shown in the console (typically https://localhost:5000)

## Project Structure

- **Pages/**
  - `Home.razor` - Landing page with overview
  - `Indicators.razor` - Technical indicators demo
  - `Candlesticks.razor` - Candlestick pattern recognition
  - `Analysis.razor` - Comprehensive stock analysis
  - `Math.razor` - Mathematical functions demo
  - `About.razor` - Information about the library

- **Services/**
  - `IMarketDataService.cs` - Interface for market data
  - `MarketDataService.cs` - Generates sample stock data
  - `ITechnicalAnalysisService.cs` - Interface for technical analysis
  - `TechnicalAnalysisService.cs` - Wrapper for TaLibStandard functions

- **Models/**
  - `StockData.cs` - Model for OHLCV data

## Technologies Used

- **Blazor WebAssembly** - .NET 9.0
- **MudBlazor** - Material Design component library
- **TaLibStandard** - Technical analysis library

## Notes

- The demo uses generated sample data for demonstration purposes
- In a production application, you would integrate with real market data providers
- Charts are shown as placeholders - integrate with a charting library like ApexCharts.Blazor for visualization