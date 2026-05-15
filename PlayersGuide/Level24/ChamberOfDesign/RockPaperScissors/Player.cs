namespace PlayersGuide.Level24.ChamberOfDesign.RockPaperScissors;

public class Player
{
    public string Name { get; }
    public Hand CurrentHand { get; private set; }

    public Player(string name)
    {
        Name = name;
    }

    public void SetHand()
    {
        Console.WriteLine($"{Name}, enter your hand (rock, paper, scissors):");

        var input = Console.ReadLine()!;

        CurrentHand = input switch
        {
            "rock" => Hand.Rock,
            "paper" => Hand.Paper,
            "scissors" => Hand.Scissors,
            _ => throw new ArgumentException("Invalid hand", nameof(input))
        };
    }
}
