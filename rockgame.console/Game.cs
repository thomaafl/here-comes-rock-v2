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

            CountdownFrom3();
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
    }
}
