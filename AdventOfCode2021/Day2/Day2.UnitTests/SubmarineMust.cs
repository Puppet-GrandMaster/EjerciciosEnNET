using System;
using Xunit;
using Day2.Logic;

namespace Day2.UnitTests
{
    public class SubmarineMust
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void ThrowException_WhenCourseIsInvalid(string invalidCourse)
        {
            var exception = Assert.Throws<ArgumentException>(() => Submarine.CreateSimpleSubmarineFor(invalidCourse));
            Assert.Equal("Invalid course", exception.Message);
        }

        [Theory]
        [InlineData("forward 5", 5)]
        [InlineData(@"forward 5
down 5
forward 8", 13)]
        [InlineData(@"forward 5
down 5
forward 8
forward 2", 15)]
        public void CalculateHorizontalPositionCorrectly(string course, int expectedPosition)
        {
            var sut = Submarine.CreateSimpleSubmarineFor(course);
            Assert.Equal(expectedPosition, sut.HorizontalPosition);
        }

        [Theory]
        [InlineData(@"forward 5
down 5", 5)]
        [InlineData(@"forward 5
down 5
forward 8
up 3", 2)]
        public void CalculateDepthCorrectly(string course, int expectedDepth)
        {
            var sut = Submarine.CreateSimpleSubmarineFor(course);
            Assert.Equal(expectedDepth, sut.Depth);
        }

        [Fact]
        public void SolveFirstSample()
        {
            const string COURSE = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var sut = Submarine.CreateSimpleSubmarineFor(COURSE);
            Assert.Equal(150, sut.Multiplier);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string COURSE = @"forward 2
forward 3
forward 5
forward 6
down 7
forward 8
forward 4
forward 7
forward 5
forward 5
down 4
down 9
forward 8
forward 5
up 5
down 5
forward 3
down 4
down 8
forward 9
down 1
up 9
down 7
up 7
up 1
forward 1
down 1
down 4
down 4
down 8
down 4
up 3
down 1
down 3
forward 7
down 6
forward 3
forward 5
forward 2
up 9
forward 7
up 5
down 3
forward 1
forward 2
down 3
down 8
down 3
forward 8
up 5
down 5
forward 3
down 5
forward 9
down 3
down 4
down 9
down 7
up 3
down 9
up 9
up 1
forward 3
up 4
down 3
forward 7
forward 7
up 7
forward 6
down 7
down 6
forward 2
forward 9
down 5
forward 4
up 6
down 1
down 9
down 9
forward 4
down 1
forward 6
down 1
down 5
down 4
down 4
forward 4
forward 9
up 1
down 2
down 8
down 5
down 8
down 8
up 2
forward 8
up 1
forward 4
down 5
down 1
up 2
forward 6
forward 9
forward 2
forward 6
forward 9
up 6
forward 9
up 4
down 7
up 6
forward 2
down 1
up 3
forward 1
forward 8
down 6
down 8
down 8
forward 8
forward 2
forward 2
down 2
up 1
down 9
up 9
down 9
up 3
forward 9
up 4
up 7
up 6
down 9
forward 1
down 3
down 4
forward 8
down 3
down 9
up 3
forward 2
up 5
down 3
forward 8
up 3
down 3
forward 2
forward 9
down 1
down 9
down 4
up 7
down 4
up 6
forward 5
down 6
forward 3
down 2
forward 1
forward 8
down 4
forward 1
up 7
forward 6
up 9
forward 6
down 3
forward 2
down 4
forward 6
down 3
down 6
down 1
down 1
down 5
forward 3
forward 9
forward 8
down 3
forward 7
up 9
forward 9
up 2
forward 4
up 3
forward 1
up 6
up 8
down 5
down 6
up 9
down 6
down 9
up 9
down 4
forward 5
up 2
down 3
up 3
down 1
forward 3
down 5
forward 7
down 6
down 7
down 5
forward 2
up 6
down 9
down 4
down 3
forward 9
up 8
forward 2
down 2
forward 4
up 6
down 4
up 8
down 7
down 2
up 6
up 4
down 2
forward 5
up 4
down 8
forward 3
forward 1
down 7
forward 8
forward 7
down 7
up 4
forward 8
down 5
up 9
forward 1
forward 4
forward 9
forward 7
down 9
up 9
down 1
down 7
forward 7
down 7
down 7
down 3
down 5
forward 3
down 2
forward 6
down 9
up 5
up 3
forward 5
down 6
down 1
forward 4
down 3
forward 8
down 7
forward 7
forward 7
up 7
up 2
up 3
forward 9
down 5
up 2
forward 5
up 5
forward 2
forward 2
down 8
forward 2
up 4
forward 1
forward 3
up 8
up 9
forward 5
down 1
up 8
down 4
down 8
up 4
forward 9
down 6
down 8
up 2
up 3
down 7
down 4
forward 5
down 6
forward 3
forward 3
forward 8
down 1
down 7
down 9
down 2
down 7
forward 7
down 7
down 6
up 6
forward 8
forward 5
up 5
down 2
up 8
up 4
down 9
up 2
forward 5
up 2
down 4
up 4
forward 2
forward 4
forward 9
forward 9
up 4
up 5
down 1
down 6
down 1
down 4
down 5
down 3
forward 3
down 9
forward 6
down 3
down 9
down 2
up 2
down 2
down 7
forward 9
down 3
down 3
down 2
down 3
forward 2
down 9
down 9
up 5
up 3
forward 4
up 7
forward 8
up 6
forward 7
down 7
down 1
forward 5
down 2
up 1
down 8
up 3
forward 2
up 9
down 1
down 3
down 6
down 2
down 7
up 2
forward 5
forward 7
down 2
forward 5
forward 4
forward 5
down 3
forward 7
down 7
forward 8
down 3
down 2
up 1
forward 6
down 4
down 2
forward 7
up 3
down 4
forward 2
up 6
down 3
up 6
up 8
down 9
up 6
forward 8
forward 9
forward 4
forward 7
down 2
forward 9
down 7
up 9
down 5
down 6
up 5
down 4
forward 8
forward 4
forward 4
down 6
forward 3
forward 6
down 9
down 9
up 2
forward 7
down 8
down 9
down 9
forward 7
forward 3
down 7
down 8
forward 8
down 6
down 5
down 9
down 3
forward 1
down 5
forward 2
forward 8
down 2
forward 6
forward 3
down 7
down 4
forward 8
forward 1
down 6
forward 9
forward 6
up 1
up 3
down 8
forward 1
up 5
down 4
forward 7
up 3
down 2
forward 1
forward 9
down 9
down 7
forward 8
down 4
up 3
down 4
forward 2
forward 6
down 7
forward 6
down 6
down 4
down 1
up 9
down 4
down 7
up 4
down 9
forward 6
down 3
forward 2
down 4
forward 3
down 5
up 9
forward 8
up 7
up 6
up 4
forward 1
down 1
forward 4
up 6
forward 5
forward 4
forward 5
up 6
down 1
forward 3
up 7
down 9
up 9
down 5
forward 6
forward 4
up 1
down 4
up 1
forward 3
forward 1
down 3
forward 7
down 2
forward 3
up 2
forward 8
down 3
up 9
down 5
forward 6
down 1
down 8
down 5
forward 1
down 6
up 2
forward 6
down 2
down 1
up 6
up 7
down 5
forward 7
forward 6
forward 6
down 7
forward 4
down 5
up 5
down 1
up 8
down 8
down 2
down 2
down 9
up 9
forward 2
forward 7
down 7
down 4
down 4
down 8
forward 5
forward 2
up 9
down 9
forward 7
up 9
down 2
down 7
up 2
up 8
forward 8
down 4
forward 3
forward 4
forward 6
forward 2
down 1
down 2
forward 2
up 1
down 1
forward 5
up 3
up 3
down 3
down 1
down 4
up 5
up 6
forward 5
up 7
forward 6
down 4
down 7
up 8
forward 1
down 5
up 4
up 3
up 5
down 1
up 5
forward 3
up 5
forward 2
forward 2
forward 5
forward 2
up 9
forward 4
down 1
down 3
down 5
up 2
down 8
forward 8
forward 9
down 1
down 3
forward 8
forward 2
down 2
down 1
up 7
forward 2
forward 8
down 9
forward 1
forward 4
down 7
down 4
up 7
down 3
down 1
down 4
up 7
down 6
forward 7
down 8
up 2
up 4
up 6
down 9
down 9
down 8
forward 6
up 3
up 1
forward 9
forward 6
up 4
up 2
up 7
forward 5
up 9
up 9
forward 9
up 6
down 1
down 3
forward 3
down 2
down 2
down 6
down 9
forward 3
forward 7
up 3
forward 3
down 5
forward 9
up 6
down 2
forward 8
down 3
up 5
down 6
forward 9
down 5
down 2
down 6
forward 8
forward 6
down 1
forward 6
up 1
up 7
down 4
down 7
forward 4
forward 7
down 4
forward 8
down 8
down 7
forward 9
down 1
down 3
down 6
forward 7
forward 6
forward 3
forward 8
down 5
down 3
up 1
down 9
down 8
forward 3
down 6
down 1
forward 5
forward 5
forward 9
up 5
down 6
up 9
down 7
down 6
up 1
forward 5
forward 7
forward 8
forward 7
forward 6
forward 3
forward 1
forward 2
up 4
forward 3
forward 4
forward 5
up 2
up 3
forward 4
down 9
up 4
forward 7
down 6
down 6
down 1
forward 2
down 2
forward 2
down 3
forward 7
forward 8
down 4
up 7
forward 7
down 7
forward 7
forward 9
down 7
up 2
down 3
forward 7
down 1
forward 8
forward 2
up 9
down 3
forward 2
up 4
forward 9
down 4
down 4
forward 4
down 2
down 9
forward 4
down 2
down 6
forward 9
forward 2
up 1
forward 2
forward 3
down 5
up 8
down 4
down 4
forward 7
down 2
up 6
down 9
forward 9
up 1
forward 3
down 5
forward 3
down 3
forward 4
up 3
down 6
down 7
down 4
down 8
down 4
down 5
up 9
up 1
down 7
up 3
up 3
down 3
up 4
up 6
forward 8
down 1
forward 7
forward 4
down 9
down 1
forward 7
forward 9
forward 1
down 3
down 2
forward 3
forward 2
down 7
forward 9
forward 6
up 9
down 2
forward 9
up 6
forward 8
up 1
down 5
down 8
forward 1
down 1
forward 9
up 1
forward 9
forward 1
forward 1
down 7
forward 3
forward 6
down 5
forward 7
forward 1
down 7
down 6
down 6
forward 5
up 6
down 6
forward 8
up 2
down 8
down 3
up 5
up 8
down 6
forward 4
forward 2
up 3
forward 5
forward 3
up 8
forward 6
up 8
forward 1
up 8
up 7
up 6
forward 2
down 9
down 9
forward 3
down 7
forward 3
down 6
forward 9
up 5
down 1
forward 7
down 1
down 5
down 9
forward 8
forward 9
forward 7
down 9
up 4
forward 5
down 5
forward 5
down 9
forward 9
forward 3
up 5
forward 8
up 5
down 1
forward 8
down 3
forward 6
up 9
forward 8
down 4
forward 3
down 5
forward 8
forward 9
forward 2
down 1
down 6
down 4
forward 9
up 2
down 3
down 6
down 3
down 9
down 1
up 6
down 2
down 7
up 5
forward 5
up 1
down 7
forward 6
up 6
down 2
down 3
forward 3
down 5
forward 8
down 9
down 7
down 8
up 7
down 1
forward 1
forward 1
down 2
up 4
forward 2
down 3
up 2
down 3
down 2
forward 7
down 1
up 7
down 2
down 1
forward 6
down 9
up 9
down 4
down 6
up 9
forward 7
forward 9
forward 7
down 4
down 1
forward 7
down 4
down 7
down 3
down 5
forward 3
down 8
forward 8
forward 7
forward 8
down 4
down 9
forward 2
forward 7
up 8
forward 4
down 6
up 8
down 2
forward 3
down 6
down 8
forward 8
forward 2
forward 9
up 6
forward 7
down 3
down 5
forward 8
forward 9
down 3
forward 3
forward 2
forward 3
down 8
up 9
up 5
up 2
up 6
up 1
up 1
up 5
forward 3
forward 2
down 3
forward 4";

            var sut = Submarine.CreateSimpleSubmarineFor(COURSE);
            Assert.Equal(1692075, sut.Multiplier);
        }

        [Fact]
        public void BeInitializedCorrectly()
        {
            var sut = Submarine.CreateSimpleSubmarineFor("forward 0");
            Assert.Equal(0, sut.HorizontalPosition);
            Assert.Equal(0, sut.Depth);
            Assert.Equal(0, sut.Aim);
        }

        [Theory]
        [InlineData(@"forward 5
down 5", 5, 0)]
        [InlineData(@"forward 5
down 5
forward 8", 5, 40)]
        public void Test1(string course, int expectedAim, int expectedDepth)
        {
            var sut = Submarine.CreateComplexSubmarineFor(course);
            Assert.Equal(expectedDepth, sut.Depth);
            Assert.Equal(expectedAim, sut.Aim);
        }

        [Fact]
        public void SolveSecondSample()
        {
            const string COURSE = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var sut = Submarine.CreateComplexSubmarineFor(COURSE);
            Assert.Equal(15, sut.HorizontalPosition);
            Assert.Equal(10, sut.Aim);
            Assert.Equal(60, sut.Depth);
            Assert.Equal(900, sut.Multiplier);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            const string COURSE = @"forward 2
forward 3
forward 5
forward 6
down 7
forward 8
forward 4
forward 7
forward 5
forward 5
down 4
down 9
forward 8
forward 5
up 5
down 5
forward 3
down 4
down 8
forward 9
down 1
up 9
down 7
up 7
up 1
forward 1
down 1
down 4
down 4
down 8
down 4
up 3
down 1
down 3
forward 7
down 6
forward 3
forward 5
forward 2
up 9
forward 7
up 5
down 3
forward 1
forward 2
down 3
down 8
down 3
forward 8
up 5
down 5
forward 3
down 5
forward 9
down 3
down 4
down 9
down 7
up 3
down 9
up 9
up 1
forward 3
up 4
down 3
forward 7
forward 7
up 7
forward 6
down 7
down 6
forward 2
forward 9
down 5
forward 4
up 6
down 1
down 9
down 9
forward 4
down 1
forward 6
down 1
down 5
down 4
down 4
forward 4
forward 9
up 1
down 2
down 8
down 5
down 8
down 8
up 2
forward 8
up 1
forward 4
down 5
down 1
up 2
forward 6
forward 9
forward 2
forward 6
forward 9
up 6
forward 9
up 4
down 7
up 6
forward 2
down 1
up 3
forward 1
forward 8
down 6
down 8
down 8
forward 8
forward 2
forward 2
down 2
up 1
down 9
up 9
down 9
up 3
forward 9
up 4
up 7
up 6
down 9
forward 1
down 3
down 4
forward 8
down 3
down 9
up 3
forward 2
up 5
down 3
forward 8
up 3
down 3
forward 2
forward 9
down 1
down 9
down 4
up 7
down 4
up 6
forward 5
down 6
forward 3
down 2
forward 1
forward 8
down 4
forward 1
up 7
forward 6
up 9
forward 6
down 3
forward 2
down 4
forward 6
down 3
down 6
down 1
down 1
down 5
forward 3
forward 9
forward 8
down 3
forward 7
up 9
forward 9
up 2
forward 4
up 3
forward 1
up 6
up 8
down 5
down 6
up 9
down 6
down 9
up 9
down 4
forward 5
up 2
down 3
up 3
down 1
forward 3
down 5
forward 7
down 6
down 7
down 5
forward 2
up 6
down 9
down 4
down 3
forward 9
up 8
forward 2
down 2
forward 4
up 6
down 4
up 8
down 7
down 2
up 6
up 4
down 2
forward 5
up 4
down 8
forward 3
forward 1
down 7
forward 8
forward 7
down 7
up 4
forward 8
down 5
up 9
forward 1
forward 4
forward 9
forward 7
down 9
up 9
down 1
down 7
forward 7
down 7
down 7
down 3
down 5
forward 3
down 2
forward 6
down 9
up 5
up 3
forward 5
down 6
down 1
forward 4
down 3
forward 8
down 7
forward 7
forward 7
up 7
up 2
up 3
forward 9
down 5
up 2
forward 5
up 5
forward 2
forward 2
down 8
forward 2
up 4
forward 1
forward 3
up 8
up 9
forward 5
down 1
up 8
down 4
down 8
up 4
forward 9
down 6
down 8
up 2
up 3
down 7
down 4
forward 5
down 6
forward 3
forward 3
forward 8
down 1
down 7
down 9
down 2
down 7
forward 7
down 7
down 6
up 6
forward 8
forward 5
up 5
down 2
up 8
up 4
down 9
up 2
forward 5
up 2
down 4
up 4
forward 2
forward 4
forward 9
forward 9
up 4
up 5
down 1
down 6
down 1
down 4
down 5
down 3
forward 3
down 9
forward 6
down 3
down 9
down 2
up 2
down 2
down 7
forward 9
down 3
down 3
down 2
down 3
forward 2
down 9
down 9
up 5
up 3
forward 4
up 7
forward 8
up 6
forward 7
down 7
down 1
forward 5
down 2
up 1
down 8
up 3
forward 2
up 9
down 1
down 3
down 6
down 2
down 7
up 2
forward 5
forward 7
down 2
forward 5
forward 4
forward 5
down 3
forward 7
down 7
forward 8
down 3
down 2
up 1
forward 6
down 4
down 2
forward 7
up 3
down 4
forward 2
up 6
down 3
up 6
up 8
down 9
up 6
forward 8
forward 9
forward 4
forward 7
down 2
forward 9
down 7
up 9
down 5
down 6
up 5
down 4
forward 8
forward 4
forward 4
down 6
forward 3
forward 6
down 9
down 9
up 2
forward 7
down 8
down 9
down 9
forward 7
forward 3
down 7
down 8
forward 8
down 6
down 5
down 9
down 3
forward 1
down 5
forward 2
forward 8
down 2
forward 6
forward 3
down 7
down 4
forward 8
forward 1
down 6
forward 9
forward 6
up 1
up 3
down 8
forward 1
up 5
down 4
forward 7
up 3
down 2
forward 1
forward 9
down 9
down 7
forward 8
down 4
up 3
down 4
forward 2
forward 6
down 7
forward 6
down 6
down 4
down 1
up 9
down 4
down 7
up 4
down 9
forward 6
down 3
forward 2
down 4
forward 3
down 5
up 9
forward 8
up 7
up 6
up 4
forward 1
down 1
forward 4
up 6
forward 5
forward 4
forward 5
up 6
down 1
forward 3
up 7
down 9
up 9
down 5
forward 6
forward 4
up 1
down 4
up 1
forward 3
forward 1
down 3
forward 7
down 2
forward 3
up 2
forward 8
down 3
up 9
down 5
forward 6
down 1
down 8
down 5
forward 1
down 6
up 2
forward 6
down 2
down 1
up 6
up 7
down 5
forward 7
forward 6
forward 6
down 7
forward 4
down 5
up 5
down 1
up 8
down 8
down 2
down 2
down 9
up 9
forward 2
forward 7
down 7
down 4
down 4
down 8
forward 5
forward 2
up 9
down 9
forward 7
up 9
down 2
down 7
up 2
up 8
forward 8
down 4
forward 3
forward 4
forward 6
forward 2
down 1
down 2
forward 2
up 1
down 1
forward 5
up 3
up 3
down 3
down 1
down 4
up 5
up 6
forward 5
up 7
forward 6
down 4
down 7
up 8
forward 1
down 5
up 4
up 3
up 5
down 1
up 5
forward 3
up 5
forward 2
forward 2
forward 5
forward 2
up 9
forward 4
down 1
down 3
down 5
up 2
down 8
forward 8
forward 9
down 1
down 3
forward 8
forward 2
down 2
down 1
up 7
forward 2
forward 8
down 9
forward 1
forward 4
down 7
down 4
up 7
down 3
down 1
down 4
up 7
down 6
forward 7
down 8
up 2
up 4
up 6
down 9
down 9
down 8
forward 6
up 3
up 1
forward 9
forward 6
up 4
up 2
up 7
forward 5
up 9
up 9
forward 9
up 6
down 1
down 3
forward 3
down 2
down 2
down 6
down 9
forward 3
forward 7
up 3
forward 3
down 5
forward 9
up 6
down 2
forward 8
down 3
up 5
down 6
forward 9
down 5
down 2
down 6
forward 8
forward 6
down 1
forward 6
up 1
up 7
down 4
down 7
forward 4
forward 7
down 4
forward 8
down 8
down 7
forward 9
down 1
down 3
down 6
forward 7
forward 6
forward 3
forward 8
down 5
down 3
up 1
down 9
down 8
forward 3
down 6
down 1
forward 5
forward 5
forward 9
up 5
down 6
up 9
down 7
down 6
up 1
forward 5
forward 7
forward 8
forward 7
forward 6
forward 3
forward 1
forward 2
up 4
forward 3
forward 4
forward 5
up 2
up 3
forward 4
down 9
up 4
forward 7
down 6
down 6
down 1
forward 2
down 2
forward 2
down 3
forward 7
forward 8
down 4
up 7
forward 7
down 7
forward 7
forward 9
down 7
up 2
down 3
forward 7
down 1
forward 8
forward 2
up 9
down 3
forward 2
up 4
forward 9
down 4
down 4
forward 4
down 2
down 9
forward 4
down 2
down 6
forward 9
forward 2
up 1
forward 2
forward 3
down 5
up 8
down 4
down 4
forward 7
down 2
up 6
down 9
forward 9
up 1
forward 3
down 5
forward 3
down 3
forward 4
up 3
down 6
down 7
down 4
down 8
down 4
down 5
up 9
up 1
down 7
up 3
up 3
down 3
up 4
up 6
forward 8
down 1
forward 7
forward 4
down 9
down 1
forward 7
forward 9
forward 1
down 3
down 2
forward 3
forward 2
down 7
forward 9
forward 6
up 9
down 2
forward 9
up 6
forward 8
up 1
down 5
down 8
forward 1
down 1
forward 9
up 1
forward 9
forward 1
forward 1
down 7
forward 3
forward 6
down 5
forward 7
forward 1
down 7
down 6
down 6
forward 5
up 6
down 6
forward 8
up 2
down 8
down 3
up 5
up 8
down 6
forward 4
forward 2
up 3
forward 5
forward 3
up 8
forward 6
up 8
forward 1
up 8
up 7
up 6
forward 2
down 9
down 9
forward 3
down 7
forward 3
down 6
forward 9
up 5
down 1
forward 7
down 1
down 5
down 9
forward 8
forward 9
forward 7
down 9
up 4
forward 5
down 5
forward 5
down 9
forward 9
forward 3
up 5
forward 8
up 5
down 1
forward 8
down 3
forward 6
up 9
forward 8
down 4
forward 3
down 5
forward 8
forward 9
forward 2
down 1
down 6
down 4
forward 9
up 2
down 3
down 6
down 3
down 9
down 1
up 6
down 2
down 7
up 5
forward 5
up 1
down 7
forward 6
up 6
down 2
down 3
forward 3
down 5
forward 8
down 9
down 7
down 8
up 7
down 1
forward 1
forward 1
down 2
up 4
forward 2
down 3
up 2
down 3
down 2
forward 7
down 1
up 7
down 2
down 1
forward 6
down 9
up 9
down 4
down 6
up 9
forward 7
forward 9
forward 7
down 4
down 1
forward 7
down 4
down 7
down 3
down 5
forward 3
down 8
forward 8
forward 7
forward 8
down 4
down 9
forward 2
forward 7
up 8
forward 4
down 6
up 8
down 2
forward 3
down 6
down 8
forward 8
forward 2
forward 9
up 6
forward 7
down 3
down 5
forward 8
forward 9
down 3
forward 3
forward 2
forward 3
down 8
up 9
up 5
up 2
up 6
up 1
up 1
up 5
forward 3
forward 2
down 3
forward 4";

            var sut = Submarine.CreateComplexSubmarineFor(COURSE);
            Assert.Equal(1749524700, sut.Multiplier);
        }
    }
}