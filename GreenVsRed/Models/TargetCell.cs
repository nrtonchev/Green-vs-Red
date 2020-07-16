using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Models
{
    public class TargetCell
    {
        /// <summary>
        /// Setting up private fields for targetCell row and col as well as a generationCounter(which will present the end result on the console).
        /// </summary>
        private int row;
        private int col;
        private int generationCount;

        /// <summary>
        /// Instantiating the TargetCell class, setting the row and col values.
        /// </summary>
        /// <param name="row">targetCell row</param>
        /// <param name="col">targetCell col</param>
        public TargetCell(int row, int col)
        {
            this.TargetCellRow = row;
            this.TargetCellCol = col;
        }
        /// <summary>
        /// Properties with public getters for accessing the row and col values, and private setters for initially setting them up(without the ability to be changed).
        /// </summary>
        public int TargetCellRow { get; private set; }
        public int TargetCellCol { get; private set; }

        /// <summary>
        /// Added a method which will update the generation count if the target cell is green('1').
        /// </summary>
        public void AddGeneration()
        {
            this.generationCount++;
        }

        /// <summary>
        /// Overriding the ToString() method to return the generationCount value;
        /// </summary>
        /// <returns>generationCount</returns>
        public override string ToString()
        {
            return generationCount.ToString();
        }
    }
}
