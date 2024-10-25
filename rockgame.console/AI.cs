using rockgame.console.Players;
using System;

public class AI : IPlayer
{
    private Random random = new Random();
    private string[] choices = { "R", "P", "S" };

    public string GetMove()
    {
        return choices[random.Next(choices.Length)];
    }
}
