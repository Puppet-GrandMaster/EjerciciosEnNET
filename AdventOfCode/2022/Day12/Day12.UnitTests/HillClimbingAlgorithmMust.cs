using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class HillClimbingAlgorithmMust
{
    [Theory]
    [InlineData("SE", 1)]
    [InlineData("SaE", 2)]
    [InlineData("SabE", 3)]
    public void FindSteps_WhenMapIsHorizontal(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }

    [Theory]
    [InlineData("S\nE", 1)]
    public void FindSteps_WhenMapIsVertical(string input, int expectedValue)
    {
        var sut = new HillClimbingAlgorithm(input);
        Assert.Equal(expectedValue, sut.FewestStepsToTarget);
    }
}