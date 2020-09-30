using System;
using System.Collections.Generic;

namespace Minesweeper
{
  public class Minesweeper
  {
    public static void Main()
    {
      
      
      Minefield mf = new Minefield();
      var field = new Minefield();
      bool runGame = true;
      bool newState = true;
            
            

            //set the bombs...
            //randomize bombs in the end 
            
            mf.SetBomb(0, 0);
            mf.SetBomb(0, 1);
            mf.SetBomb(1, 1);
            mf.SetBomb(1, 4);
            mf.SetBomb(4, 2);


            /*
            mf.SetBomb(4, 0);
            mf.SetBomb(4, 1);
            mf.SetBomb(4, 2);
            mf.SetBomb(4, 3);
            mf.SetBomb(4, 4);
            */









            //the mine field should look like this now:
            //  01234
            //4|1X1
            //3|11111
            //2|2211X
            //1|XX111
            //0|X31

            // Game code...

            mf.InitializeMineField();
            
            while(runGame == true)
            {
                int x;
                int y;
                newState = true;


                mf.PrintMineField(newState);

                Console.WriteLine("Enter x-coordinate: ");
                string xInput = Console.ReadLine();
                Console.WriteLine("Enter y-coordinate: ");
                string yInput = Console.ReadLine();

                if (String.IsNullOrEmpty(xInput) || String.IsNullOrEmpty(yInput))
                {
                    Console.WriteLine("Please select a coordinate");
                    mf.PrintMineField(newState);
                }
                else
                {
                    try
                    {
                        x = Convert.ToInt32(xInput);
                        y = Convert.ToInt32(yInput);

                        if (x > 4 || y > 4)
                        {
                            Console.WriteLine("Position is out of bounds, try again");
                            mf.PrintMineField(newState);
                        }
                        else
                        {
                            mf.HandleInput(x, y);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please select an integer");
                        mf.PrintMineField(newState);
                    }
                }
            }

            Console.Read();
    }
       
        
  }
}
