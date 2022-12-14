using Day14.Logic;
using static Day14.UnitTests.Constants;

namespace Day14.UnitTests;

public class SandFallingSimulatorMust
{
    [Fact]
    public void Test1()
    {
        var sut = new SandFallingSimulator(SAMPLE_INPUT);
        Assert.Equal(@"..........
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
........#.
#########.", sut.GetVisualMap());
    }
}