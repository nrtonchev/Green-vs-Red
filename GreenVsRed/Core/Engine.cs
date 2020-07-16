using GreenVsRed.Core.Contracts;
using GreenVsRed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed.Core
{
    public class Engine : IEngine
    {
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

            try
            {
                gameBoard = new GameBoard(input[1], input[0]);
            }
            catch (ArgumentException InvalidInput)
            {
                Console.WriteLine(InvalidInput.Message);
            }

            try
            {

            }
            catch (ArgumentException InvalidCellValue)
            {
                Console.WriteLine(InvalidCellValue.Message);
            }
        }
    }
}
