using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOut
{
    public class LightsOutPuzzle
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfCols { get; private set; }

        public bool[,] Board { get; set; }

        public bool Completed
        {
            get
            {
                return IsPuzzleCompleted();
            }
        }

        //public LightsOutPuzzle()
        //{
        //    CreateBoard();
        //}

        public void CreateBoard(int numberOfRows, int numberOfCols)
        {
            if (numberOfRows < 2 || numberOfCols < 2)
            {
                throw new ArgumentException("The board rows and columns must be greater than 1");
            }

            NumberOfRows = numberOfRows;
            NumberOfCols = numberOfCols;

            var board = new bool[NumberOfRows, NumberOfCols];
            var rand = new Random();

            for (int x = 0; x < NumberOfRows; x++)
            {
                for (int y = 0; y < NumberOfCols; y++)
                {
                    board[x, y] = rand.Next(2) == 0;
                }
            }

            Board = board;
        }

        public void ToggleLights(int x, int y)
        {
            if (x < 0 || x >= NumberOfRows || y < 0 || y >= NumberOfCols)
            {
                throw new ArgumentException("Coordinates out of range");
            }

            Board[x,y] = !Board[x, y];
            if (x > 0) { Board[x-1, y] = !Board[x-1, y]; }
            if (x < NumberOfRows-1) { Board[x+1, y] = !Board[x+1, y]; }
            if (y > 0) { Board[x, y-1] = !Board[x, y-1]; }
            if (y < NumberOfCols-1) { Board[x, y+1] = !Board[x, y+1]; }
        }

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

        public void Cheat()
        {
            for (int x = 0; x < NumberOfRows; x++)
            {
                for (int y = 0; y < NumberOfCols; y++)
                {
                    Board[x, y] = false;
                }
            }

            var centreRow = NumberOfRows / 2;
            var centreCol = NumberOfCols / 2;

            Board[centreRow, centreCol] = true;
            Board[centreRow-1, centreCol] = true;
            Board[centreRow+1, centreCol] = true;
            Board[centreRow, centreCol-1] = true;
            Board[centreRow, centreCol+1] = true;

        }
    }
}
