using rockgame.console.Players;
using System;

public class YourPlayer : IPlayer
{
    public string GetMove()
    {
        Console.WriteLine("\n----------------------------------------------------\n");
        Console.WriteLine("\n-----------------* Pick your move *-----------------\n");
        Console.WriteLine("\n    (Rock - R)     (Paper - P)    (Scissors - S)    \n");
        Console.WriteLine("----------------------------------------------------\n");

        Console.WriteLine("Insert your choice here (or type 'exit' to quit): ");
        string yourChoice = Console.ReadLine().ToUpper();
        Console.WriteLine("\n----------------------------------------------------\n");

        if (yourChoice == "R" || yourChoice == "P" || yourChoice == "S" || yourChoice == "EXIT")
        {
            return yourChoice;
        }
        else
        {
            Console.WriteLine("That was not a valid input, please try again ...");
            return GetMove();
        }
    }
}
