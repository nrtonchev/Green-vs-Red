using GreenVsRed.Exceptions;
using GreenVsRed.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Models
{
    public class GameBoard : IGameBoard
    {
        /// <summary>
        /// Setting private fields for the gameBoard(matrix), height value and width value for easier access in the class.
        /// </summary>
        private int[,] gameBoard;
        private int height;
        private int width;

        /// <summary>
        /// Creating constructor for instantiating the multidimentional array and setting the values for height and width.
        /// </summary>
        /// <param name="height">gameBoard height</param>
        /// <param name="width">gameBoard width</param>
        public GameBoard(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.gameBoard = new int[this.Height, this.Width];
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
        /// <param name="value">value to be set</param>
        public void SetValue(int height, int width, int value)
        {
            if (value != 0 && value != 1)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCellInputValue);
            }
            this.gameBoard[height, width] = value;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
