public class Solution {
    
    List<IList<string>> ans = new List<IList<string>>();

        public bool IsValid(char[,] board, int i, int j)
        {
            //go up, down, left, right, upleft, upright, downleft, downright

            int left = j - 1;
            while (left >= 0)
            {
                if (board[i, left] == 'Q') return false;
                left--;
            }

            int right = j + 1;
            while (right < board.GetLength(1))
            {
                if (board[i, right] == 'Q') return false;
                right++;
            }

            int up = i - 1;
            while (up >= 0)
            {
                if (board[up, j] == 'Q') return false;
                up--;
            }

            int down = i + 1;
            while (down < board.GetLength(0))
            {
                if (board[down, j] == 'Q') return false;
                down++;
            }

            left = j - 1;
            up = i - 1;

            while (up >= 0 && left >= 0)
            {
                if (board[up, left] == 'Q') return false;
                left--;
                up--;
            }

            up = i - 1;
            right = j + 1;

            while (up >= 0 && right < board.GetLength(1))
            {
                if (board[up, right] == 'Q') return false;
                up--;
                right++;
            }

            down = i + 1;
            left = j - 1;

            while (down < board.GetLength(0) && left >= 0)
            {
                if (board[down, left] == 'Q') return false;
                left--;
                down++;
            }

            down = i + 1;
            right = j + 1;
            while (down < board.GetLength(0) && right < board.GetLength(1))
            {
                if (board[down, right] == 'Q') return false;

                down++;
                right++;
            }

            return true;
        }

        public void BackTrack(int row, int queensLeft, char[,] board, HashSet<(int, int)> immediateExcusions)
        {
            if (queensLeft == 0)
            {
                List<string> final = new List<string>();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    StringBuilder current = new StringBuilder();
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        current.Append(board[i, j]);
                    }
                    final.Add(current.ToString());
                }

                if (ans.Count == 0)
                {
                    ans.Add(final);
                    return;
                }

                bool total = true;
              /*
                foreach (var item in ans)
                {
                    bool good = false;
                    for (int j = 0; j < item.Count; j++)
                    {
                        if (item[j] != final[j])
                        {
                            good = true;
                            break;
                        }
                    }

                    if (!good)
                    {
                        total = false;
                    }
                }
              */
                if (total)
                {
                    ans.Add(final);
                }
                return;
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[row, i] == 'Q') continue;

                if (immediateExcusions.Contains((row, i)) == false && IsValid(board, row, i))
                {
                    board[row, i] = 'Q';

                    HashSet<(int, int)> newExclusions = new HashSet<(int, int)>(immediateExcusions)
                    {
                        (row - 1, i),
                        (row + 1, i),
                        (row, i - 1),
                        (row, i + 1),
                        (row - 1, i - 1),
                        (row + 1, i + 1),
                        (row - 1, i + 1),
                        (row + 1, i - 1)
                    };


                    BackTrack(row + 1, queensLeft - 1, board, newExclusions);
                    board[row, i] = '.';
                }
            }
        }

        public IList<IList<string>> SolveNQueens(int n)
        {

            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = '.';
                }
            }

            BackTrack(0, n, board, new HashSet<(int, int)>());

            return ans;
        }

}
