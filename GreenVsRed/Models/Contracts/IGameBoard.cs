using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Models.Contracts
{
    public interface IGameBoard
    {
        int Height { get; }
        int Width { get; }
        void SetValue(int row, int col, char value);
        void ApplyingRules();
    }
}
