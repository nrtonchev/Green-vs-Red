using GreenVsRed.Core.Contracts;
using GreenVsRed.Exceptions;
using GreenVsRed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GreenVsRed.Core
{
    public class Engine : IEngine
    {
        private int generationCount;
        public Engine()
        {
        }

        public void Run()
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            GameBoard gameBoard = null;
            int height = input[1];
            int width = input[0];

            //Adding try catch for invalid input exception during gameBoard instantiate.
            try
            {
                gameBoard = new GameBoard(input[1], input[0]);
            }
            catch (ArgumentException InvalidInput)
            {
                Console.WriteLine(InvalidInput.Message);
            }

            //Adding try catch for invalid cell value exception during gameBoard value set.
            try
            {
                for (int row = 0; row < gameBoard.Height; row++)
                {
                    char[] boardTokens = Console.ReadLine().ToCharArray();

                    for (int col = 0; col < gameBoard.Width; col++)
                    {
                        char cellValue = boardTokens[col];
                        gameBoard.SetValue(row, col, cellValue);
                    }
                }
            }
            catch (ArgumentException InvalidCellValue)
            {
                Console.WriteLine(InvalidCellValue.Message);
            }

            TargetCell targetCell = null;

            //Adding try catch for invalid input exception during targetCell instantiate.
            try
            {
                int[] argTokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                if ((argTokens[1] >= height || argTokens[1] < 0) || (argTokens[0] >= height || argTokens[0] < 0))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.IndexOutOfBounds));
                }

                targetCell = new TargetCell(argTokens[1], argTokens[0]);
                generationCount = argTokens[2];

                if (TargetIsGreen(gameBoard, argTokens[1], argTokens[0]))
                {
                    targetCell.AddGeneration();
                }
            }
            catch (ArgumentException InvalidIndexes)
            {
                Console.WriteLine(InvalidIndexes.Message);
            }

            //Adding for loop to itterate throug the multidimentional array and apply nextGeneration rules.
            for (int i = 0; i < generationCount; i++)
            {
                gameBoard.ApplyingRules();
                if (TargetIsGreen(gameBoard, targetCell.TargetCellRow, targetCell.TargetCellCol))
                {
                    targetCell.AddGeneration();
                }
            }

            //Print end result.
            Console.WriteLine(targetCell);
        }

        //Method to check if Target cell is green ('1').
        static bool TargetIsGreen(GameBoard gameBoard, int row, int col)
        {
            return gameBoard.ReturnCell(row, col) == '1';
        }
            
    }
}
