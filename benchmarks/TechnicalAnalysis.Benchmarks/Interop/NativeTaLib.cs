// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace TechnicalAnalysis.Benchmarks.Interop;

/// <summary>
/// An opt-in P/Invoke bridge to the original TA-Lib C library.
/// </summary>
/// <remarks>
/// <para>
/// The bridge is entirely optional. <see cref="IsAvailable"/> probes for the native library once, never throws and
/// returns <see langword="false"/> when nothing suitable is found; the rest of the benchmark suite then runs
/// unchanged with zero native dependencies.
/// </para>
/// <para>
/// Only functions whose C signature is certain are bound here. Every one of them is declared in
/// <c>ta_func.h</c> of the upstream TA-Lib distribution with the same shape: leading <c>startIdx</c> /
/// <c>endIdx</c>, then the <c>const double[]</c> inputs, then the <c>optIn*</c> parameters, then
/// <c>int *outBegIdx</c> and <c>int *outNBElement</c>, then the <c>double[]</c> output buffers. The return type is
/// the C enum <c>TA_RetCode</c>, which is marshalled as <see cref="int"/> (<c>TA_SUCCESS</c> is 0). The calling
/// convention is cdecl on every supported platform.
/// </para>
/// <para>
/// The <c>TA_MAType</c> C enum uses the same ordinal order as <c>TechnicalAnalysis.Common.MAType</c>
/// (SMA, EMA, WMA, DEMA, TEMA, TRIMA, KAMA, MAMA, T3), so a plain cast to <see cref="int"/> is correct.
/// </para>
/// </remarks>
public static class NativeTaLib
{
    /// <summary>
    /// The value of <c>TA_SUCCESS</c> in the C <c>TA_RetCode</c> enum.
    /// </summary>
    public const int Success = 0;

    /// <summary>
    /// The logical name used by every <c>[DllImport]</c> below. It is never resolved by the default loader: the
    /// registered <see cref="DllImportResolver"/> always answers with the handle discovered by <see cref="Probe"/>.
    /// </summary>
    private const string LogicalLibraryName = "talib-native";

    /// <summary>
    /// Environment variable that overrides discovery with an explicit file name or absolute path.
    /// </summary>
    private const string OverrideEnvironmentVariable = "TALIB_NATIVE_LIBRARY";

    /// <summary>
    /// Library names handed to the platform loader, which applies the usual <c>lib</c> prefix and
    /// <c>.so</c> / <c>.dylib</c> / <c>.dll</c> suffix conventions itself.
    /// </summary>
    private static readonly string[] CandidateNames =
    [
        "ta-lib",
        "ta_lib",
        "libta-lib",
        "libta_lib",
        "ta_libc",
        "ta_libc_cdr",
        "libta-lib.so.0",
        "libta_lib.so.0"
    ];

    /// <summary>
    /// Absolute paths tried after the plain names, covering the default Homebrew, MacPorts and autotools prefixes.
    /// </summary>
    private static readonly string[] CandidatePaths =
    [
        "/opt/homebrew/lib/libta-lib.dylib",
        "/opt/homebrew/lib/libta_lib.dylib",
        "/usr/local/lib/libta-lib.dylib",
        "/usr/local/lib/libta_lib.dylib",
        "/opt/local/lib/libta-lib.dylib",
        "/usr/local/lib/libta-lib.so",
        "/usr/local/lib/libta_lib.so",
        "/usr/lib/libta-lib.so",
        "/usr/lib/libta_lib.so",
        "/usr/lib/x86_64-linux-gnu/libta-lib.so",
        "/usr/lib/aarch64-linux-gnu/libta-lib.so"
    ];

    private static readonly Lock SyncRoot = new();

    private static bool _probed;
    private static bool _available;
    private static IntPtr _handle;
    private static string _resolvedName = "<none>";
    private static string _diagnostics = "not probed yet";

