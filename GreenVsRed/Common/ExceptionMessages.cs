using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Exceptions
{
    public class ExceptionMessages
    {
        public static string InputOutOfBounds = "Input should be an integer between 1 and 999!";
        public static string InvalidWidthValue = "Width value should be less than or equal to the height value!";
        public static string InvalidCellInputValue = "Cell value should be eigther red (0) or green (1)!";
        public static string IndexOutOfBounds = "Provided indexes are outside of bounds of the game board!";
    }
}
