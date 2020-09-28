using System;
namespace Minesweeper
{
  class Minefield
  {
        private bool[,] _bombLocations = new bool[5, 5];
        private string[,] _bombLocationsVisual = new string[5, 5];
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
        public void PrintMineField(bool b)
        {
           
            Console.WriteLine("  01234");
            for (int i = 0; i < 5; i++)
            {
                //Denna raden som skriver 54321 osv, ska helst skriva 0,1,2,3,4
                Console.Write(5 - i + "|");
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
                Console.WriteLine("You have to select a valid number");
            }
            else 
            {

                int x = Convert.ToInt32(xCoordinate);
                int y = Convert.ToInt32(yCoordinate);
                if(x > 5 || y > 5)
                {
                    Console.WriteLine("Position is out of bounds, try again");
                    InitializeMineField();
                }
                else
                {
                    HandleInput(x, y);
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
                //Om inte bomben hittades så får vi kolla hur bombens grannar ser ut
                //Printar nu ett O där bomben inte var men inte deras grannar 
                
                
                for(int j = x - 1; j <= x + 1; j++)
                {
                    for(int i = y - 1; i < y + 1; i++)
                    {
                        if(i >= 0 && j >= 0 && i < y && j < x && !(j == x && i == y))
                        {
                            _bombLocationsVisual[i, j] = "O";
                            newState = true;
                            PrintMineField(newState);
                        }
                    }
                }
                
                

            }
            
            
        }

        public void GameOver()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("Do you want to play again? Y/N");
            string choice = Console.ReadLine();
            if (choice.Equals("Y"))
            {
                newState = false;
                PrintMineField(newState);
            }
            else
            {
                Environment.Exit(0);
            }
            
        }
        




    }
}
