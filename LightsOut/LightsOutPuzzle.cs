using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOut
{
    public class LightsOutPuzzle
    {
        public int NumberOfRows { get; private set; } = 5;
        public int NumberOfCols { get; private set; } = 5;

        public bool[,] Board { get; set; }

        public LightsOutPuzzle()
        {
            CreateBoard();
        }

        public void CreateBoard()
        {
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
                throw new Exception("Coordinates out of range");
            }

            Board[x,y] = !Board[x, y];
            if (x > 0) { Board[0, y] = !Board[0, y]; }
            if (x < NumberOfRows-1) { Board[x+1, y] = !Board[x + 1, y]; }
            if (y > 0) { Board[x, 0] = !Board[x, 0]; }
            if (x < NumberOfCols-1) { Board[x, y+1] = !Board[x, y + 1]; }
        }

        public bool PuzzleCompleted()
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
