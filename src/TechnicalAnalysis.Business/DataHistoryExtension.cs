using System;

namespace TechnicalAnalysis.Business
{
    public static class DataHistoryExtension
    {
        public static DataHistory ComputeAcos(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Acos, priceDataPoint);

        public static DataHistory ComputeAd(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Ad, priceDataPoint);

        public static DataHistory ComputeAdd(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Add, priceDataPoint);

        public static DataHistory ComputeAdOsc(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.AdOsc, priceDataPoint);

        public static DataHistory ComputeAdx(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Adx, priceDataPoint);

        public static DataHistory ComputeAdxr(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Adxr, priceDataPoint);

        public static DataHistory ComputeApo(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Apo, priceDataPoint);

        public static DataHistory ComputeAroon(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Aroon, priceDataPoint);

        public static DataHistory ComputeAroonOsc(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.AroonOsc, priceDataPoint);

        public static DataHistory ComputeAsin(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Asin, priceDataPoint);

        public static DataHistory ComputeAtan(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Atan, priceDataPoint);

        public static DataHistory ComputeAtr(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Atr, priceDataPoint);

        public static DataHistory ComputeAvgPrice(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.AvgPrice, priceDataPoint);

        public static DataHistory ComputeBollingerBands(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.BollingerBands, priceDataPoint);

        public static DataHistory ComputeBeta(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Beta, priceDataPoint);

        public static DataHistory ComputeBop(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Bop, priceDataPoint);

        public static DataHistory ComputeCci(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cci, priceDataPoint);

        public static DataHistory ComputeCdl2Crows(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl2Crows, priceDataPoint);

        public static DataHistory ComputeCdl3BlackCrows(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3BlackCrows, priceDataPoint);

        public static DataHistory ComputeCdl3Inside(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3Inside, priceDataPoint);

        public static DataHistory ComputeCdl3LineStrike(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3LineStrike, priceDataPoint);

        public static DataHistory ComputeCdl3Outside(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3Outside, priceDataPoint);

        public static DataHistory ComputeCdl3StarsInSouth(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3StarsInSouth, priceDataPoint);

        public static DataHistory ComputeCdl3WhiteSoldiers(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cdl3WhiteSoldiers, priceDataPoint);

        public static DataHistory ComputeCdlAbandonedBaby(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlAbandonedBaby, priceDataPoint);

        public static DataHistory ComputeCdlAdvanceBlock(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlAdvanceBlock, priceDataPoint);

        public static DataHistory ComputeCdlBeltHold(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlBeltHold, priceDataPoint);

        public static DataHistory ComputeCdlBreakaway(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlBreakaway, priceDataPoint);

        public static DataHistory ComputeCdlClosingMarubozu(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlClosingMarubozu, priceDataPoint);

        public static DataHistory ComputeCdlConcealBabySwallow(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlConcealBabySwallow, priceDataPoint);

        public static DataHistory ComputeCdlCounterAttack(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlCounterAttack, priceDataPoint);

        public static DataHistory ComputeCdlDarkCloudCover(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlDarkCloudCover, priceDataPoint);

        public static DataHistory ComputeCdlDoji(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlDoji, priceDataPoint);

        public static DataHistory ComputeCdlDojiStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlDojiStar, priceDataPoint);

        public static DataHistory ComputeCdlDragonflyDoji(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlDragonflyDoji, priceDataPoint);

        public static DataHistory ComputeCdlEngulfing(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlEngulfing, priceDataPoint);

        public static DataHistory ComputeCdlEveningDojiStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlEveningDojiStar, priceDataPoint);

        public static DataHistory ComputeCdlEveningStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlEveningStar, priceDataPoint);

        public static DataHistory ComputeCdlGapSideSideWhite(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlGapSideSideWhite, priceDataPoint);

        public static DataHistory ComputeCdlGravestoneDoji(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlGravestoneDoji, priceDataPoint);

        public static DataHistory ComputeCdlHammer(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHammer, priceDataPoint);

        public static DataHistory ComputeCdlHangingMan(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHangingMan, priceDataPoint);

        public static DataHistory ComputeCdlHarami(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHarami, priceDataPoint);

        public static DataHistory ComputeCdlHaramiCross(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHaramiCross, priceDataPoint);

        public static DataHistory ComputeCdlHighWave(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHighWave, priceDataPoint);

        public static DataHistory ComputeCdlHikkake(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHikkake, priceDataPoint);

        public static DataHistory ComputeCdlHikkakeMod(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHikkakeMod, priceDataPoint);

        public static DataHistory ComputeCdlHomingPigeon(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlHomingPigeon, priceDataPoint);

        public static DataHistory ComputeCdlIdentical3Crows(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlIdentical3Crows, priceDataPoint);

        public static DataHistory ComputeCdlInNeck(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlInNeck, priceDataPoint);

        public static DataHistory ComputeCdlInvertedHammer(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlInvertedHammer, priceDataPoint);

        public static DataHistory ComputeCdlKicking(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlKicking, priceDataPoint);

        public static DataHistory ComputeCdlKickingByLength(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlKickingByLength, priceDataPoint);

        public static DataHistory ComputeCdlLadderBottom(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlLadderBottom, priceDataPoint);

        public static DataHistory ComputeCdlLongLeggedDoji(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlLongLeggedDoji, priceDataPoint);

        public static DataHistory ComputeCdlLongLine(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlLongLine, priceDataPoint);

        public static DataHistory ComputeCdlMarubozu(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlMarubozu, priceDataPoint);

        public static DataHistory ComputeCdlMatchingLow(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlMatchingLow, priceDataPoint);

        public static DataHistory ComputeCdlMatHold(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlMatHold, priceDataPoint);

        public static DataHistory ComputeCdlMorningDojiStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlMorningDojiStar, priceDataPoint);

        public static DataHistory ComputeCdlMorningStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlMorningStar, priceDataPoint);

        public static DataHistory ComputeCdlOnNeck(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlOnNeck, priceDataPoint);

        public static DataHistory ComputeCdlPiercing(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlPiercing, priceDataPoint);

        public static DataHistory ComputeCdlRickshawMan(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlRickshawMan, priceDataPoint);

        public static DataHistory ComputeCdlRiseFall3Methods(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlRiseFall3Methods, priceDataPoint);

        public static DataHistory ComputeCdlSeparatingLines(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlSeparatingLines, priceDataPoint);

        public static DataHistory ComputeCdlShootingStar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlShootingStar, priceDataPoint);

        public static DataHistory ComputeCdlShortLine(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlShortLine, priceDataPoint);

        public static DataHistory ComputeCdlSpinningTop(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlSpinningTop, priceDataPoint);

        public static DataHistory ComputeCdlStalledPattern(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlStalledPattern, priceDataPoint);

        public static DataHistory ComputeCdlStickSandwich(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlStickSandwich, priceDataPoint);

        public static DataHistory ComputeCdlTakuri(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlTakuri, priceDataPoint);

        public static DataHistory ComputeCdlTasukiGap(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlTasukiGap, priceDataPoint);

        public static DataHistory ComputeCdlThrusting(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlThrusting, priceDataPoint);

        public static DataHistory ComputeCdlTristar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlTristar, priceDataPoint);

        public static DataHistory ComputeCdlUnique3River(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlUnique3River, priceDataPoint);

        public static DataHistory ComputeCdlUpsideGap2Crows(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlUpsideGap2Crows, priceDataPoint);

        public static DataHistory ComputeCdlXSideGap3Methods(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.CdlXSideGap3Methods, priceDataPoint);

        public static DataHistory ComputeCeil(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Ceil, priceDataPoint);

        public static DataHistory ComputeCmo(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cmo, priceDataPoint);

        public static DataHistory ComputeCorrel(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Correl, priceDataPoint);

        public static DataHistory ComputeCos(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cos, priceDataPoint);

        public static DataHistory ComputeCosh(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Cosh, priceDataPoint);

        public static DataHistory ComputeDema(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Dema, priceDataPoint);

        public static DataHistory ComputeDiv(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Div, priceDataPoint);

        public static DataHistory ComputeDx(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Dx, priceDataPoint);

        public static DataHistory ComputeEma(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Ema, priceDataPoint);

        public static DataHistory ComputeExp(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Exp, priceDataPoint);

        public static DataHistory ComputeFloor(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Floor, priceDataPoint);

        public static DataHistory ComputeHtDcPeriod(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtDcPeriod, priceDataPoint);

        public static DataHistory ComputeHtDcPhase(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtDcPhase, priceDataPoint);

        public static DataHistory ComputeHtPhasor(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtPhasor, priceDataPoint);

        public static DataHistory ComputeHtSine(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtSine, priceDataPoint);

        public static DataHistory ComputeHtTrendline(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtTrendline, priceDataPoint);

        public static DataHistory ComputeHtTrendMode(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.HtTrendMode, priceDataPoint);

        public static DataHistory ComputeKama(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Kama, priceDataPoint);

        public static DataHistory ComputeLinearReg(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.LinearReg, priceDataPoint);

        public static DataHistory ComputeLinearRegAngle(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.LinearRegAngle, priceDataPoint);

        public static DataHistory ComputeLinearRegIntercept(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.LinearRegIntercept, priceDataPoint);

        public static DataHistory ComputeLinearRegSlope(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.LinearRegSlope, priceDataPoint);

        public static DataHistory ComputeLn(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Ln, priceDataPoint);

        public static DataHistory ComputeLog10(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Log10, priceDataPoint);

        public static DataHistory ComputeMacd(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Macd, priceDataPoint);

        public static DataHistory ComputeMacdExt(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MacdExt, priceDataPoint);

        public static DataHistory ComputeMacdFix(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MacdFix, priceDataPoint);

        public static DataHistory ComputeMama(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Mama, priceDataPoint);

        public static DataHistory ComputeMax(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Max, priceDataPoint);

        public static DataHistory ComputeMaxIndex(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MaxIndex, priceDataPoint);

        public static DataHistory ComputeMedPrice(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MedPrice, priceDataPoint);

        public static DataHistory ComputeMfi(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Mfi, priceDataPoint);

        public static DataHistory ComputeMidPoint(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MidPoint, priceDataPoint);

        public static DataHistory ComputeMidPrice(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MidPrice, priceDataPoint);

        public static DataHistory ComputeMin(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Min, priceDataPoint);

        public static DataHistory ComputeMinIndex(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MinIndex, priceDataPoint);

        public static DataHistory ComputeMinMax(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MinMax, priceDataPoint);

        public static DataHistory ComputeMinMaxIndex(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MinMaxIndex, priceDataPoint);

        public static DataHistory ComputeMinusDI(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MinusDI, priceDataPoint);

        public static DataHistory ComputeMinusDM(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MinusDM, priceDataPoint);

        public static DataHistory ComputeMom(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Mom, priceDataPoint);

        public static DataHistory ComputeMovingAverage(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MovingAverage, priceDataPoint);

        public static DataHistory ComputeMovingAverageVariablePeriod(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.MovingAverageVariablePeriod, priceDataPoint);

        public static DataHistory ComputeMult(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Mult, priceDataPoint);

        public static DataHistory ComputeNatr(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Natr, priceDataPoint);

        public static DataHistory ComputeObv(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Obv, priceDataPoint);

        public static DataHistory ComputePlusDI(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.PlusDI, priceDataPoint);

        public static DataHistory ComputePlusDM(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.PlusDM, priceDataPoint);

        public static DataHistory ComputePpo(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Ppo, priceDataPoint);

        public static DataHistory ComputeRoc(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Roc, priceDataPoint);

        public static DataHistory ComputeRocP(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.RocP, priceDataPoint);

        public static DataHistory ComputeRocR(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.RocR, priceDataPoint);

        public static DataHistory ComputeRocR100(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.RocR100, priceDataPoint);

        public static DataHistory ComputeRsi(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Rsi, priceDataPoint);

        public static DataHistory ComputeSar(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sar, priceDataPoint);

        public static DataHistory ComputeSarExt(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.SarExt, priceDataPoint);

        public static DataHistory ComputeSin(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sin, priceDataPoint);

        public static DataHistory ComputeSinh(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sinh, priceDataPoint);

        public static DataHistory ComputeSma(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sma, priceDataPoint);

        public static DataHistory ComputeSqrt(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sqrt, priceDataPoint);

        public static DataHistory ComputeStdDev(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.StdDev, priceDataPoint);

        public static DataHistory ComputeStoch(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Stoch, priceDataPoint);

        public static DataHistory ComputeStochF(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.StochF, priceDataPoint);

        public static DataHistory ComputeStochRsi(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.StochRsi, priceDataPoint);

        public static DataHistory ComputeSub(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sub, priceDataPoint);

        public static DataHistory ComputeSum(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Sum, priceDataPoint);

        public static DataHistory ComputeT3(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.T3, priceDataPoint);

        public static DataHistory ComputeTan(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Tan, priceDataPoint);

        public static DataHistory ComputeTanh(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Tanh, priceDataPoint);

        public static DataHistory ComputeTema(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Tema, priceDataPoint);

        public static DataHistory ComputeTrima(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Trima, priceDataPoint);

        public static DataHistory ComputeTrix(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Trix, priceDataPoint);

        public static DataHistory ComputeTrueRange(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.TrueRange, priceDataPoint);

        public static DataHistory ComputeTsf(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Tsf, priceDataPoint);

        public static DataHistory ComputeTypPrice(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.TypPrice, priceDataPoint);

        public static DataHistory ComputeUltOsc(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.UltOsc, priceDataPoint);

        public static DataHistory ComputeVariance(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Variance, priceDataPoint);

        public static DataHistory ComputeWclPrice(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.WclPrice, priceDataPoint);

        public static DataHistory ComputeWillR(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.WillR, priceDataPoint);

        public static DataHistory ComputeWma(
            this DataHistory dataHistory,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close) =>
            dataHistory.ComputeIndicator(Indicator.Wma, priceDataPoint);



        public static DataHistory ComputeIndicator(
            this DataHistory dh,
            Indicator indicator,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close)
        {
            return dh.ComputeIndicator(indicator, 0, dh.Average.Length - 1, priceDataPoint);
        }

        public static DataHistory ComputeIndicator(
            this DataHistory dh,
            Indicator indicator,
            int startIdx,
            int endIdx,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close)
        {
            var result = dh.ComputeIndicatorBase(indicator, priceDataPoint);
            dh.Indicators.Add(indicator, result);
            return dh;
        }



        private static IndicatorBase ComputeIndicatorBase(
            this DataHistory dh,
            Indicator indicator,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close)
        {
            return dh.ComputeIndicatorBase(indicator, 0, dh.Average.Length - 1, priceDataPoint);
        }

        private static IndicatorBase ComputeIndicatorBase(
            this DataHistory dh,
            Indicator indicator,
            int startIdx,
            int endIdx,
            PriceDataPoint priceDataPoint = PriceDataPoint.Close)
        {
            double[] real = dh.GetPriceData(priceDataPoint);

            return indicator switch
            {
                Indicator.Acos => TAMath.Acos(startIdx, endIdx, real),
                Indicator.Ad => TAMath.Ad(startIdx, endIdx, dh.High, dh.Low, dh.Close, dh.Volume),
                // Indicator.Add => TAMath.Add(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.AdOsc => TAMath.AdOsc(startIdx, endIdx, dh.High, dh.Low, dh.Close, dh.Volume),
                Indicator.Adx => TAMath.Adx(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Adxr => TAMath.Adxr(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Apo => TAMath.Apo(startIdx, endIdx, real),
                Indicator.Aroon => TAMath.Aroon(startIdx, endIdx, dh.High, dh.Low),
                Indicator.AroonOsc => TAMath.AroonOsc(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Asin => TAMath.Asin(startIdx, endIdx, real),
                Indicator.Atan => TAMath.Atan(startIdx, endIdx, real),
                Indicator.Atr => TAMath.Atr(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.AvgPrice => TAMath.AvgPrice(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.BollingerBands => TAMath.BollingerBands(startIdx, endIdx, real),
                // Indicator.Beta => TAMath.Beta(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.Bop => TAMath.Bop(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cci => TAMath.Cci(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Cdl2Crows => TAMath.Cdl2Crows(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3BlackCrows => TAMath.Cdl3BlackCrows(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3Inside => TAMath.Cdl3Inside(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3LineStrike => TAMath.Cdl3LineStrike(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3Outside => TAMath.Cdl3Outside(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3StarsInSouth => TAMath.Cdl3StarsInSouth(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Cdl3WhiteSoldiers => TAMath.Cdl3WhiteSoldiers(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlAbandonedBaby => TAMath.CdlAbandonedBaby(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlAdvanceBlock => TAMath.CdlAdvanceBlock(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlBeltHold => TAMath.CdlBeltHold(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlBreakaway => TAMath.CdlBreakaway(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlClosingMarubozu => TAMath.CdlClosingMarubozu(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlConcealBabySwallow => TAMath.CdlConcealBabySwallow(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlCounterAttack => TAMath.CdlCounterAttack(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlDarkCloudCover => TAMath.CdlDarkCloudCover(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlDoji => TAMath.CdlDoji(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlDojiStar => TAMath.CdlDojiStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlDragonflyDoji => TAMath.CdlDragonflyDoji(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlEngulfing => TAMath.CdlEngulfing(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlEveningDojiStar => TAMath.CdlEveningDojiStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlEveningStar => TAMath.CdlEveningStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlGapSideSideWhite => TAMath.CdlGapSideSideWhite(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlGravestoneDoji => TAMath.CdlGravestoneDoji(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHammer => TAMath.CdlHammer(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHangingMan => TAMath.CdlHangingMan(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHarami => TAMath.CdlHarami(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHaramiCross => TAMath.CdlHaramiCross(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHighWave => TAMath.CdlHighWave(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHikkake => TAMath.CdlHikkake(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHikkakeMod => TAMath.CdlHikkakeMod(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlHomingPigeon => TAMath.CdlHomingPigeon(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlIdentical3Crows => TAMath.CdlIdentical3Crows(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlInNeck => TAMath.CdlInNeck(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlInvertedHammer => TAMath.CdlInvertedHammer(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlKicking => TAMath.CdlKicking(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlKickingByLength => TAMath.CdlKickingByLength(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlLadderBottom => TAMath.CdlLadderBottom(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlLongLeggedDoji => TAMath.CdlLongLeggedDoji(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlLongLine => TAMath.CdlLongLine(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlMarubozu => TAMath.CdlMarubozu(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlMatchingLow => TAMath.CdlMatchingLow(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlMatHold => TAMath.CdlMatHold(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlMorningDojiStar => TAMath.CdlMorningDojiStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlMorningStar => TAMath.CdlMorningStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlOnNeck => TAMath.CdlOnNeck(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlPiercing => TAMath.CdlPiercing(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlRickshawMan => TAMath.CdlRickshawMan(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlRiseFall3Methods => TAMath.CdlRiseFall3Methods(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlSeparatingLines => TAMath.CdlSeparatingLines(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlShootingStar => TAMath.CdlShootingStar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlShortLine => TAMath.CdlShortLine(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlSpinningTop => TAMath.CdlSpinningTop(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlStalledPattern => TAMath.CdlStalledPattern(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlStickSandwich => TAMath.CdlStickSandwich(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlTakuri => TAMath.CdlTakuri(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlTasukiGap => TAMath.CdlTasukiGap(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlThrusting => TAMath.CdlThrusting(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlTristar => TAMath.CdlTristar(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlUnique3River => TAMath.CdlUnique3River(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlUpsideGap2Crows => TAMath.CdlUpsideGap2Crows(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.CdlXSideGap3Methods => TAMath.CdlXSideGap3Methods(startIdx, endIdx, dh.Open, dh.High, dh.Low, dh.Close),
                Indicator.Ceil => TAMath.Ceil(startIdx, endIdx, real),
                Indicator.Cmo => TAMath.Cmo(startIdx, endIdx, real),
                // Indicator.Correl => TAMath.Correl(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.Cos => TAMath.Cos(startIdx, endIdx, real),
                Indicator.Cosh => TAMath.Cosh(startIdx, endIdx, real),
                Indicator.Dema => TAMath.Dema(startIdx, endIdx, real),
                // Indicator.Div => TAMath.Div(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.Dx => TAMath.Dx(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Ema => TAMath.Ema(startIdx, endIdx, real),
                Indicator.Exp => TAMath.Exp(startIdx, endIdx, real),
                Indicator.Floor => TAMath.Floor(startIdx, endIdx, real),
                Indicator.HtDcPeriod => TAMath.HtDcPeriod(startIdx, endIdx, real),
                Indicator.HtDcPhase => TAMath.HtDcPhase(startIdx, endIdx, real),
                Indicator.HtPhasor => TAMath.HtPhasor(startIdx, endIdx, real),
                Indicator.HtSine => TAMath.HtSine(startIdx, endIdx, real),
                Indicator.HtTrendline => TAMath.HtTrendline(startIdx, endIdx, real),
                Indicator.HtTrendMode => TAMath.HtTrendMode(startIdx, endIdx, real),
                Indicator.Kama => TAMath.Kama(startIdx, endIdx, real),
                Indicator.LinearReg => TAMath.LinearReg(startIdx, endIdx, real),
                Indicator.LinearRegAngle => TAMath.LinearRegAngle(startIdx, endIdx, real),
                Indicator.LinearRegIntercept => TAMath.LinearRegIntercept(startIdx, endIdx, real),
                Indicator.LinearRegSlope => TAMath.LinearRegSlope(startIdx, endIdx, real),
                Indicator.Ln => TAMath.Ln(startIdx, endIdx, real),
                Indicator.Log10 => TAMath.Log10(startIdx, endIdx, real),
                Indicator.Macd => TAMath.Macd(startIdx, endIdx, real),
                Indicator.MacdExt => TAMath.MacdExt(startIdx, endIdx, real),
                Indicator.MacdFix => TAMath.MacdFix(startIdx, endIdx, real),
                Indicator.Mama => TAMath.Mama(startIdx, endIdx, real),
                Indicator.Max => TAMath.Max(startIdx, endIdx, real),
                Indicator.MaxIndex => TAMath.MaxIndex(startIdx, endIdx, real),
                Indicator.MedPrice => TAMath.MedPrice(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Mfi => TAMath.Mfi(startIdx, endIdx, dh.High, dh.Low, dh.Close, dh.Volume),
                Indicator.MidPoint => TAMath.MidPoint(startIdx, endIdx, real),
                Indicator.MidPrice => TAMath.MidPrice(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Min => TAMath.Min(startIdx, endIdx, real),
                Indicator.MinIndex => TAMath.MinIndex(startIdx, endIdx, real),
                Indicator.MinMax => TAMath.MinMax(startIdx, endIdx, real),
                Indicator.MinMaxIndex => TAMath.MinMaxIndex(startIdx, endIdx, real),
                Indicator.MinusDI => TAMath.MinusDI(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.MinusDM => TAMath.MinusDM(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Mom => TAMath.Mom(startIdx, endIdx, real),
                Indicator.MovingAverage => TAMath.MovingAverage(startIdx, endIdx, real),
                // Indicator.MovingAverageVariablePeriod => TAMath.MovingAverageVariablePeriod(startIdx, endIdx, real, dataHistory.Periods),
                // Indicator.Mult => TAMath.Mult(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.Natr => TAMath.Natr(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Obv => TAMath.Obv(startIdx, endIdx, real, dh.Volume),
                Indicator.PlusDI => TAMath.PlusDI(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.PlusDM => TAMath.PlusDM(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Ppo => TAMath.Ppo(startIdx, endIdx, real),
                Indicator.Roc => TAMath.Roc(startIdx, endIdx, real),
                Indicator.RocP => TAMath.RocP(startIdx, endIdx, real),
                Indicator.RocR => TAMath.RocR(startIdx, endIdx, real),
                Indicator.RocR100 => TAMath.RocR100(startIdx, endIdx, real),
                Indicator.Rsi => TAMath.Rsi(startIdx, endIdx, real),
                Indicator.Sar => TAMath.Sar(startIdx, endIdx, dh.High, dh.Low),
                Indicator.SarExt => TAMath.SarExt(startIdx, endIdx, dh.High, dh.Low),
                Indicator.Sin => TAMath.Sin(startIdx, endIdx, real),
                Indicator.Sinh => TAMath.Sinh(startIdx, endIdx, real),
                Indicator.Sma => TAMath.Sma(startIdx, endIdx, real),
                Indicator.Sqrt => TAMath.Sqrt(startIdx, endIdx, real),
                Indicator.StdDev => TAMath.StdDev(startIdx, endIdx, real),
                Indicator.Stoch => TAMath.Stoch(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.StochF => TAMath.StochF(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.StochRsi => TAMath.StochRsi(startIdx, endIdx, real),
                // Indicator.Sub => TAMath.Sub(startIdx, endIdx, dataHistory.Real0, dataHistory.Real1),
                Indicator.Sum => TAMath.Sum(startIdx, endIdx, real),
                Indicator.T3 => TAMath.T3(startIdx, endIdx, real),
                Indicator.Tan => TAMath.Tan(startIdx, endIdx, real),
                Indicator.Tanh => TAMath.Tanh(startIdx, endIdx, real),
                Indicator.Tema => TAMath.Tema(startIdx, endIdx, real),
                Indicator.Trima => TAMath.Trima(startIdx, endIdx, real),
                Indicator.Trix => TAMath.Trix(startIdx, endIdx, real),
                Indicator.TrueRange => TAMath.TrueRange(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Tsf => TAMath.Tsf(startIdx, endIdx, real),
                Indicator.TypPrice => TAMath.TypPrice(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.UltOsc => TAMath.UltOsc(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Variance => TAMath.Variance(startIdx, endIdx, real),
                Indicator.WclPrice => TAMath.WclPrice(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.WillR => TAMath.WillR(startIdx, endIdx, dh.High, dh.Low, dh.Close),
                Indicator.Wma => TAMath.Wma(startIdx, endIdx, real),
                _ => throw new ArgumentOutOfRangeException(nameof(indicator), indicator, null)
            };
        }

        private static double[] GetPriceData(this DataHistory dataHistory, PriceDataPoint priceDataPoint)
        {
            return priceDataPoint switch
            {
                PriceDataPoint.Open => dataHistory.Open,
                PriceDataPoint.High => dataHistory.High,
                PriceDataPoint.Low => dataHistory.Low,
                PriceDataPoint.Close => dataHistory.Close,
                PriceDataPoint.Average => dataHistory.Average,
                _ => throw new ArgumentOutOfRangeException(nameof(priceDataPoint), priceDataPoint, null)
            };
        }
    }
}
