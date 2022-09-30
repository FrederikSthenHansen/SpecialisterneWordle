// See https://aka.ms/new-console-template for more information
using WordleConsole;

ColourPicker.revertColour();
Console.WriteLine("Welcome to Frederiks Wordle!");
Thread.Sleep(1000); 
GameMaster GM = new GameMaster();
GM.newGame(true);

    
while (true)
{
   string guess = Console.ReadLine();

   //Handle and Guess and chech if the game is over:
   if (GM.HandleGuess(guess) == true) 
   { 
      Console.WriteLine("Press any key to start a new game..."); 
      Console.ReadKey();
      GM.newGame(false);
   }
}

    