    static NativeTaLib()
    {
        // Registering the resolver here (rather than lazily) guarantees it is in place before the CLR resolves any
        // of the [DllImport] entries below, because touching any static member runs this constructor first.
        try
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), ResolveLibrary);
        }
        catch (InvalidOperationException)
        {
            // A resolver was already registered for this assembly. Harmless: discovery still works through it or
            // through the default loader, and a failure to bind simply leaves IsAvailable false.
        }
    }

    /// <summary>
    /// Gets a value indicating whether the native TA-Lib C library was found, loaded and successfully initialised.
    /// </summary>
    /// <remarks>
    /// This property never throws. The first access performs the probe; subsequent accesses are a field read.
    /// </remarks>
    public static bool IsAvailable
    {
        get
        {
            Probe();
            return _available;
        }
    }

    /// <summary>
    /// Gets the name or path the native library was resolved from, or <c>&lt;none&gt;</c> when it was not found.
    /// </summary>
    public static string ResolvedName
    {
        get
        {
            Probe();
            return _resolvedName;
        }
    }

    /// <summary>
    /// Gets a human readable description of what the probe tried and what happened, for the startup banner.
    /// </summary>
    public static string Diagnostics
    {
        get
        {
            Probe();
            return _diagnostics;
        }
    }

    /// <summary>
    /// Calls <c>TA_SMA</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inReal">The input series.</param>
    /// <param name="optInTimePeriod">The averaging period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outReal">The caller-allocated output buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Sma(
        int startIdx,
        int endIdx,
        double[] inReal,
        int optInTimePeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outReal)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pIn = inReal)
        fixed (double* pOut = outReal)
        {
            retCode = TA_SMA(startIdx, endIdx, pIn, optInTimePeriod, &begIdx, &nbElement, pOut);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_EMA</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inReal">The input series.</param>
    /// <param name="optInTimePeriod">The averaging period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outReal">The caller-allocated output buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Ema(
        int startIdx,
        int endIdx,
        double[] inReal,
        int optInTimePeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outReal)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pIn = inReal)
        fixed (double* pOut = outReal)
        {
            retCode = TA_EMA(startIdx, endIdx, pIn, optInTimePeriod, &begIdx, &nbElement, pOut);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_RSI</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inReal">The input series.</param>
    /// <param name="optInTimePeriod">The RSI period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outReal">The caller-allocated output buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Rsi(
        int startIdx,
        int endIdx,
        double[] inReal,
        int optInTimePeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outReal)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pIn = inReal)
        fixed (double* pOut = outReal)
        {
            retCode = TA_RSI(startIdx, endIdx, pIn, optInTimePeriod, &begIdx, &nbElement, pOut);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_MACD</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inReal">The input series.</param>
    /// <param name="optInFastPeriod">The fast EMA period.</param>
    /// <param name="optInSlowPeriod">The slow EMA period.</param>
    /// <param name="optInSignalPeriod">The signal EMA period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outMacd">The caller-allocated MACD line buffer.</param>
    /// <param name="outMacdSignal">The caller-allocated signal line buffer.</param>
    /// <param name="outMacdHist">The caller-allocated histogram buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Macd(
        int startIdx,
        int endIdx,
        double[] inReal,
        int optInFastPeriod,
        int optInSlowPeriod,
        int optInSignalPeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outMacd,
        double[] outMacdSignal,
        double[] outMacdHist)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pIn = inReal)
        fixed (double* pMacd = outMacd)
        fixed (double* pSignal = outMacdSignal)
        fixed (double* pHist = outMacdHist)
        {
            retCode = TA_MACD(
                startIdx,
                endIdx,
                pIn,
                optInFastPeriod,
                optInSlowPeriod,
                optInSignalPeriod,
                &begIdx,
                &nbElement,
                pMacd,
                pSignal,
                pHist);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_BBANDS</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inReal">The input series.</param>
    /// <param name="optInTimePeriod">The averaging period.</param>
    /// <param name="optInNbDevUp">The number of standard deviations for the upper band.</param>
    /// <param name="optInNbDevDn">The number of standard deviations for the lower band.</param>
    /// <param name="optInMaType">The moving average type, ordinal-compatible with <c>MAType</c>.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outUpper">The caller-allocated upper band buffer.</param>
    /// <param name="outMiddle">The caller-allocated middle band buffer.</param>
    /// <param name="outLower">The caller-allocated lower band buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Bbands(
        int startIdx,
        int endIdx,
        double[] inReal,
        int optInTimePeriod,
        double optInNbDevUp,
        double optInNbDevDn,
        int optInMaType,
        out int outBegIdx,
        out int outNbElement,
        double[] outUpper,
        double[] outMiddle,
        double[] outLower)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pIn = inReal)
        fixed (double* pUpper = outUpper)
        fixed (double* pMiddle = outMiddle)
        fixed (double* pLower = outLower)
        {
            retCode = TA_BBANDS(
                startIdx,
                endIdx,
                pIn,
                optInTimePeriod,
                optInNbDevUp,
                optInNbDevDn,
                optInMaType,
                &begIdx,
                &nbElement,
                pUpper,
                pMiddle,
                pLower);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_ATR</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inHigh">The high price series.</param>
    /// <param name="inLow">The low price series.</param>
    /// <param name="inClose">The close price series.</param>
    /// <param name="optInTimePeriod">The averaging period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outReal">The caller-allocated output buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Atr(
        int startIdx,
        int endIdx,
        double[] inHigh,
        double[] inLow,
        double[] inClose,
        int optInTimePeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outReal)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pHigh = inHigh)
        fixed (double* pLow = inLow)
        fixed (double* pClose = inClose)
        fixed (double* pOut = outReal)
        {
            retCode = TA_ATR(startIdx, endIdx, pHigh, pLow, pClose, optInTimePeriod, &begIdx, &nbElement, pOut);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_ADX</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inHigh">The high price series.</param>
    /// <param name="inLow">The low price series.</param>
    /// <param name="inClose">The close price series.</param>
    /// <param name="optInTimePeriod">The averaging period.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outReal">The caller-allocated output buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Adx(
        int startIdx,
        int endIdx,
        double[] inHigh,
        double[] inLow,
        double[] inClose,
        int optInTimePeriod,
        out int outBegIdx,
        out int outNbElement,
        double[] outReal)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pHigh = inHigh)
        fixed (double* pLow = inLow)
        fixed (double* pClose = inClose)
        fixed (double* pOut = outReal)
        {
            retCode = TA_ADX(startIdx, endIdx, pHigh, pLow, pClose, optInTimePeriod, &begIdx, &nbElement, pOut);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    /// <summary>
    /// Calls <c>TA_STOCH</c>.
    /// </summary>
    /// <param name="startIdx">The first index of the input to process.</param>
    /// <param name="endIdx">The last index of the input to process.</param>
    /// <param name="inHigh">The high price series.</param>
    /// <param name="inLow">The low price series.</param>
    /// <param name="inClose">The close price series.</param>
    /// <param name="optInFastKPeriod">The fast %K period.</param>
    /// <param name="optInSlowKPeriod">The slow %K smoothing period.</param>
    /// <param name="optInSlowKMaType">The slow %K moving average type.</param>
    /// <param name="optInSlowDPeriod">The slow %D smoothing period.</param>
    /// <param name="optInSlowDMaType">The slow %D moving average type.</param>
    /// <param name="outBegIdx">Receives the input index the first output element corresponds to.</param>
    /// <param name="outNbElement">Receives the number of valid output elements.</param>
    /// <param name="outSlowK">The caller-allocated slow %K buffer.</param>
    /// <param name="outSlowD">The caller-allocated slow %D buffer.</param>
    /// <returns>The C <c>TA_RetCode</c>; <see cref="Success"/> means success.</returns>
    public static unsafe int Stoch(
        int startIdx,
        int endIdx,
        double[] inHigh,
        double[] inLow,
        double[] inClose,
        int optInFastKPeriod,
        int optInSlowKPeriod,
        int optInSlowKMaType,
        int optInSlowDPeriod,
        int optInSlowDMaType,
        out int outBegIdx,
        out int outNbElement,
        double[] outSlowK,
        double[] outSlowD)
    {
        int begIdx = 0;
        int nbElement = 0;
        int retCode;

        fixed (double* pHigh = inHigh)
        fixed (double* pLow = inLow)
        fixed (double* pClose = inClose)
        fixed (double* pSlowK = outSlowK)
        fixed (double* pSlowD = outSlowD)
        {
            retCode = TA_STOCH(
                startIdx,
                endIdx,
                pHigh,
                pLow,
                pClose,
                optInFastKPeriod,
                optInSlowKPeriod,
                optInSlowKMaType,
                optInSlowDPeriod,
                optInSlowDMaType,
                &begIdx,
                &nbElement,
                pSlowK,
                pSlowD);
        }

        outBegIdx = begIdx;
        outNbElement = nbElement;
        return retCode;
    }

    private static IntPtr ResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        return string.Equals(libraryName, LogicalLibraryName, StringComparison.Ordinal) ? _handle : IntPtr.Zero;
    }

    private static void Probe()
    {
        if (Volatile.Read(ref _probed))
        {
            return;
        }

        lock (SyncRoot)
        {
            if (_probed)
            {
                return;
            }

            StringBuilder log = new();

            try
            {
                ProbeCore(log);
            }
#pragma warning disable CA1031 // Discovery must never propagate: the whole point is that the suite degrades gracefully.
            catch (Exception ex)
#pragma warning restore CA1031
            {
                _available = false;
                _handle = IntPtr.Zero;
                log.Append(CultureInfo.InvariantCulture, $"unexpected failure: {ex.GetType().Name}: {ex.Message}");
            }

            _diagnostics = log.ToString();
            Volatile.Write(ref _probed, true);
        }
    }

    private static void ProbeCore(StringBuilder log)
    {
        string? overridden = Environment.GetEnvironmentVariable(OverrideEnvironmentVariable);
        List<string> attempted = [];

        if (!string.IsNullOrWhiteSpace(overridden))
        {
            attempted.Add(overridden);
        }

        attempted.AddRange(CandidateNames);
        attempted.AddRange(CandidatePaths);

        foreach (string candidate in attempted)
        {
            if (!TryLoad(candidate, out IntPtr handle))
            {
                continue;
            }

            // A library that loads but has no TA_Initialize export is not TA-Lib.
            if (!NativeLibrary.TryGetExport(handle, "TA_Initialize", out IntPtr initialize))
            {
                NativeLibrary.Free(handle);
                log.Append(CultureInfo.InvariantCulture, $"'{candidate}' loaded but exports no TA_Initialize; ignored. ");
                continue;
            }

            // Called through the export pointer of *this* candidate, never through the [DllImport] stub.
            // Invoking the stub would make the CLR run the resolver once and cache the resolved module and
            // function pointer for the lifetime of the process; the next candidate would then jump to that
            // cached address, which by then points into a library this loop has already freed. Calling the
            // pointer directly keeps each candidate self-contained, so a library that loads but fails
            // TA_Initialize costs an ignored candidate rather than an access violation.
            int retCode = InvokeInitialize(initialize);
            if (retCode != Success)
            {
                NativeLibrary.Free(handle);
                log.Append(CultureInfo.InvariantCulture, $"'{candidate}': TA_Initialize returned {retCode}; ignored. ");
                continue;
            }

            // Published only now that the candidate is known good, so the resolver can never hand a
            // [DllImport] a handle that is about to be freed.
            _handle = handle;
            _resolvedName = candidate;

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            _available = true;
            log.Append(CultureInfo.InvariantCulture, $"resolved '{candidate}', TA_Initialize succeeded.");
            return;
        }

        _available = false;
        _handle = IntPtr.Zero;
        log.Append(CultureInfo.InvariantCulture, $"probed {attempted.Count} candidate name(s)/path(s), none loaded.");
    }

    /// <summary>
    /// Calls a resolved <c>TA_Initialize</c> export through its address, bypassing the P/Invoke stub and the
    /// per-process caching that comes with it.
    /// </summary>
    /// <param name="entryPoint">The address of <c>TA_Initialize</c> in the candidate library.</param>
    /// <returns>The C <c>TA_RetCode</c>.</returns>
    private static unsafe int InvokeInitialize(IntPtr entryPoint)
    {
        return ((delegate* unmanaged[Cdecl]<int>)entryPoint)();
    }

    private static bool TryLoad(string candidate, out IntPtr handle)
    {
        handle = IntPtr.Zero;

        try
        {
            if (Path.IsPathRooted(candidate))
            {
                return File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out handle);
            }

            return NativeLibrary.TryLoad(
                candidate,
                Assembly.GetExecutingAssembly(),
                DllImportSearchPath.SafeDirectories | DllImportSearchPath.UserDirectories,
                out handle);
        }
