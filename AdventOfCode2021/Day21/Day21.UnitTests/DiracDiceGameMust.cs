using System;
using Day21.Logic;
using Xunit;

namespace Day21.UnitTests
{
    public class DiracDiceGameMust
    {
        [Theory]
        [InlineData(-1, 4)]
        [InlineData(11, 4)]
        [InlineData(4, 11)]
        [InlineData(4, -1)]
        public void ThrowException_WhenInitializedWithInvalidData(int player1Position, int player2Position)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DiracDiceGame(player1Position, player2Position));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(4, 8)]
        [InlineData(10, 8)]
        public void BeInitializedCorrectly(int player1Position, int player2Position)
        {
            var sut = new DiracDiceGame(player1Position, player2Position);
            Assert.True(sut.IsPlayerAt(0, player1Position));
            Assert.True(sut.IsPlayerAt(1, player2Position));
        }

        [Fact]
        public void UpdatePlayerPositionCorrectly_AfterOneRound()
        {
            var sut = new DiracDiceGame(4, 8);

            sut.ThrowDice();
            sut.ThrowDice();
            Assert.True(sut.IsPlayerAt(0, 10));
            Assert.Equal(10, sut.GetScoreFor(0));
            Assert.True(sut.IsPlayerAt(1, 3));
            Assert.Equal(3, sut.GetScoreFor(1));
        }

        [Fact]
        public void UpdatePlayerPositionCorrectly_AfterTwoRounds()
        {
            var sut = new DiracDiceGame(4, 8);

            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();

            Assert.True(sut.IsPlayerAt(0, 4));
            Assert.Equal(14, sut.GetScoreFor(0));
            Assert.True(sut.IsPlayerAt(1, 6));
            Assert.Equal(9, sut.GetScoreFor(1));
        }

        [Fact]
        public void UpdatePlayerPositionCorrectly_AfterThreeRounds()
        {
            var sut = new DiracDiceGame(4, 8);

            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();

            Assert.True(sut.IsPlayerAt(0, 6));
            Assert.Equal(20, sut.GetScoreFor(0));
            Assert.True(sut.IsPlayerAt(1, 7));
            Assert.Equal(16, sut.GetScoreFor(1));
        }

        [Fact]
        public void UpdatePlayerPositionCorrectly_AfterFourRounds()
        {
            var sut = new DiracDiceGame(4, 8);

            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();
            sut.ThrowDice();

            Assert.True(sut.IsPlayerAt(0, 6));
            Assert.Equal(26, sut.GetScoreFor(0));
            Assert.True(sut.IsPlayerAt(1, 6));
            Assert.Equal(22, sut.GetScoreFor(1));
        }
    }
}
