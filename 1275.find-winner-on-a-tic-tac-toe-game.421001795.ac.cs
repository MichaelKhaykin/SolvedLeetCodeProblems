public class Solution
{
    private enum State : byte
    {
        Empty = 0,
        X = 1,
        O = 2
    }

    private State CheckWin(State[,] numBoard, out bool hasEmpty)
    {
        int[] rows = new int[3];
        int[] cols = new int[3];
        hasEmpty = false;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (numBoard[i, j] == State.Empty)
                {
                    hasEmpty = true;
                    continue;
                }

                if (numBoard[i, j] == State.X)
                {
                    rows[i]++;
                    cols[j]++;
                    continue;
                }

                rows[i]--;
                cols[j]--;
            }
        }

        int diagonal1 = 0;
        int diagonal2 = 0;

        for (int i = 0; i < 3; i++)
        {
            if (numBoard[i, i] != State.Empty)
            {
                if (numBoard[i, i] == State.X)
                {
                    diagonal1++;
                }
                else
                {
                    diagonal1--;
                }
            }

            int j = 2 - i;

            if (numBoard[i, j] != State.Empty)
            {
                if (numBoard[i, j] == State.X)
                {
                    diagonal2++;
                }
                else
                {
                    diagonal2--;
                }
            }
        }


        if (rows.Any(r => r == 3))
        {
            return State.X;
        }

        if (rows.Any(r => r == -3))
        {
            return State.O;
        }

        if (cols.Any(r => r == 3))
        {
            return State.X;
        }

        if (cols.Any(r => r == -3))
        {
            return State.O;
        }


        if (diagonal1 == 3)
        {
            return State.X;
        }

        if (diagonal1 == -3)
        {
            return State.O;
        }

        if (diagonal2 == 3)
        {
            return State.X;
        }

        if (diagonal2 == -3)
        {
            return State.O;
        }

        return State.Empty;
    }

    public string Tictactoe(int[][] moves)
    {
        State[,] numBoard = new State[3, 3];
        for (int i = 0; i < moves.Length; i++)
        {
            State curr = (i % 2 == 0) ? State.X : State.O;
            numBoard[moves[i][0], moves[i][1]] = curr;
        }

        var winner = CheckWin(numBoard, out bool hasEmpty);

        if (winner == State.Empty)
        {
            if (hasEmpty)
            {
                return "Pending";
            }
            else
            {
                return "Draw";
            }
        }

        if (winner == State.X)
        {
            return "A";
        }

        return "B";

    }
}
