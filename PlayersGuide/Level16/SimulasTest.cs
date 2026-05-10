namespace PlayersGuide.Level16;

public static class SimulasTest
{
    public static void Solution()
    {
        var chestStatus = ChestStatus.Locked;

        while (true)
        {
            string chestState = CalculateChestState(chestStatus);
            Console.Write($"The chest is {chestState}. What do you want to do? ");
            string action = Console.ReadLine()!;

            if (Enum.TryParse<ChestCommand>(action, true, out var chestCommand))
            {
                if (IsActionValid(chestCommand, chestStatus))
                {
                    chestStatus = CalculateChestStatus(chestCommand);
                }
            }
        }
    }

    private static ChestStatus CalculateChestStatus(ChestCommand chestCommand)
    {
        return chestCommand switch
        {
            ChestCommand.Lock => ChestStatus.Locked,
            ChestCommand.Unlock => ChestStatus.Closed,
            ChestCommand.Open => ChestStatus.Open,
            ChestCommand.Close => ChestStatus.Closed,
            _ => throw new ArgumentOutOfRangeException(nameof(chestCommand), chestCommand, null)
        };
    }

    private static bool IsActionValid(ChestCommand chestCommand, ChestStatus chestStatus)
    {
        if (chestStatus == ChestStatus.Locked && chestCommand != ChestCommand.Unlock)
        {
            return false;
        }

        if (chestStatus == ChestStatus.Closed && chestCommand != ChestCommand.Open && chestCommand != ChestCommand.Lock)
        {
            return false;
        }

        if (chestStatus == ChestStatus.Open && chestCommand != ChestCommand.Close)
        {
            return false;
        }

        return true;
    }

    private static string CalculateChestState(ChestStatus chestStatus)
    {
        return chestStatus switch
        {
            ChestStatus.Open => "open",
            ChestStatus.Closed => "unlocked",
            ChestStatus.Locked => "locked",
            _ => throw new ArgumentOutOfRangeException(nameof(chestStatus), chestStatus, null)
        };
    }
}
