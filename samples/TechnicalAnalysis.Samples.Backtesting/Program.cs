// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Samples.Backtesting;

/// <summary>
/// Entry point of the backtesting sample.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Parses the command line, runs the sample and prints its report.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns><c>0</c> on success, <c>1</c> when the command line or the input data was rejected.</returns>
    internal static int Main(string[] args)
    {
        CommandLineOptions options;
        try
        {
            options = CommandLineOptions.Parse(args);
        }
        catch (FormatException ex)
        {
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine();
            Console.Error.WriteLine(CommandLineOptions.Usage);
            return 1;
        }

        if (options.ShowHelp)
        {
            Console.WriteLine(CommandLineOptions.Usage);
            return 0;
        }

        try
        {
            Console.WriteLine(BacktestSampleRunner.Run(options));
            return 0;
        }
        catch (FileNotFoundException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
        catch (FormatException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
    }
}
