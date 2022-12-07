using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class FinderMust
{
    [Fact]
    public void ReturnOne_WhenFindingAmountOfDirectoriesOfEmptyFileSystem()
    {
        var sut = new Finder("$ cd /\n$ ls");
        Assert.Equal(1, sut.GetDirectoryCount());
    }

    [Fact]
    public void ReturnTwo_WhenBrowsingAmountOfDirectoriesOfFileSystemWithOneDirectory()
    {
        var sut = new Finder("$ cd /\n$ ls\ndir a\n$ cd a\n$ ls");
        Assert.Equal(2, sut.GetDirectoryCount());
    }

    [Fact]
    public void ReturnTwo_WhenListingDirectoryInsideDirectoryButNeverBrowsingIt()
    {
        var sut = new Finder("$ cd /\n$ ls\ndir a");
        Assert.Equal(2, sut.GetDirectoryCount());
    }

    [Fact]
    public void ReturnCorrectAmountOfFiles()
    {
        var sut = new Finder("$ cd /\n$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\n$ cd a\n$ ls\n$ cd ..");
        Assert.Equal(2, sut.GetDirectoryCount());
        Assert.Equal(2, sut.GetFileCount());
    }

    [Fact]
    public void ParseSampleDataCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(4, sut.GetDirectoryCount());
        Assert.Equal(10, sut.GetFileCount());
    }

    [Fact]
    public void CalculateDirectorySizeCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(48381165, sut.GetDirectorySize());
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(95437, sut.GetSumOfTotalDirectoriesOfAtMost100000());
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new Finder(PUZZLE_INPUT);
        Assert.Equal(1778099, sut.GetSumOfTotalDirectoriesOfAtMost100000());
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(24933642, sut.GetSmallestDirectoryToDeleteToFreeEnoughSpace());
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new Finder(PUZZLE_INPUT);
        Assert.Equal(1623571, sut.GetSmallestDirectoryToDeleteToFreeEnoughSpace());
    }
}