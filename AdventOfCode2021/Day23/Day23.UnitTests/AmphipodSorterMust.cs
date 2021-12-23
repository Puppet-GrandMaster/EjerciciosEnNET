using System;
using Day23.Logic;
using Xunit;

namespace Day23.UnitTests
{
    public class AmphipodSorterMust
    {
        private const string SAMPLE_MAP = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";

        private const string REAL_MAP = @"#############
#...........#
###B#D#C#A###
  #C#D#B#A#
  #########";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new AmphipodSorter(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_MAP)]
        [InlineData(REAL_MAP)]
        public void LoadMapCorrectly(string map)
        {
            var sut = new AmphipodSorter(map);
            Assert.Equal(map, sut.ToString());
        }
    }
}