#pragma warning disable CA1031 // A malformed candidate must not abort the probe.
        catch (Exception)
#pragma warning restore CA1031
        {
            handle = IntPtr.Zero;
            return false;
        }
    }

    private static void OnProcessExit(object? sender, EventArgs e)
    {
        try
        {
            if (_available)
            {
                _available = false;
                _ = TA_Shutdown();
            }
        }
#pragma warning disable CA1031 // Nothing useful can be done at process exit.
        catch (Exception)
#pragma warning restore CA1031
        {
            // Ignored.
        }
    }

    [DllImport(LogicalLibraryName, EntryPoint = "TA_Shutdown", CallingConvention = CallingConvention.Cdecl)]
    private static extern int TA_Shutdown();

    [DllImport(LogicalLibraryName, EntryPoint = "TA_SMA", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_SMA(
        int startIdx,
        int endIdx,
        double* inReal,
        int optInTimePeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outReal);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_EMA", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_EMA(
        int startIdx,
        int endIdx,
        double* inReal,
        int optInTimePeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outReal);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_RSI", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_RSI(
        int startIdx,
        int endIdx,
        double* inReal,
        int optInTimePeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outReal);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_MACD", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_MACD(
        int startIdx,
        int endIdx,
        double* inReal,
        int optInFastPeriod,
        int optInSlowPeriod,
        int optInSignalPeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outMACD,
        double* outMACDSignal,
        double* outMACDHist);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_BBANDS", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_BBANDS(
        int startIdx,
        int endIdx,
        double* inReal,
        int optInTimePeriod,
        double optInNbDevUp,
        double optInNbDevDn,
        int optInMAType,
        int* outBegIdx,
        int* outNBElement,
        double* outRealUpperBand,
        double* outRealMiddleBand,
        double* outRealLowerBand);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_ATR", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_ATR(
        int startIdx,
        int endIdx,
        double* inHigh,
        double* inLow,
        double* inClose,
        int optInTimePeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outReal);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_ADX", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_ADX(
        int startIdx,
        int endIdx,
        double* inHigh,
        double* inLow,
        double* inClose,
        int optInTimePeriod,
        int* outBegIdx,
        int* outNBElement,
        double* outReal);

    [DllImport(LogicalLibraryName, EntryPoint = "TA_STOCH", CallingConvention = CallingConvention.Cdecl)]
    private static extern unsafe int TA_STOCH(
        int startIdx,
        int endIdx,
        double* inHigh,
        double* inLow,
        double* inClose,
        int optInFastK_Period,
        int optInSlowK_Period,
        int optInSlowK_MAType,
        int optInSlowD_Period,
        int optInSlowD_MAType,
        int* outBegIdx,
        int* outNBElement,
        double* outSlowK,
        double* outSlowD);
}
