namespace PlayersGuide.Level16;

public static class SimulasTestGeminiSolution
{
    public static void Solution()
    {
        var chestStatus = ChestStatus.Locked;

        while (true)
        {
            // A quick inline switch for formatting the output string
            string stateDisplay = chestStatus switch
            {
                ChestStatus.Closed => "unlocked",
                _ => chestStatus.ToString().ToLower()
            };

            Console.Write($"The chest is {stateDisplay}. What do you want to do? ");
            string action = Console.ReadLine()!;

            if (Enum.TryParse<ChestCommand>(action, true, out var command))
            {
                // Here is the magic: The Tuple Pattern Match
                // We evaluate (CurrentState, Command) together to find the NewState.
                chestStatus = (chestStatus, command) switch
                {
                    (ChestStatus.Locked, ChestCommand.Unlock) => ChestStatus.Closed,
                    (ChestStatus.Closed, ChestCommand.Open) => ChestStatus.Open,
                    (ChestStatus.Closed, ChestCommand.Lock) => ChestStatus.Locked,
                    (ChestStatus.Open, ChestCommand.Close) => ChestStatus.Closed,
                    _ => chestStatus // Discard (ignore) invalid state/command combos!
                };
            }
        }
    }
}
