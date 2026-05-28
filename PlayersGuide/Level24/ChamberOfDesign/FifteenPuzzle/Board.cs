namespace PlayersGuide.Level24.ChamberOfDesign.FifteenPuzzle;

public class Board
{
    public int?[,] State { get; }
    public (int Row, int Column) EmptyPosition { get; set; }
    public int NumberOfMoves { get; private set; }

    public Board(int?[,] state, int size)
    {
        State = state;
        EmptyPosition = (size - 1, size - 1);
    }

    public void Move(Direction direction)
    {
        if (direction == Direction.Up)
        {
            if (EmptyPosition.Row > 0)
            {
                Swap(EmptyPosition.Row, EmptyPosition.Column, EmptyPosition.Row - 1, EmptyPosition.Column);
                EmptyPosition = (EmptyPosition.Row - 1, EmptyPosition.Column);
                NumberOfMoves++;
            }
        }

        if (direction == Direction.Down)
        {
            if (EmptyPosition.Row < State.Length - 1)
            {
                Swap(EmptyPosition.Row, EmptyPosition.Column, EmptyPosition.Row + 1, EmptyPosition.Column);
                EmptyPosition = (EmptyPosition.Row + 1, EmptyPosition.Column);
                NumberOfMoves++;
            }
        }

        if (direction == Direction.Left)
        {
            if (EmptyPosition.Column > 0)
            {
                Swap(EmptyPosition.Row, EmptyPosition.Column, EmptyPosition.Row, EmptyPosition.Column - 1);
                EmptyPosition = (EmptyPosition.Row, EmptyPosition.Column - 1);
                NumberOfMoves++;
            }
        }

        if (direction == Direction.Right)
        {
            if (EmptyPosition.Column < State.Length - 1)
            {
                Swap(EmptyPosition.Row, EmptyPosition.Column, EmptyPosition.Row, EmptyPosition.Column + 1);
                EmptyPosition = (EmptyPosition.Row, EmptyPosition.Column + 1);
                NumberOfMoves++;
            }
        }
    }

    private void Swap(int row, int column1, int v, int column2)
    {
        int? temp = State[v, column2];
        State[row, column1] = temp;
        State[v, column2] = null;
    }

    public bool IsSolved()
    {
        int expected = 1;

        for (int i = 0; i < State.GetLength(0); i++)
        {
            for (int j = 0; j < State.GetLength(1); j++)
            {
                if (State[i, j] != expected)
                {
                    return false;
                }

                expected++;
            }
        }

        return true;
    }
}
