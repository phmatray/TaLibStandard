// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting;

/// <summary>
/// The parsed command line of the sample.
/// </summary>
public sealed record CommandLineOptions
{
    /// <summary>
    /// The usage text printed by <c>--help</c> and after a parse error.
    /// </summary>
    public const string Usage = """
        TaLibStandard - backtesting sample

        Runs four indicator strategies and a buy-and-hold baseline over the same price series,
        then prints a side-by-side performance comparison. With no arguments it uses a deterministic
        synthetic series, so it works completely offline.

        Usage:
          dotnet run --project samples/TechnicalAnalysis.Samples.Backtesting [options]

        Options:
          --csv <path>              Load bars from a CSV file instead of generating them.
                                    Header required: Date,Open,High,Low,Close,Volume (any order).
          --bars <int>              Number of synthetic bars to generate. Default: 1500.
          --seed <int>              Seed of the synthetic series generator. Default: 20240101.
          --capital <double>        Starting account equity. Default: 100000.
          --commission-bps <double> Commission per fill, in basis points of notional. Default: 5.
          --slippage-bps <double>   Slippage per fill, in basis points of price. Default: 2.
          --bars-per-year <int>     Annualisation constant for CAGR, volatility, Sharpe, Sortino,
                                    Calmar. Default: 252 (daily bars, equity calendar).
          --allow-short             Permit short positions. Off by default, in which case a short
                                    signal simply flattens the position.
          --trade-log               Print an excerpt of each strategy's round trips.
          -h, --help                Print this text and exit.

        Examples:
          dotnet run --project samples/TechnicalAnalysis.Samples.Backtesting
          dotnet run --project samples/TechnicalAnalysis.Samples.Backtesting -- --seed 7 --bars 3000 --allow-short
          dotnet run --project samples/TechnicalAnalysis.Samples.Backtesting -- --csv ./spy.csv --commission-bps 10
        """;

    /// <summary>
    /// Gets a value indicating whether the user asked for the usage text.
    /// </summary>
    public bool ShowHelp { get; init; }

    /// <summary>
    /// Gets the path of the CSV file to load, or <see langword="null"/> to generate a synthetic series.
    /// </summary>
    public string? CsvPath { get; init; }

    /// <summary>
    /// Gets the number of synthetic bars to generate when no CSV file is supplied. Defaults to <c>1500</c>.
    /// </summary>
    public int BarCount { get; init; } = 1_500;

    /// <summary>
    /// Gets the seed of the synthetic series generator.
    /// </summary>
    public int Seed { get; init; } = SyntheticSeriesGenerator.DefaultSeed;

    /// <summary>
    /// Gets a value indicating whether an excerpt of the trade log should be printed for each strategy.
    /// </summary>
    public bool ShowTradeLog { get; init; }

    /// <summary>
    /// Gets the backtest options assembled from the command line.
    /// </summary>
    public BacktestOptions Backtest { get; init; } = new();

    /// <summary>
    /// Parses a command line.
    /// </summary>
    /// <param name="args">The raw arguments, as handed to <c>Main</c>.</param>
    /// <returns>The parsed options.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="args"/> is <see langword="null"/>.</exception>
    /// <exception cref="FormatException">An option is unknown, missing its value, or its value is not parsable or out of range.</exception>
    public static CommandLineOptions Parse(IReadOnlyList<string> args)
    {
        ArgumentNullException.ThrowIfNull(args);

        CommandLineOptions options = new();
        BacktestOptions backtest = options.Backtest;

        for (int i = 0; i < args.Count; i++)
        {
            string argument = args[i];
            switch (argument)
            {
                case "-h":
                case "--help":
                    return options with { ShowHelp = true };

                case "--csv":
                    options = options with { CsvPath = NextValue(args, ref i) };
                    break;

                case "--bars":
                    options = options with { BarCount = ParseInt(NextValue(args, ref i), argument, 1) };
                    break;

                case "--seed":
                    options = options with { Seed = ParseInt(NextValue(args, ref i), argument, int.MinValue) };
                    break;

                case "--capital":
                    backtest = backtest with { InitialCapital = ParseDouble(NextValue(args, ref i), argument) };
                    break;

                case "--commission-bps":
                    backtest = backtest with { CommissionBps = ParseDouble(NextValue(args, ref i), argument) };
                    break;

                case "--slippage-bps":
                    backtest = backtest with { SlippageBps = ParseDouble(NextValue(args, ref i), argument) };
                    break;

                case "--bars-per-year":
                    backtest = backtest with { BarsPerYear = ParseInt(NextValue(args, ref i), argument, 1) };
                    break;

                case "--allow-short":
                    backtest = backtest with { AllowShort = true };
                    break;

                case "--trade-log":
                    options = options with { ShowTradeLog = true };
                    break;

                default:
                    throw new FormatException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Unknown option '{0}'.",
                        argument));
            }
        }

        try
        {
            backtest.Validate();
        }
        catch (ArgumentException ex)
        {
            throw new FormatException(ex.Message, ex);
        }

        return options with { Backtest = backtest };
    }

    private static string NextValue(IReadOnlyList<string> args, ref int index)
    {
        if (index + 1 >= args.Count)
        {
            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "Option '{0}' requires a value.",
                args[index]));
        }

        index++;
        return args[index];
    }

    private static int ParseInt(string text, string option, int minimum)
    {
        if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
        {
            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "Option '{0}' expects an integer but got '{1}'.",
                option,
                text));
        }

        if (value < minimum)
        {
            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "Option '{0}' expects a value of at least {1} but got {2}.",
                option,
                minimum,
                value));
        }

        return value;
    }

    private static double ParseDouble(string text, string option)
    {
        if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new FormatException(string.Format(
                CultureInfo.InvariantCulture,
                "Option '{0}' expects a number but got '{1}'.",
                option,
                text));
        }

        return value;
    }
}
