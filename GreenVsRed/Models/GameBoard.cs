using GreenVsRed.Exceptions;
using GreenVsRed.Models.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Models
{
    public class GameBoard : IGameBoard
    {
        /// <summary>
        /// Setting private fields for the gameBoard(matrix), height value and width value for easier access in the class.
        /// </summary>
        private char[,] gameBoard;
        private int height;
        private int width;

        /// <summary>
        /// Creating constructor for instantiating the multidimentional array(creating "Generation Zero") and setting the values for height and width.
        /// </summary>
        /// <param name="height">gameBoard height</param>
        /// <param name="width">gameBoard width</param>
        public GameBoard(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.gameBoard = new char[this.Height, this.Width];
        }

        /// <summary>
        /// A property with a public getter for accessing the height value and a private setter for setting it up in the constructor, and not being able to further change it. The private setter makes sure that the height value does not exceed the required maximum.
        /// </summary>
        public int Height {
            get
            {
                return this.height;
            }
            private set
            {
                if (value >= 1000)
                {
                    throw new ArgumentException(ExceptionMessages.InputOutOfBounds);
                }

                this.height = value;
            }
        }

        /// <summary>
        /// A property with a public getter for accessing the width value and a private setter for setting it up in the constructor, and not being able to further change it. The private setter makes sure that the width is not larger than the height as per the following statement from the problem description: "In our case we will assume that x <= y < 1000". Also, it makes sure that the height value does not exceed the required maximum.
        /// </summary>
        public int Width {
            get
            {
                return this.width;
            }

            private set
            {
                if (value > this.Height)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWidthValue);
                }

                if (value >= 1000)
                {
                    throw new ArgumentException(ExceptionMessages.InputOutOfBounds);
                }

                this.width = value;
            }
        }

        /// <summary>
        /// This method is used for setting the values for each cell in the boardGame.
        /// Value should be:
        /// - "0" - red;
        /// - "1" - green;
        /// </summary>
        /// <param name="height">gameBoard height</param>
        /// <param name="width">gameBoard width</param>
        /// <param name="value">char value to be set</param>
        public void SetValue(int row, int col, char value)
        {
            if (value != '0' && value != '1')
            {
                throw new ArgumentException(ExceptionMessages.InvalidCellInputValue);
            }
            this.gameBoard[row, col] = value;
        }
        /// <summary>
        /// Added a method to check what value the target cell coordinates respond to.
        /// </summary>
        /// <param name="row">row value of target cell</param>
        /// <param name="col">col value of target cell</param>
        /// <returns></returns>
        public char ReturnCell(int row, int col)
        {
            return this.gameBoard[row, col];
        }

        /// <summary>
        /// Added a method which will return the next generation after applied rules.
        /// </summary>
        /// <returns>nextGeneration</returns>
        public void ApplyingRules()
        {
            char[,] nextGenBoard = new char[this.Height, this.Width];
            Array.Copy(this.gameBoard, 0, nextGenBoard, 0, this.gameBoard.Length);

            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    char cellValue = gameBoard[row, col];

                    switch (cellValue)
                    {
                        case '0':
                            if (!IsRed(row, col))
                            {
                                nextGenBoard[row, col] = '1';
                            }
                            ; break;
                        case '1':
                            if (!IsGreen(row, col))
                            {
                                nextGenBoard[row, col] = '0';
                            }
                            ; break;
                    }
                }
            }

            this.gameBoard = nextGenBoard;
        }

        /// <summary>
        /// Checks if current cell shoul remain red or turn green.
        /// </summary>
        /// <param name="row">current cell row</param>
        /// <param name="col">current cell col</param>
        /// <returns>IsRed</returns>
        private bool IsRed(int row, int col)
        {
            int greenNeighbours = CheckGreenNeighbours(row, col);

            if (greenNeighbours == 3 || greenNeighbours == 6)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if current cell shoul remain green or turn red.
        /// </summary>
        /// <param name="row">current cell row</param>
        /// <param name="col">current cell col</param>
        /// <returns>IsGreen</returns>
        private bool IsGreen(int row, int col)
        {
            int greenNeighbours = CheckGreenNeighbours(row, col);

            if (greenNeighbours == 2 || greenNeighbours == 3 || greenNeighbours == 6)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Private method used to check neighbouring green cells.
        /// </summary>
        /// <param name="row">current cell row</param>
        /// <param name="col">current cell col</param>
        /// <returns>numberOfGreenNeighbours</returns>
        private int CheckGreenNeighbours(int row, int col)
        {
            int count = 0;

            if ((row - 1 >= 0 && col - 1 >= 0) && gameBoard[row - 1, col - 1] == '1')
            {
                count++;
            }

            if (row - 1 >= 0 && gameBoard[row - 1, col] == '1')
            {
                count++;
            }

            if ((row - 1 >= 0 && col + 1 < this.Width) && gameBoard[row - 1, col + 1] == '1')
            {
                count++;
            }

            if (col - 1 >= 0 && gameBoard[row, col - 1] == '1')
            {
                count++;
            }

            if (col + 1 < this.Width && gameBoard[row, col + 1] == '1')
            {
                count++;
            }

            if ((row + 1 < this.Height && col - 1 >= 0) && gameBoard[row + 1, col - 1] == '1')
            {
                count++;
            }

            if (row + 1 < this.Height && gameBoard[row + 1, col] == '1')
            {
                count++;
            }

            if ((row + 1 < this.Height && col + 1 < this.Width) && gameBoard[row + 1, col + 1] == '1')
            {
                count++;
            }

            return count;
        }
    }
}
