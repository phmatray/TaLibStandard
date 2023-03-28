using TechnicalAnalysis.Candles.CandleInNeck;

namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class CdlInNeckTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlInNeckFloatingPoint(Type floatingPointType)
    {
        // Arrange
        var genericMethod = GetType().GetMethod(
            nameof(CdlInNeck), BindingFlags.NonPublic | BindingFlags.Static);
        var method = genericMethod!.MakeGenericMethod(floatingPointType);
        var result = (CandleInNeckResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static CandleInNeckResult CdlInNeck<T>()
        where T : IFloatingPoint<T>
    {
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        var open = fixture.CreateMany<T>(100).ToArray();
        var high = fixture.CreateMany<T>(100).ToArray();
        var low = fixture.CreateMany<T>(100).ToArray();
        var close = fixture.CreateMany<T>(100).ToArray();
            
        // Act
        var actualResult = TAMath.CdlInNeck(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}