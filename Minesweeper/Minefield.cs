using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Minesweeper
{
  public class Minefield
  {
        public string PositionExceeded = "Indexet låg utanför gränserna för matrisen";

        private bool[,] _bombLocations = new bool[5, 5];
        private string[,] _bombLocationsVisual = new string[5, 5];
        private string[,] _bombLocationsReveal = new string[5, 5];
        private bool[,] _hasBeenSearched = new bool[5, 5];
        bool bombFound = false;
        bool runGame;
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
                    _bombLocationsVisual[j, i] = "?";
                }
                
            }
            

        }
        //Kanske göra att om bool b är nytt state så kallar den på en kopia av samma klass
        public void PrintMineField(bool b)
        {
            int charCounter = 0;
            Console.WriteLine("  01234");
            for (int i = 0; i < 5; i++)
            {
                
                Console.Write(0 + i + "|");
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(_bombLocationsVisual[j, i]);

                }
                
                Console.WriteLine();
                
            }
            foreach (string c in _bombLocationsVisual)
            {
                if (c.Equals("?"))
                {
                    charCounter++;
                }
            }

            if (charCounter == 5)
            {
                finishedTime = DateTime.Now.Subtract(startTime);
                GameWon(finishedTime);
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

            for (int j = x - 1; j <= x + 1; j++)
            {
                for (int i = y - 1; i <= y + 1; i++)
                {
                    if (j < 0 || j > 4 || i < 0 || i > 4)
                    {

                    }
                    else
                    {

                        if (_bombLocations[i, j])
                        {
                            
                            bombCounter++;
                        }

                    }
                }
            }

            if (bombCounter > 0)
            {
                _bombLocationsVisual[x, y] = bombCounter.ToString();
            }

            else
            {
                _bombLocationsVisual[x, y] = " ";
            }
            bombFound = false;
            //Om användaren matar in 2,2 så måste alla rutor nedanför undersökas:
            //1,1 1,2 1,3 2,1 2,3 3,1 3,2 3,3
            //man kan skapa en loop att gå igenom och se om alla runtom är false. Är samtliga det, så byt denna ruta till ett
            // mellanslag, dvs _bombLocationsVisual[x, y] = " ";

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

        
        public Boolean RevealField()
        {
            Console.WriteLine("  01234");
            for (int i = 0; i < 5; i++)
            {

                Console.Write(i + 0 + "|");
                for (int j = 0; j < 5; j++)
                {
                    if(_bombLocations[i, j])
                    {
                        Console.Write(_bombLocationsReveal[i, j] = "B");
                    }
                    
                }
                
                Console.WriteLine();
            }
            return newState = false;
        }

        public void GameWon(TimeSpan finishedTime)
        {

            Console.WriteLine("You've won the game! Time: " + finishedTime);
        }
        




    }
}
