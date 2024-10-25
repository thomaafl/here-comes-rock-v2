using rockgame.console.Players;
using rockgame.console;

class Program
{
    static void Main()
    {
        IPlayer player = new YourPlayer();
        IPlayer computer = new AI();
        Game game = new Game(player, computer);
        game.Intro();
    }
}
