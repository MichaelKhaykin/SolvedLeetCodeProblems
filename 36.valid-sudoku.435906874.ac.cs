public class Solution {
    public bool IsValidSudoku(char[][] board) {
        
        //vertical
        for(int i = 0; i < board[0].Length; i++)
        {
            HashSet<int> collision = new HashSet<int>();
            for(int j = 0; j < board.Length; j++)
            {
                if(int.TryParse(board[j][i].ToString(), out int x))
                {
                    if(collision.Add(x) == false) return false;
                }
            }
        }
        
        //horizontal
        for(int i = 0; i < board.Length; i++)
        {
            HashSet<int> collision = new HashSet<int>();
            for(int j = 0; j < board[i].Length; j++)
            {
                if(int.TryParse(board[i][j].ToString(), out int x))
                {
                    if(collision.Add(x) == false) return false;
                }
            }
        }
        
        int width = 3;
        int height = 3;
        
        for(int i = 0; i <= board.Length - height; i += 3)
        {
            for(int j = 0; j <= board[i].Length - width; j += 3)
            {
                HashSet<int> visited = new HashSet<int>();
                
                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {
                        if(int.TryParse(board[i + y][j + x].ToString(), out int b))
                        {
                            if(visited.Add(b) == false) return false;
                        }
                    }
                }
            }
        }
        
        return true;
    }
}
