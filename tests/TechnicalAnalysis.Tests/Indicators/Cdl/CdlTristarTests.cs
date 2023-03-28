using TechnicalAnalysis.Candles.CandleTristar;

namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class CdlTristarTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlTristarFloatingPoint(Type floatingPointType)
    {
        // Arrange
        var genericMethod = GetType().GetMethod(
            nameof(CdlTristar), BindingFlags.NonPublic | BindingFlags.Static);
        
        var method = genericMethod!.MakeGenericMethod(floatingPointType);
        var result = (CandleTristarResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static CandleTristarResult CdlTristar<T>()
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
        var actualResult = TAMath.CdlTristar(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}