using System;
using Day16.Logic;
using Xunit;

namespace Day16.UnitTests
{
    public class TransmissionDecoderMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenTransmissionIsInvalid(string invalidTransmission)
        {
            var exception = Assert.Throws<ArgumentException>(() => new TransmissionDecoder(invalidTransmission));
            Assert.Equal("Invalid transmission", exception.Message);
        }
        [Theory]
        [InlineData("D2FE28", "110", "100")]
        [InlineData("38006F45291200", "001", "110")]
        [InlineData("EE00D40C823060", "111", "011")]
        public void Test1(string transmission, string expectedVersion, string expectedTypeId)
        {
            var sut = new TransmissionDecoder(transmission);
            Assert.Collection(sut.Packets,
                p1 => {
                    Assert.Equal(expectedVersion, p1.Version);
                    Assert.Equal(expectedTypeId, p1.TypeId);
                });
        }

        [Fact]
        public void ParseLiteralPacketsCorrectly()
        {
            var decoder = new TransmissionDecoder("D2FE28");
            var sut = decoder.Packets[0] as LiteralPacket;

            Assert.Equal("110", sut.Version);
            Assert.Equal("100", sut.TypeId);
            Assert.Collection(sut.Groups,
                p1 => Assert.Equal("10111", p1),
                p2 => Assert.Equal("11110", p2),
                p3 => Assert.Equal("00101", p3));
            Assert.Equal(2021, sut.Value);
        }

/*
                    Assert.Collection(p1.Literal,
                        p11 => Assert.Equal("10111", p11),
                        p12 => Assert.Equal("11110", p12),
                        p13 => Assert.Equal("11110", p13),
                        p14 => Assert.Equal("00101", p14),
                        p15 => Assert.Equal("000", p15));

*/
    }

}
