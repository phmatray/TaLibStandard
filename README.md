# TaLibStandard
[![Sparkline](https://stars.medv.io/phmatray/TaLibStandard.svg)](https://stars.medv.io/phmatray/TaLibStandard)

A modern and robust C# Technical Analysis library based on the original open-source [TA-Lib](https://ta-lib.org) by Mario Fortier, using Generic Math and supporting Double, Float, and Decimal data types.

---

[![phmatray - TaLibStandard](https://img.shields.io/static/v1?label=phmatray&message=TaLibStandard&color=blue&logo=github)](https://github.com/phmatray/TaLibStandard "Go to GitHub repo")
[![License: GPL-3.0-or-later](https://img.shields.io/badge/License-GPLv3.0--or--later-blue.svg)](https://www.gnu.org/licenses/gpl-3.0.html)
[![stars - TaLibStandard](https://img.shields.io/github/stars/phmatray/TaLibStandard?style=social)](https://github.com/phmatray/TaLibStandard)
[![forks - TaLibStandard](https://img.shields.io/github/forks/phmatray/TaLibStandard?style=social)](https://github.com/phmatray/TaLibStandard)

[![GitHub tag](https://img.shields.io/github/tag/phmatray/TaLibStandard?include_prereleases=&sort=semver&color=blue)](https://github.com/phmatray/TaLibStandard/releases/)
[![issues - TaLibStandard](https://img.shields.io/github/issues/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/pulls)
[![GitHub contributors](https://img.shields.io/github/contributors/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/graphs/contributors)
[![GitHub last commit](https://img.shields.io/github/last-commit/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/commits/master)
[![codecov](https://codecov.io/gh/phmatray/TaLibStandard/branch/main/graph/badge.svg?token=041C4QKW6O)](https://app.codecov.io/gh/phmatray/TaLibStandard/tree/main)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/84e2475f22a04bc1bed551f081029e82)](https://app.codacy.com/gh/phmatray/TaLibStandard/dashboard)

---

## 📝 Table of Contents

<!-- TOC -->
* [TaLibStandard](#talibstandard)
  * [📝 Table of Contents](#-table-of-contents)
  * [📚 Introduction](#-introduction)
  * [🎯 Goal](#-goal)
  * [🏁 Getting started](#-getting-started)
  * [📌 Features](#-features)
    * [Roadmap (next features)](#roadmap-next-features)
  * [📄 Documentation](#-documentation)
  * [📥 Installation](#-installation)
    * [📋 Prerequisites](#-prerequisites)
    * [🚀 We use the latest C# features](#-we-use-the-latest-c-features)
    * [📦 NuGet Packages](#-nuget-packages)
    * [🧪 Tests Specifications](#-tests-specifications)
  * [💾 Installation](#-installation-1)
  * [📊 Code Quality](#-code-quality)
  * [❓ Issues and Feature Requests](#-issues-and-feature-requests)
  * [🤝 Contributing](#-contributing)
  * [🌟 Contributors](#-contributors)
  * [✉️ Contact](#-contact)
  * [📝 Release notes](#-release-notes)
  * [📜 License](#-license)
<!-- TOC -->

## 📚 Introduction

TaLibStandard is a modern interpretation of the widely used [TA-Lib](https://ta-lib.org), reimagined in C# 14. It is designed to be reliable, efficient, and user-friendly for developers performing financial market analysis. The addition of .NET's Generic Math feature allows for a richer, more flexible library that can handle a variety of number types.

## 🎯 Goal

The primary objective of TaLibStandard is to provide a comprehensive, feature-rich and accessible library for conducting technical analysis on financial market data.

## 🏁 Getting started

To get started with TaLibStandard, you can clone the repository and explore the examples provided in the `examples` directory. You can also refer to the list of [available functions](./docs/functions.md) in the documentation for a comprehensive overview of the library's capabilities.

## 📌 Features

* [x] Support for Double, Float, and Decimal data types, with the help of .NET's Generic Math
* [x] With some basic tests (coverage: >= 80%)
* [x] .NET Exception handling (BREAKING CHANGE)

### Roadmap (next features)

* [ ] Comprehensive API documentation that is easy to understand
* [ ] High-Level API for common use cases
* [ ] Support for more data types
* [ ] Support for more functions
* [ ] More tests
* [ ] More examples
* [ ] Add a Benchmark project
* [ ] Create a gRPC server to expose the library as a service

## 📄 Documentation

**TaLibStandard** provides a [COMPLETE DOCUMENTATION](https://github.com/phmatray/TaLibStandard/blob/main/docs/README.md) of the library.

All summaries are written in English. If you want to help us translate the documentation, please open an issue to
discuss it.

> **Note:** The documentation is generated using [Doraku/DefaultDocumentation]() tool. It is generated automatically when the project is built.

## 📥 Installation

### 📋 Prerequisites

- .NET 10.0 (supported versions: 10.x)
- A C# IDE (Visual Studio, JetBrains Rider, etc.)
- A C# compiler (dotnet CLI, etc.)

### 🚀 We use the latest C# features

This library targets .NET 10.0 and uses the latest C# features. It is written in C# 14.0 and uses the new `init`
properties, `record` types, `switch` expressions, `using` declarations and more.

I invite you to read the [C# 14.0 documentation](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14) to
learn more about these features.

### 📦 NuGet Packages

| Package Name                         | NuGet Version Badge                                                                                                                                      | NuGet Downloads Badge                                                                                                                                     | Package Explorer                                                            |
|--------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------|
| Atypical.TechnicalAnalysis.Candles   | [![NuGet](https://img.shields.io/nuget/v/Atypical.TechnicalAnalysis.Candles.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Candles)     | [![NuGet](https://img.shields.io/nuget/dt/Atypical.TechnicalAnalysis.Candles.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Candles)     | [Explore](https://nuget.info/packages/Atypical.TechnicalAnalysis.Candles)   |
| Atypical.TechnicalAnalysis.Functions | [![NuGet](https://img.shields.io/nuget/v/Atypical.TechnicalAnalysis.Functions.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Functions) | [![NuGet](https://img.shields.io/nuget/dt/Atypical.TechnicalAnalysis.Functions.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Functions) | [Explore](https://nuget.info/packages/Atypical.TechnicalAnalysis.Functions) |
| Atypical.TechnicalAnalysis.Core      | [![NuGet](https://img.shields.io/nuget/v/Atypical.TechnicalAnalysis.Common.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Common)       | [![NuGet](https://img.shields.io/nuget/dt/Atypical.TechnicalAnalysis.Common.svg)](https://www.nuget.org/packages/Atypical.TechnicalAnalysis.Common)       | [Explore](https://nuget.info/packages/Atypical.TechnicalAnalysis.Common)    |

This table is automatically updated regularly the latest developments and releases in the Atypical Technical Analysis suite.

### 🧪 Tests Specifications

  * Target framework : .NET 10
  * Language version : C# 14
  * xUnit and Shouldly 

## 💾 Installation

To install TaLibStandard, you can use the NuGet package manager. Run the following command in your terminal:

```shell
dotnet add package Atypical.TechnicalAnalysis.Candles
dotnet add package Atypical.TechnicalAnalysis.Functions
```

## 📊 Code Quality

We strive for the highest code quality in TaLibStandard, leveraging Codacy—an automated code analysis/quality tool. Codacy provides static analysis, cyclomatic complexity measures, duplication identification, and code unit test coverage changes for every commit and pull request.

View our Codacy metrics [here](https://app.codacy.com/gh/phmatray/TaLibStandard).

## ❓ Issues and Feature Requests

For reporting bugs or suggesting new features, kindly submit these as an issue to the [TaLibStandard Repository](https://github.com/phmatray/TaLibStandard/issues). We value your contributions, but before submitting an issue, please ensure it is not a duplicate of an existing one.

## 🤝 Contributing

We welcome contributions from the community! If you'd like to contribute to TaLibStandard, please fork the repository and submit a pull request. For major changes, please open an issue first to discuss what you would like to change.

## 🌟 Contributors

[![Contributors](https://contrib.rocks/image?repo=phmatray/TaLibStandard)](http://contrib.rocks)

## ✉️ Contact

You can contact us by opening an issue on this repository.

## 📝 Release notes

### v3.0.0 (January 2026) - .NET 10 LTS Release 🎉

**Breaking Changes:**
- **Upgraded to .NET 10 LTS** - Framework support extended until November 2028
- **C# 14 Language Features** - Utilizing the latest C# capabilities
- **Updated Dependencies** - All major packages updated to .NET 10 compatible versions
- **Minimum .NET Version:** Now requires .NET 10.0 SDK

**Major Improvements:**
- **Code Quality:** Extensive refactoring eliminated ~1,200 lines of duplicated code
- **Validation Consolidation:** Unified validation patterns across 99 indicators
- **Result Classes:** Consolidated result types with inheritance hierarchy
- **Mathematical Functions:** Template-based approach for 60+ math indicators
- **Lookback Validation:** Standardized lookback calculations for 87 indicators
- **Code Cleanup:** Removed unused code and consolidated common patterns

**Performance:**
- All 898 tests passing
- No performance degradation
- Maintained backward compatibility in algorithms

**Documentation:**
- Auto-generated API documentation updated
- All function and candle pattern docs regenerated

For migration guide from v2.x to v3.0, see [Migration from v2 to v3](#migration-from-v2-to-v3).

### Previous Releases

- v2.0.0 (June 2025) - Major release with .NET Exception handling
- v1.0.0 (June 2025) - First stable release
- v0.4.0 (June 2025) - Generic Math support
- v0.3.1 (June 2025) - Bug fixes and improvements
- v0.3.0 (June 2025) - Enhanced functionality
- v0.2.0 (June 2025) - Additional indicators
- v0.1.0 (November 2023) - Initial release

## Migration from v2 to v3

### Prerequisites
- **Update to .NET 10 SDK:** Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)
- **Update project target framework:**
  ```xml
  <TargetFramework>net10.0</TargetFramework>
  ```

### Breaking Changes

1. **Framework Requirement**
   - Minimum version: .NET 10.0
   - Projects targeting .NET 9 or earlier must upgrade

2. **Package Dependencies**
   - If you reference TaLibStandard packages, ensure your project can target .NET 10.0
   - Update any conflicting package versions

### API Compatibility
- **No API breaking changes** - All public method signatures remain the same
- **No behavioral changes** - All algorithms produce identical results
- Code that worked with v2.x will work with v3.0 after framework upgrade

### Testing Your Migration
```csharp
// No code changes needed - same API as v2.x
var rsiResult = TAFunc.Rsi(0, closePrices.Length - 1, closePrices, 14,
    ref outBegIdx, ref outNBElement, ref rsiValues);
```

## 📜 License

GNU General Public License v3.0 or later.
