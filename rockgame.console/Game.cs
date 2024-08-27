using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rockgame.console
{
    public class Game
    {
        public void Intro()
        {
            Console.WriteLine(" ---------------- Here comes ROCK ----------------\n");
            Console.WriteLine("                  (with powerups!)                    \n\n");
            Console.WriteLine("----------------------------------------------------\n");

            bool choice = Choice();

            if (choice) Console.WriteLine("AI time!");
            string move = PickYourMove1();
            CountdownFrom3();
            Console.WriteLine(move);

        }

        public bool Choice()
        {
            Console.WriteLine("Play against the computer? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                return true;
            }
            else if (choice == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wrong input...\n");
                Choice(); // Use the result of the recursive call
            }
            return false;
        }

        public void CountdownFrom3()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000); // Pause for 1 second
            }
            Console.WriteLine("Go!\n");
        }

        public string PickYourMove1()
        {
            
            Console.WriteLine("\n----------------------------------------------------\n");
            Console.WriteLine("\n-----------------* Pick your move *-----------------\n");
            Console.WriteLine("\n    (Rock - R)     (Paper - P)    (Scissors - S)    \n");
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("Insert your choice here: ");
            string yourchoice = Console.ReadLine();
            Console.WriteLine("\n----------------------------------------------------\n");
            yourchoice = yourchoice.ToUpper();
            if (yourchoice == "R" || yourchoice == "P" || yourchoice == "S")
            {
                return yourchoice;
            }
            else
            {
                Console.WriteLine("That was not a valid input, please try again ...");
                return PickYourMove1();
            }


        }
    }
}
