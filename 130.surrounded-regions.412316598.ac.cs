public class Solution {
    
       bool seen = false;

        public bool Contained(char[][] board, int i, int j, HashSet<(int i, int j)> places)
        {
            var leftIndex = j - 1;
            var rightIndex = j + 1;
            var upIndex = i - 1;
            var downIndex = i + 1;

            if (upIndex < 0 || leftIndex < 0 ||
                downIndex >= board.Length ||
                rightIndex >= board[i].Length)
            {
                seen = true;
                return false;
            }

            places.Add((i, j));

            if (board[i][leftIndex] == 'O' && !places.Contains((i, leftIndex))) Contained(board, i, leftIndex, places);
            if (board[i][rightIndex] == 'O' && !places.Contains((i, rightIndex))) Contained(board, i, rightIndex, places);
            if (board[downIndex][j] == 'O' && !places.Contains((downIndex, j))) Contained(board, downIndex, j, places);
            if (board[upIndex][j] == 'O' && !places.Contains((upIndex, j))) Contained(board, upIndex, j, places);

            return true;
        }

        public void Solve(char[][] board)
        {
            //ignore edges of board
            for (int i = 1; i < board.Length - 1; i++)
            {
                for (int j = 1; j < board[i].Length - 1; j++)
                {
                    if (board[i][j] == 'X') continue;

                    HashSet<(int i, int j)> points = new HashSet<(int i, int j)>();
                    seen = false;
                    bool curiousity = Contained(board, i, j, points);

                    if (seen == true) continue;

                    foreach (var item in points)
                    {
                        board[item.i][item.j] = 'X';
                    }
                }
            }
        }
}
