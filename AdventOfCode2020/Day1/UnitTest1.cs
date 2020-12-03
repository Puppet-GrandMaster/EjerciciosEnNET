using System.Runtime.CompilerServices;
using System;
using Xunit;
using AdventOfCode2020.Day1;

namespace Day1
{
    public class UnitTest1
    {
        [Fact]
        public void Find2020_WhenCombiningTwoNumbers()
        {
            const int lookedForValue = 2020;
            var solver = new PuzzleSolver.Builder().Build();
            solver.SolveWith(2);

            Assert.Equal(lookedForValue, solver.Value1 + solver.Value2);
            Assert.Equal(787776, solver.Solution);
        }

        [Fact]
        public void Find2020_WhenCombiningThreeNumbers()
        {
            const int lookedForValue = 2020;
            var solver = new PuzzleSolver.Builder().Build();
            solver.SolveWith(3);

            Assert.Equal(lookedForValue, solver.Value1 + solver.Value2 + solver.Value3);
            Assert.Equal(262738554, solver.Solution);
        }
    }
}
