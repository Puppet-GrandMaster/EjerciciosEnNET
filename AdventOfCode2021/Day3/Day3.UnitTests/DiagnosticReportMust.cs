using System;
using Xunit;
using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests
{
    public class DiagnosticReportMust
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void ThrowException_WhenInvalidDataIsSupplied(string invalidReport)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DiagnosticReport(invalidReport));
            Assert.Equal("Invalid report", exception.Message);
        }

        [Theory]
        [InlineData("1", 0)]
        [InlineData("0", 0)]
        [InlineData("0\n1\n1", 0)]
        [InlineData("1\n0\n0", 0)]
        [InlineData("100\n100", 12)]
        [InlineData("1010\n0101\n1110", 14)]
        [InlineData(SAMPLE_INPUT, 198)]
        public void CalculatePowerConsumptionCorrectly_WhenUsingSampleInput(string reportInput, int expectedPowerConsumption)
        {
            var sut = new DiagnosticReport(reportInput);
            sut.PreparePowerConsumptionReport();
            Assert.Equal(expectedPowerConsumption, sut.PowerConsumption);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new DiagnosticReport(REAL_INPUT);
            sut.PreparePowerConsumptionReport();
            Assert.Equal(2003336, sut.PowerConsumption);
        }

        [Fact]
        public void ObtainLifeSupportRatingCorrectly_WhenUsingSampleInput()
        {
            var sut = new DiagnosticReport(SAMPLE_INPUT);
            sut.PrepareLifeSupportRating();
            Assert.Equal(230, sut.LifeSupportRating);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new DiagnosticReport(REAL_INPUT);
            sut.PrepareLifeSupportRating();
            Assert.Equal(1877139, sut.LifeSupportRating);
        }
    }
}