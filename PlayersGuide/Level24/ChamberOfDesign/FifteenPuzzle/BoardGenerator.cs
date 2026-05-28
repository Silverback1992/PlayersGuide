namespace PlayersGuide.Level24.ChamberOfDesign.FifteenPuzzle;

public static class BoardGenerator
{
    public static Board Generate(int size)
    {
        var numbers = new HashSet<int>();

        while (numbers.Count != size * size - 1)
        {
            int randomNumber = Random.Shared.Next(1, size * size);
            numbers.Add(randomNumber);
        }

        var startState = new int?[size, size];
        int i = 0;
        int j = 0;

        foreach (var number in numbers)
        {
            startState[i, j] = number;
            j++;
            if (j == size)
            {
                j = 0;
                i++;
            }
        }

        var board = new Board(startState, size);
        return board;
    }
}
