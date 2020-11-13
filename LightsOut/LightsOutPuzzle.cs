using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOut
{
    /// <summary>
    /// Lights Out Puzzle
    /// </summary>
    public class LightsOutPuzzle
    {
        /// <summary>
        /// The Puzzle Board
        /// </summary>
        public bool[,] Board { get; set; }

        /// <summary>
        /// The number of rows in the puzzle board
        /// </summary>
        public int NumberOfRows { get; private set; }

        /// <summary>
        /// The number of columns in the puzzle board
        /// </summary>
        public int NumberOfCols { get; private set; }

        /// <summary>
        /// Returns the state of the puzzles completion
        /// </summary>
        public bool Completed => IsPuzzleCompleted();

        /// <summary>
        /// Generates a new puzzle board and randomly sets the lights on or off
        /// </summary>
        /// <param name="numberOfRows">The number of rows for the board</param>
        /// <param name="numberOfCols">The number of columns for the board</param>
        public void CreateBoard(int numberOfRows, int numberOfCols)
        {
            // do not allow a board of less than 2 by 2
            if (numberOfRows < 2 || numberOfCols < 2)
            {
                throw new ArgumentException("The board rows and columns must be greater than 1");
            }

            // set the public properties (used to draw board)
            NumberOfRows = numberOfRows;
            NumberOfCols = numberOfCols;

            var board = new bool[NumberOfRows, NumberOfCols];
            var rand = new Random();

            // turn some of the lights on
            for (int x = 0; x < NumberOfRows; x++)
            {
                for (int y = 0; y < NumberOfCols; y++)
                {
                    board[x, y] = rand.Next(2) == 0;
                }
            }

            Board = board;
        }

        /// <summary>
        /// Toggle the selected light and the lights in the imediate vacinity
        /// </summary>
        /// <param name="x">Row coordinate</param>
        /// <param name="y">Column coordinate</param>
        public void ToggleLights(int x, int y)
        {
            // check the coordinates are within the confines of the board
            if (x < 0 || x >= NumberOfRows || y < 0 || y >= NumberOfCols)
            {
                throw new ArgumentException("Coordinates out of range");
            }

            // toggle the lights
            Board[x,y] = !Board[x, y]; // centre
            if (x > 0) { Board[x-1, y] = !Board[x-1, y]; } // left
            if (x < NumberOfRows-1) { Board[x+1, y] = !Board[x+1, y]; } // right
            if (y > 0) { Board[x, y-1] = !Board[x, y-1]; } // top
            if (y < NumberOfCols-1) { Board[x, y+1] = !Board[x, y+1]; } // bottom
        }

        /// <summary>
        /// Set up the board for a one-click finish to help testing or cheating :)
        /// </summary>
        public void Cheat()
        {
            // clear the board
            for (int x = 0; x < NumberOfRows; x++)
            {
                for (int y = 0; y < NumberOfCols; y++)
                {
                    Board[x, y] = false;
                }
            }

            // turn the lights on in a cross in the middle of the board
            var centreRow = NumberOfRows / 2;
            var centreCol = NumberOfCols / 2;

            Board[centreRow, centreCol] = true;
            Board[centreRow-1, centreCol] = true;
            Board[centreRow+1, centreCol] = true;
            Board[centreRow, centreCol-1] = true;
            Board[centreRow, centreCol+1] = true;

        }

        /// <summary>
        /// Check the board to see if any lights are left on
        /// </summary>
        /// <returns></returns>
        private bool IsPuzzleCompleted()
        {
            var lightsStillOn = false;

            for (int x = 0; x < NumberOfRows; x++)
            {
                for (int y = 0; y < NumberOfCols; y++)
                {
                    lightsStillOn = lightsStillOn || Board[x, y];
                }
            }

            return !lightsStillOn;
        }
    }
}
