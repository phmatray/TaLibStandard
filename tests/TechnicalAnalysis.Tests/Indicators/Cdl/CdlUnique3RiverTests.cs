using TechnicalAnalysis.Candles.CandleUnique3River;
namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class CdlUnique3RiverTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlUnique3RiverFloatingPoint(Type floatingPointType)
    {
        // Arrange
        var genericMethod = GetType().GetMethod(
            nameof(CdlUnique3River), BindingFlags.NonPublic | BindingFlags.Static);
        
        var method = genericMethod!.MakeGenericMethod(floatingPointType);
        var result = (CandleUnique3RiverResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }

    private static CandleUnique3RiverResult CdlUnique3River<T>()
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
        var actualResult = TAMath.CdlUnique3River(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}