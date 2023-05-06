// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TACore
{
    public static readonly GlobalsType Globals = new();
        
    static TACore()
    {
        RestoreCandleDefaultSettings(AllCandleSettings);
    }
        
    public static Compatibility GetCompatibility()
    {
        return Globals.Compatibility;
    }
        
    public static RetCode SetCompatibility(Compatibility value)
    {
        Globals.Compatibility = value;
        return Success;
    }
        
    public static long GetUnstablePeriod(FuncUnstId id)
    {
        return id >= FuncUnstId.FuncUnstAll ? 0 : Globals.UnstablePeriod[(int)id];
    }
        
    public static RetCode SetUnstablePeriod(FuncUnstId id, long unstablePeriod)
    {
        if (id > FuncUnstId.FuncUnstAll)
        {
            return BadParam;
        }
            
        if (id != FuncUnstId.FuncUnstAll)
        {
            Globals.UnstablePeriod[(int)id] = unstablePeriod;
        }
        else
        {
            for (int i = 0; i < 23; i++)
            {
                Globals.UnstablePeriod[i] = unstablePeriod;
            }
        }
            
        return Success;
    }
        
    public static RetCode RestoreCandleDefaultSettings(CandleSettingType settingType)
    {
        switch (settingType)
        {
            case BodyLong:
                SetCandleSettings(BodyLong, RangeType.RealBody, 10, 1.0);
                break;

            case BodyVeryLong:
                SetCandleSettings(BodyVeryLong, RangeType.RealBody, 10, 3.0);
                break;

            case BodyShort:
                SetCandleSettings(BodyShort, RangeType.RealBody, 10, 1.0);
                break;

            case BodyDoji:
                SetCandleSettings(BodyDoji, RangeType.HighLow, 10, 0.1);
                break;

            case ShadowLong:
                SetCandleSettings(ShadowLong, RangeType.RealBody, 0, 1.0);
                break;

            case ShadowVeryLong:
                SetCandleSettings(ShadowVeryLong, RangeType.RealBody, 0, 2.0);
                break;

            case ShadowShort:
                SetCandleSettings(ShadowShort, RangeType.Shadows, 10, 1.0);
                break;

            case ShadowVeryShort:
                SetCandleSettings(ShadowVeryShort, RangeType.HighLow, 10, 0.1);
                break;

            case Near:
                SetCandleSettings(Near, RangeType.HighLow, 5, 0.2);
                break;

            case Far:
                SetCandleSettings(Far, RangeType.HighLow, 5, 0.6);
                break;

            case Equal:
                SetCandleSettings(Equal, RangeType.HighLow, 5, 0.05);
                break;

            case AllCandleSettings:
                SetCandleSettings(BodyLong, RangeType.RealBody, 10, 1.0);
                SetCandleSettings(BodyVeryLong, RangeType.RealBody, 10, 3.0);
                SetCandleSettings(BodyShort, RangeType.RealBody, 10, 1.0);
                SetCandleSettings(BodyDoji, RangeType.HighLow, 10, 0.1);
                SetCandleSettings(ShadowLong, RangeType.RealBody, 0, 1.0);
                SetCandleSettings(ShadowVeryLong, RangeType.RealBody, 0, 2.0);
                SetCandleSettings(ShadowShort, RangeType.Shadows, 10, 1.0);
                SetCandleSettings(ShadowVeryShort, RangeType.HighLow, 10, 0.1);
                SetCandleSettings(Near, RangeType.HighLow, 5, 0.2);
                SetCandleSettings(Far, RangeType.HighLow, 5, 0.6);
                SetCandleSettings(Equal, RangeType.HighLow, 5, 0.05);
                break;
                
            default:
                throw new ArgumentOutOfRangeException(nameof(settingType), settingType, null);
        }
        return Success;
    }
        
    public static RetCode SetCandleSettings(CandleSettingType settingType, RangeType rangeType, int avgPeriod, double factor)
    {
        if (settingType >= AllCandleSettings)
        {
            return BadParam;
        }
            
        Globals.CandleSettings[(int)settingType].SettingType = settingType;
        Globals.CandleSettings[(int)settingType].RangeType = rangeType;
        Globals.CandleSettings[(int)settingType].AvgPeriod = avgPeriod;
        Globals.CandleSettings[(int)settingType].Factor = factor;
            
        return Success;
    }
    
    public sealed class CandleSetting
    {
        public int AvgPeriod { get; set; }
        public double Factor { get; set; }
        public RangeType RangeType { get; set; }
        public CandleSettingType SettingType { get; set; }
    }

    public enum Compatibility
    {
        Default,
        Metastock
    }
        
    public enum FuncUnstId
    {
        FuncUnstNone = -1,
        Adx = 0,
        Adxr = 1,
        Atr = 2,
        Cmo = 3,
        Dx = 4,
        Ema = 5,
        HtDcPeriod = 6,
        HtDcPhase = 7,
        HtPhasor = 8,
        HtSine = 9,
        HtTrendline = 10,
        HtTrendMode = 11,
        Kama = 12,
        Mama = 13,
        Mfi = 14,
        MinusDI = 15,
        MinusDM = 16,
        Natr = 17,
        PlusDI = 18,
        PlusDM = 19,
        Rsi = 20,
        StochRsi = 21,
        T3 = 22,
        FuncUnstAll = 23
    }
        
    public sealed class GlobalsType
    {
        public CandleSetting[] CandleSettings { get; }
        public Compatibility Compatibility { get; set; } = Compatibility.Default;
        public long[] UnstablePeriod { get; } = new long[23];

        public GlobalsType()
        {
            for (int i = 0; i < 23; i++)
            {
                UnstablePeriod[i] = 0;
            }
                
            CandleSettings = new CandleSetting[11];
                
            for (int j = 0; j < CandleSettings.Length; j++)
            {
                CandleSettings[j] = new CandleSetting();
            }
        }
    }
}
