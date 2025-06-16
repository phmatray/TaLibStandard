using System.Numerics;

namespace Demo.WIP;

public record TACandle<T>(T Open, T High, T Low, T Close)
    where T : IFloatingPoint<T>
{
}

public static class TACandleFactory
{
    /// <summary>
    /// Create a <see cref="TACandle{T}"/> from the specified values.
    /// </summary>
    /// <param name="open">An open price.</param>
    /// <param name="high">A high price.</param>
    /// <param name="low">A low price.</param>
    /// <param name="close">A close price.</param>
    /// <typeparam name="T">The type of the price.</typeparam>
    /// <returns>A <see cref="TACandle{T}"/>.</returns>
    public static TACandle<T> Create<T>(T open, T high, T low, T close)
        where T : IFloatingPoint<T>
    {
        return new(open, high, low, close);
    }

    /// <summary>
    /// Create a collection of <see cref="TACandle{T}"/> from the specified arrays.
    /// </summary>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <returns>A collection of <see cref="TACandle{T}"/>.</returns>
    public static IEnumerable<TACandle<T>> Create<T>(T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        // Verify required price component.
        ArgumentNullException.ThrowIfNull(open);
        ArgumentNullException.ThrowIfNull(high);
        ArgumentNullException.ThrowIfNull(low);
        ArgumentNullException.ThrowIfNull(close);

        // Validate the requested output range.
        if (open.Length != high.Length || open.Length != low.Length || open.Length != close.Length)
        {
            throw new ArgumentException("The arrays must have the same length.");
        }

        for (int i = 0; i < open.Length; i++)
        {
            yield return Create(open[i], high[i], low[i], close[i]);
        }
    }
}

