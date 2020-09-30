using System;
namespace Minesweeper
{
  class Minefield
  {
        private bool[,] _bombLocations = new bool[5, 5];
        private string[,] _bombLocationsVisual = new string[5, 5];
        private string[,] _bombLocationsReveal = new string[5, 5];
        private bool[,] _hasBeenSearched = new bool[5, 5];
        bool bombFound = false;
        int bombCounter;
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
                    _bombLocationsVisual[i, j] = "?";
                }
            }
            PrintMineField(newState);
        }
        //Kanske göra att om bool b är nytt state så kallar den på en kopia av samma klass
        public void PrintMineField(bool b)
        {
           
            Console.WriteLine("  01234");
            for (int i = 0; i < 5; i++)
            {
                
                Console.Write(0 + i + "|");
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(_bombLocationsVisual[i, j]);
                }
                Console.WriteLine();
            }
            GetInput();
        }

        public void GetInput()
        {
            Console.WriteLine("Enter x-coordinate: ");
            string xCoordinate = Console.ReadLine();
            
            Console.WriteLine("Enter y-coordinate: ");
            //Check if input is valid

            string yCoordinate = Console.ReadLine();
            if(string.IsNullOrEmpty(xCoordinate) || string.IsNullOrEmpty(yCoordinate))
            {
                Console.WriteLine("You have to select a valid coordinate");
                InitializeMineField();
            }
            else 
            {
                
                try
                {
                    int x = Convert.ToInt32(xCoordinate);
                    int y = Convert.ToInt32(yCoordinate);

                    if (x > 5 || y > 5)
                    {
                        Console.WriteLine("Position is out of bounds, try again");
                        InitializeMineField();
                    }
                    else
                    {
                        HandleInput(x, y);
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please write an integer");
                    InitializeMineField();
                }
    
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
                newState = true;
                PrintMineField(newState);
                

                //Om inte bomben hittades så får vi kolla hur bombens grannar ser ut
                //Printar nu ett O där bomben inte var men inte deras grannar 

                
                for(int j = x - 1; j <= x + 1; j++)
                {
                    for(int i = y - 1; i <= y + 1; i++)
                    {
                        if(i >= 0 && j >= 0 && i < y && j < x && !(j == x && i == y))
                        {
                            _bombLocationsVisual[i, j] = " ";
                            //kolla hur bombens grannar ser ut 
                            /*
                            HandleAdjacent(x, y);
                            newState = true;
                            PrintMineField(newState);
                            */

                        }
                    }
                }




            }
            
            
        }

        public void HandleAdjacent(int x, int y)
        {
            bombCounter = 0;
            _hasBeenSearched[x, y] = true;

            //Console.WriteLine("För X: " + x + " och Y: " + y + " undersöks: ");

            for (int j = x - 1; j <= x + 1; j++)
            {
                for (int i = y - 1; i <= y + 1; i++)
                {
                    if (j < 0 || j > 4 || i < 0 || i > 4) //kollar out of grid? 
                    {
                        
                    }
                    else
                    {
                        
                        if(_bombLocations[j, i])
                        {
                            bombCounter++;
                        }
                        if(!_hasBeenSearched[j, i] && !_bombLocations[j, i])
                        {
                            HandleAdjacent(j, i);
                        }
                        
                      
                    }
                }
            }
            if(bombCounter != 0)
            {
                _bombLocationsVisual[x, y] = bombCounter.ToString();
            }
            else
            {
                _bombLocationsVisual[x, y] = "/";
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
                    if(_bombLocations[i, j])
                    {
                        Console.Write(_bombLocationsReveal[i, j] = "B");
                    }
                    //Console.Write(_bombLocationsReveal[i, j]);
                }
                Console.WriteLine();
            }
        }
        




    }
}
