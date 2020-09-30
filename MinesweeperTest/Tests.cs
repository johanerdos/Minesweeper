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
            }catch(System.IndexOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, mf.PositionExceeded);
                return;
            }

            Assert.Fail();

            //Assert.ThrowsException<System.IndexOutOfRangeException>(() => mf.SetBomb(x, y));
            
            
    }

  
  }
}
