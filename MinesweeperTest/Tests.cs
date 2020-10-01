using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
  [TestClass]
  public class Tests
  {
        Minesweeper.Minesweeper ms = new Minesweeper.Minesweeper();
        Minesweeper.Minefield mf = new Minesweeper.Minefield();

        [TestMethod]
    public void FindOutOfRangeException()
    {
            
            int x = 6;
            int y = 5;

            try
            {
                mf.SetBomb(x, y);

            }
            catch(System.IndexOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, mf.PositionExceeded);
                return;
            }

            Assert.Fail();
    }
        [TestMethod]
        public void FindFormatException()
        {
            string xC = "x";
            string yC = "y";

            try
            {
                int x = Convert.ToInt32(xC);
                int y = Convert.ToInt32(yC);
            }
            catch(System.FormatException e)
            {
                StringAssert.Contains(e.Message, mf.FormatException);
                return;
            }

            Assert.Fail();
        }

  
  }
}
