using System;
using Xunit;

namespace LightsOut.Tests
{
    public class LightsOutPuzzleTests
    {
        [Fact]
        public void CreateBoard_RowsLessThan2_ThrowsArguementException()
        {
            var puzzle = new LightsOutPuzzle();

            Assert.Throws<ArgumentException>(() => puzzle.CreateBoard(1,2));
        }

        [Fact]
        public void CreateBoard_ColumnsLessThan2_ThrowsArguementException()
        {
            var puzzle = new LightsOutPuzzle();

            Assert.Throws<ArgumentException>(() => puzzle.CreateBoard(2, 1));
        }

        [Fact]
        public void ToggleLights_RowsNotInRange_ThrowsArguementException()
        {
            var puzzle = new LightsOutPuzzle();
            puzzle.CreateBoard(5, 5);

            Assert.Throws<ArgumentException>(() => puzzle.ToggleLights(6, 2));
        }

        [Fact]
        public void ToggleLights_ColumnsNotInRange_ThrowsArguementException()
        {
            var puzzle = new LightsOutPuzzle();
            puzzle.CreateBoard(5, 5);

            Assert.Throws<ArgumentException>(() => puzzle.ToggleLights(2, 6));
        }

        [Fact]
        public void IsPuzzleCompleted_SomeLightsAreOn_ReturnsFalse()
        {
            var puzzle = new LightsOutPuzzle();
            puzzle.CreateBoard(5, 5);

            // In the highly unlikely event of a blank board being generated..
            // switch on a light
            puzzle.Board[0, 0] = true;

            var result = puzzle.Completed;

            Assert.False(result);
        }

        [Fact]
        public void IsPuzzleCompleted_LightsAreAllOff_ReturnsTrue()
        {
            var puzzle = new LightsOutPuzzle();
            puzzle.CreateBoard(5, 5);

            for (int x = 0; x < puzzle.NumberOfRows; x++)
            {
                for (int y = 0; y < puzzle.NumberOfCols; y++)
                {
                    puzzle.Board[x, y] = false;
                }
            }

            var result = puzzle.Completed;

            Assert.True(result);
        }
    }
}
