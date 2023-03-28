namespace TechnicalAnalysis.Tests.Indicators.Func;

public class SarExtTests
{
    [Fact]
    public void SarExtDouble()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        double[] high = fixture.CreateMany<double>(100).ToArray();
        double[] low = fixture.CreateMany<double>(100).ToArray();
            
        // Act
        var actualResult = TAMath.SarExt(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
        
    [Fact]
    public void SarExtFloat()
    {
        // Arrange
        Fixture fixture = new();
        const int startIdx = 0;
        const int endIdx = 99;
        float[] high = fixture.CreateMany<float>(100).ToArray();
        float[] low = fixture.CreateMany<float>(100).ToArray();
            
        // Act
        var actualResult = TAMath.SarExt(
            startIdx,
            endIdx,
            high,
            low);

        // Assert
        actualResult.Should().NotBeNull();
        actualResult.RetCode.Should().Be(RetCode.Success);
    }
}