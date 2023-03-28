using TechnicalAnalysis.Candles.Candle2Crows;

namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class Cdl2CrowsTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void Cdl2CrowsFloatingPoint(Type floatingPointType)
    {
        // Arrange
        var genericMethod = GetType().GetMethod(
            nameof(Cdl2Crows), BindingFlags.NonPublic | BindingFlags.Static);
        
        var method = genericMethod!.MakeGenericMethod(floatingPointType);
        var result = (Candle2CrowsResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static Candle2CrowsResult Cdl2Crows<T>()
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
        var actualResult = TAMath.Cdl2Crows(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}