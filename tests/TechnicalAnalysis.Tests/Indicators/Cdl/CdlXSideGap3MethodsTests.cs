using TechnicalAnalysis.Candles.CandleXSideGap3Methods;

namespace TechnicalAnalysis.Tests.Indicators.Cdl;

public class CdlXSideGap3MethodsTests
{
    [Theory]
    [InlineData(typeof(float))]
    [InlineData(typeof(double))]
    [InlineData(typeof(decimal))]
    [InlineData(typeof(Half))]
    public void CdlXSideGap3MethodsFloatingPoint(Type floatingPointType)
    {
        // Arrange
        var genericMethod = GetType().GetMethod(
            nameof(CdlXSideGap3Methods), BindingFlags.NonPublic | BindingFlags.Static);
        var method = genericMethod!.MakeGenericMethod(floatingPointType);
        var result = (CandleXSideGap3MethodsResult?)method.Invoke(this, null);
        
        // Assert
        result.Should().NotBeNull();
        result!.RetCode.Should().Be(RetCode.Success);
    }
    
    private static CandleXSideGap3MethodsResult CdlXSideGap3Methods<T>()
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
        var actualResult = TAMath.CdlXSideGap3Methods(
            startIdx,
            endIdx,
            open,
            high,
            low,
            close);

        return actualResult;
    }
}