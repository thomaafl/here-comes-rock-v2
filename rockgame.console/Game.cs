using rockgame.console.Players;
using System;
using System.Threading;

namespace rockgame.console
{
    public class Game
    {
        private IPlayer player;
        private IPlayer computer;
        private string[] choices = { "R", "P", "S" };
        private int wins = 0;
        private int losses = 0;
        private int ties = 0;

        public Game(IPlayer player, IPlayer computer)
        {
            this.player = player;
            this.computer = computer;
        }

        public void Intro()
        {
            Console.WriteLine(" ---------------- Here comes ROCK ----------------\n");
            Console.WriteLine("                  (with powerups!)                    \n\n");
            Console.WriteLine("----------------------------------------------------\n");

            bool choice = Choice();


            if (choice)
            {
                do
                {
                    int rounds = GetNumberOfRounds();
                    for (int i = 0; i < rounds; i++)
                    {
                        Console.WriteLine($"Round {i + 1} of {rounds}");
                        string playerMove = player.GetMove();
                        if (playerMove == "EXIT")
                        {
                            return;
                        }
                        string computerMove = computer.GetMove();
                        CountdownFrom3();
                        Console.WriteLine($"Player chose: {ConvertMoveToFullName(playerMove)}");
                        Console.WriteLine(GetMoveArt(playerMove));
                        Console.WriteLine($"Computer chose: {ConvertMoveToFullName(computerMove)}");
                        Console.WriteLine(GetMoveArt(computerMove));
                        DetermineWinner(playerMove, computerMove);
                        DisplayScore();
                    }
                    DisplayFinalScore();
                } while (PlayAgain());
            }
            else
            {
                Console.WriteLine("Game ended by user.");
            }

            Console.WriteLine("Thanks for playing!");
        }

        public bool Choice()
        {
            Console.WriteLine("Play against the computer? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                return true;
            }
            else if (choice.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wrong input...\n");
                return Choice(); // Use the result of the recursive call
            }
        }

        public int GetNumberOfRounds()
        {
            Console.WriteLine("Choose the number of rounds to play (1, 3, or 9): ");
            string input = Console.ReadLine();
            if (input == "1" || input == "3" || input == "9")
            {
                return int.Parse(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose 1, 3, or 9.");
                return GetNumberOfRounds();
            }
        }

        public bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                wins = 0;
                ties = 0;
                losses = 0;
                return true;
            }
            else if (choice.ToUpper() == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wrong input...\n");
                return PlayAgain(); // Use the result of the recursive call
            }
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

        public void DetermineWinner(string playerMove, string computerMove)
        {
            if (playerMove == computerMove)
            {
                Console.WriteLine("It's a tie!");
                ties++;
            }
            else if ((playerMove == "R" && computerMove == "S") ||
                     (playerMove == "P" && computerMove == "R") ||
                     (playerMove == "S" && computerMove == "P"))
            {
                Console.WriteLine("You win!");
                wins++;
            }
            else
            {
                Console.WriteLine("You lose!");
                losses++;
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Score: Wins - {wins}, Losses - {losses}, Ties - {ties}");
        }

        public void DisplayFinalScore()
        {
            Console.WriteLine("\nFinal Score:");
            Console.WriteLine($"Wins - {wins}, Losses - {losses}, Ties - {ties}");

            if (wins > losses)
            {
                Console.WriteLine("Congratulations! You are the winner!");
                Console.WriteLine(GetTrophyArt());
            }
            else if (losses > wins)
            {
                Console.WriteLine("The computer wins! Better luck next time.");
                Console.WriteLine(GetTrophyArt());
            }
            else
            {
                Console.WriteLine("It's a tie overall!");
            }
        }

        private string ConvertMoveToFullName(string move)
        {
            return move switch
            {
                "R" => "rock",
                "P" => "paper",
                "S" => "scissors",
                _ => "unknown"
            };
        }

        private string GetMoveArt(string move)
        {
            return move switch
            {
                "R" => @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
",
                "P" => @"
    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
",
                "S" => @"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)
",
                _ => ""
            };
        }

        private string GetTrophyArt()
        {
            return @"
       ___________
      '._==_==_=_.'
      .-\:      /-.
     | (|:.     |) |
      '-|:.     |-'
        \::.    /
         '::. .'
           ) (
         _.' '._
        '''''''''";
        }
    }
}
