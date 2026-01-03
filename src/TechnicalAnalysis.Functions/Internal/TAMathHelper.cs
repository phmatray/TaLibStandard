// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions.Internal;

/// <summary>
/// Internal helper class for TAMath method overload generation.
/// Handles float-to-double conversion automatically.
/// </summary>
internal static class TAMathHelper
{
    /// <summary>
    /// Generic wrapper for single input array indicators.
    /// Converts float array to double and delegates to the core method.
    /// </summary>
    /// <typeparam name="TResult">The result type returned by the core method.</typeparam>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="real">The input data array as float.</param>
    /// <param name="coreMethod">The core method that accepts double arrays.</param>
    /// <returns>The result from the core method.</returns>
    public static TResult Execute<TResult>(
        int startIdx,
        int endIdx,
        float[] real,
        Func<int, int, double[], TResult> coreMethod)
        where TResult : class
    {
        return coreMethod(startIdx, endIdx, real.ToDouble());
    }

    /// <summary>
    /// Generic wrapper for two input arrays (High/Low).
    /// Converts float arrays to double and delegates to the core method.
    /// </summary>
    /// <typeparam name="TResult">The result type returned by the core method.</typeparam>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="high">The high prices array as float.</param>
    /// <param name="low">The low prices array as float.</param>
    /// <param name="coreMethod">The core method that accepts double arrays.</param>
    /// <returns>The result from the core method.</returns>
    public static TResult Execute<TResult>(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        Func<int, int, double[], double[], TResult> coreMethod)
        where TResult : class
    {
        return coreMethod(startIdx, endIdx, high.ToDouble(), low.ToDouble());
    }

    /// <summary>
    /// Generic wrapper for three input arrays (High/Low/Close).
    /// Converts float arrays to double and delegates to the core method.
    /// </summary>
    /// <typeparam name="TResult">The result type returned by the core method.</typeparam>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="high">The high prices array as float.</param>
    /// <param name="low">The low prices array as float.</param>
    /// <param name="close">The close prices array as float.</param>
    /// <param name="coreMethod">The core method that accepts double arrays.</param>
    /// <returns>The result from the core method.</returns>
    public static TResult Execute<TResult>(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        Func<int, int, double[], double[], double[], TResult> coreMethod)
        where TResult : class
    {
        return coreMethod(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    /// <summary>
    /// Generic wrapper for four input arrays (High/Low/Close/Volume).
    /// Converts float arrays to double and delegates to the core method.
    /// </summary>
    /// <typeparam name="TResult">The result type returned by the core method.</typeparam>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <param name="high">The high prices array as float.</param>
    /// <param name="low">The low prices array as float.</param>
    /// <param name="close">The close prices array as float.</param>
    /// <param name="volume">The volume array as float.</param>
    /// <param name="coreMethod">The core method that accepts double arrays.</param>
    /// <returns>The result from the core method.</returns>
    public static TResult Execute<TResult>(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        float[] volume,
        Func<int, int, double[], double[], double[], double[], TResult> coreMethod)
        where TResult : class
    {
        return coreMethod(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble());
    }
}
