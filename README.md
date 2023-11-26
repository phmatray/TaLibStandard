# TaLibStandard
[![Sparkline](https://stars.medv.io/phmatray/TaLibStandard.svg)](https://stars.medv.io/phmatray/TaLibStandard)

A modern and robust C# Technical Analysis library based on the original open-source [TA-Lib](https://ta-lib.org) by Mario Fortier, using Generic Math and supporting Double, Float, and Decimal data types.

---

[![phmatray - TaLibStandard](https://img.shields.io/static/v1?label=phmatray&message=TaLibStandard&color=blue&logo=github)](https://github.com/phmatray/TaLibStandard "Go to GitHub repo")
[![License: BSD-3-Clause](https://img.shields.io/badge/License-BSD--3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![stars - TaLibStandard](https://img.shields.io/github/stars/phmatray/TaLibStandard?style=social)](https://github.com/phmatray/TaLibStandard)
[![forks - TaLibStandard](https://img.shields.io/github/forks/phmatray/TaLibStandard?style=social)](https://github.com/phmatray/TaLibStandard)

[![GitHub tag](https://img.shields.io/github/tag/phmatray/TaLibStandard?include_prereleases=&sort=semver&color=blue)](https://github.com/phmatray/TaLibStandard/releases/)
[![issues - TaLibStandard](https://img.shields.io/github/issues/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/pulls)
[![GitHub contributors](https://img.shields.io/github/contributors/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/graphs/contributors)
[![GitHub last commit](https://img.shields.io/github/last-commit/phmatray/TaLibStandard)](https://github.com/phmatray/TaLibStandard/commits/master)
[![codecov](https://codecov.io/gh/phmatray/TaLibStandard/branch/main/graph/badge.svg?token=041C4QKW6O)](https://codecov.io/gh/phmatray/TaLibStandard)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/84e2475f22a04bc1bed551f081029e82)](https://www.codacy.com/gh/phmatray/TaLibStandard/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=phmatray/TaLibStandard&amp;utm_campaign=Badge_Grade)

---

<!-- TOC -->
* [TaLibStandard](#talibstandard)
  * [Introduction](#introduction)
  * [Goal](#goal)
  * [Getting started](#getting-started)
  * [Features](#features)
    * [Library](#library)
    * [Tests Specifications](#tests-specifications)
  * [Installation](#installation)
  * [Code Quality](#code-quality)
  * [Issues and Feature Requests](#issues-and-feature-requests)
  * [Contributing](#contributing)
  * [Release notes](#release-notes)
  * [Licence](#licence)
<!-- TOC -->

## Introduction

TaLibStandard is a modern interpretation of the widely used [TA-Lib](https://ta-lib.org), reimagined in C# 11. It is designed to be reliable, efficient, and user-friendly for developers performing financial market analysis. The addition of .NET's Generic Math feature allows for a richer, more flexible library that can handle a variety of number types.

## Goal

The primary objective of TaLibStandard is to provide a comprehensive, feature-rich and accessible library for conducting technical analysis on financial market data.

## Getting started

To get started with TaLibStandard, you can clone the repository and explore the examples provided in the `examples` directory. You can also refer to the list of [available functions](./docs/functions.md) in the documentation for a comprehensive overview of the library's capabilities.

## Features

  * Support for Double, Float, and Decimal data types, with the help of .NET's Generic Math
  * With some basic tests (coverage: 85%)
  * Comprehensive API documentation that is easy to understand

### Library

  * Target framework : .NET 8
  * Language version : C# 12

### Tests Specifications

* Target framework : .NET 8
* Language version : C# 12
* xUnit and FluentAssertions 

## Installation

To install TaLibStandard, you can use the NuGet package manager. Run the following command in your terminal:

```shell
dotnet add package TaLibStandard
```

## Code Quality

We strive for the highest code quality in TaLibStandard, leveraging Codacy—an automated code analysis/quality tool. Codacy provides static analysis, cyclomatic complexity measures, duplication identification, and code unit test coverage changes for every commit and pull request.

View our Codacy metrics [here](https://app.codacy.com/gh/phmatray/TaLibStandard).

## Issues and Feature Requests

For reporting bugs or suggesting new features, kindly submit these as an issue to the [TaLibStandard Repository](https://github.com/phmatray/TaLibStandard/issues). We value your contributions, but before submitting an issue, please ensure it is not a duplicate of an existing one.

## Contributing

We welcome contributions from the community! If you'd like to contribute to TaLibStandard, please fork the repository and submit a pull request. For major changes, please open an issue first to discuss what you would like to change.

## Release notes

(Add details of the version history, bug fixes, and new feature additions in each release here)

## Licence

GNU General Public License v3.0
