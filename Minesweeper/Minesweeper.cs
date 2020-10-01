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
            
            
            
            mf.SetBomb(0, 0);
            mf.SetBomb(0, 1);
            mf.SetBomb(1, 1);
            mf.SetBomb(1, 4);
            mf.SetBomb(4, 2);
            

            //the mine field should look like this now:
            //  01234
            //4|1X1
            //3|11111
            //2|2211X
            //1|XX111
            //0|X31

            // Game code...
            
            Console.WriteLine("Minesweeper!");
            mf.InitializeMineField();

            
            
            while (runGame)
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
                                
                    }
                    else
                    {
                         mf.HandleInput(x, y);
                    }
                  }
                  catch (FormatException)
                  {
                      Console.WriteLine("Please select an integer");
                            
                  }
                }
            }
            
            Console.Read();
        }
            
    }
       
        
  }

