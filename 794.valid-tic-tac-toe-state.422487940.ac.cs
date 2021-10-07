public class Solution {
    
    
    private bool checkWinner(int[,] board, int player)
    {
        // check rows
        if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) { return true; }
        if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) { return true; }
        if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) { return true; }

        // check columns
        if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) { return true; }
        if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) { return true; }
        if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) { return true; }

        // check diags
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) { return true; }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) { return true; }

        return false;
    }
    
    private (int, int) Find(int[,] board, int player, HashSet<(int, int)> seen)
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(board[i, j] == player && !seen.Contains((i, j)))
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1);
    }
    
    public bool ValidTicTacToe(string[] board) {
        
        int[,] better = new int[3, 3];
        int ans = 0;
        
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(board[i][j] == ' ') continue;
                
                better[i, j] = board[i][j] == 'X' ? 1 : 2;
                ans++;
            }
        }
        
        bool xWon = checkWinner(better, 1);
        bool yWon = checkWinner(better, 2);
        
        if(xWon && yWon) return false;
        
        if(xWon && ans % 2 == 0) return false;
        if(yWon && ans % 2 != 0) return false;
        
        HashSet<(int, int)> seen = new HashSet<(int, int)>();
        bool placeX = true;
        
        while(seen.Count < ans)
        {
            var placePos = Find(better, placeX ? 1 : 2, seen);
            if(placePos.Item1 == -1 && placePos.Item2 == -1) return false;
            
            seen.Add(placePos);
            placeX = !placeX;
        }
        
        return true;
    }
}

