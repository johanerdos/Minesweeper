using System;
using System.Collections.Generic;

namespace Minesweeper
{
  class Minesweeper
  {
    public static void Main()
    {

      Minefield mf = new Minefield();
      var field = new Minefield();
      
                //set the bombs...
                mf.SetBomb(0, 0);
                mf.SetBomb(0, 1);
                mf.SetBomb(1, 1);
                mf.SetBomb(1, 4);
                mf.SetBomb(4, 2);

            mf.InitializeMineField();



                //the mine field should look like this now:
                //  01234
                //4|1X1
                //3|11111
                //2|2211X
                //1|XX111
                //0|X31

                // Game code...

            Console.Read();
    }
       
        
  }
}
