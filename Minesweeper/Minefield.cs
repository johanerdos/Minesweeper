using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Minesweeper
{
  public class Minefield
  {
        //strings for assert in unit testing
        //Had to write in swedish cause of my computerlanguage lol
        public string PositionExceeded = "Indexet låg utanför gränserna för matrisen";
        public string FormatException = "Indatasträngen hade ett felaktigt format";

        private bool[,] _bombLocations = new bool[5, 5];
        private string[,] _bombLocationsVisual = new string[5, 5];
        private string[,] _bombLocationsReveal = new string[5, 5];
        private bool[,] _hasBeenSearched = new bool[5, 5];
        bool bombFound = false;
        
        int bombCounter;
        DateTime startTime = DateTime.Now;
        TimeSpan finishedTime;
        private bool newState = false;
        

    public void SetBomb(int x, int y)
    {
      _bombLocations[x, y] = true;
      
    }

     public void InitializeMineField()
        {
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //setting the 2D array to contain "?"s
                    _bombLocationsVisual[j, i] = "?";
                }
                
            }
        }
        
        public void PrintMineField(bool b)
        {
            //checking if bool b is true, then we're keeping the state and printing it
            //if b is false, we initiate the field again and start over
            if (b)
            {
                int charCounter = 0;
                Console.WriteLine("  01234");
                for (int i = 0; i < 5; i++)
                {

                    Console.Write(0 + i + "|");
                    for (int j = 0; j < 5; j++)
                    {
                        //printing the 2D array which is declared in the initiate method
                        Console.Write(_bombLocationsVisual[j, i]);

                    }

                    Console.WriteLine();

                }
                //checking how many "?" are left in the 2D array, we can do this since we know the amount of bombs in the field
                foreach (string c in _bombLocationsVisual)
                {
                    if (c.Equals("?"))
                    {
                        charCounter++;
                    }
                }

                //and then when there is 5 left the game is won
                //don't really need to call Gamewon() but thought it would be cleaner
                if (charCounter == 5)
                {
                    finishedTime = DateTime.Now.Subtract(startTime);
                    GameWon(finishedTime);
                }
            }
            //initiating minefield and starting over if b is false
            else
            {
                InitializeMineField();
            }
            

        }


        public void HandleInput(int x, int y)
        {
            
            if (_bombLocations[x, y]) //checking if bomb was found 
            {
                
                GameOver();
            }
            else
            {
                
                HandleAdjacent(x, y);
 
            }

        }

        public void HandleAdjacent(int x, int y)
        {
            //check the current tiles nearby bombs.
            bombCounter = 0;
            _hasBeenSearched[x, y] = true;

            //looping the field to find the neighbouring tiles
            for (int j = x - 1; j <= x + 1; j++)
            {
                for (int i = y - 1; i <= y + 1; i++)
                {
                    
                    if (j < 0 || j > 4 || i < 0 || i > 4)//checking the grid boundaries
                    {

                    }
                    
                    else
                    {
                        //if there is neighbouring bombs present, we want to know how many and save that number in bombcounter
                        if (_bombLocations[i, j])
                        {
                            
                            bombCounter++;
                        }

                    }
                }

                
            }
            //and then if there are bombs in neighbouring tiles we print out how many there is
            if (bombCounter > 0)
            {
                _bombLocationsVisual[x, y] = bombCounter.ToString();
            }

            else
            {
                _bombLocationsVisual[x, y] = " ";
            }
            bombFound = false;
           
        }


    public void GameOver()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("Do you want to play again? Y/N");
            string choice = Console.ReadLine();
            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                newState = false;
                PrintMineField(newState);
            }
            if(choice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Do you want to reveal the field? Y/N");
                string reveal = Console.ReadLine();
                if (reveal.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    RevealField();
                    
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Please select Y or N");
                
            }
            
        }

        public void RevealField()
        {
            
            Console.WriteLine("  01234");
            for (int i = 0; i < 5; i++)
            {

                Console.Write(i + 0 + "|");
                for (int j = 0; j < 5; j++)
                {
                    //finding what coordinates contain a bomb and changing those coordinates to a "B"
                    if(_bombLocations[i, j])
                    {
                        Console.Write(_bombLocationsReveal[i, j] = "B");
                    }
                    
                }
                
                Console.WriteLine();
            }
           
        }

        public void GameWon(TimeSpan finishedTime)
        {
            newState = false;
            Console.WriteLine("You've won the game! Completion Time: " + finishedTime.ToString(@"mm\:ss"));
            Console.WriteLine("Exit? Y/N");
            string input = Console.ReadLine();
            if(input.Equals("Y", StringComparison.OrdinalIgnoreCase)){

                Environment.Exit(0);
            }
            else
            {
                PrintMineField(newState);
            }
        }
    }
}
