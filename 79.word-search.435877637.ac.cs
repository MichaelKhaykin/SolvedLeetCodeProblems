public class Solution {
    
    bool worked = false;
    
    //need to add hashset
    public void DFS(int i, int j, char[][] board, string word, int idInWord, HashSet<(int, int)> visited)
    {
        if (idInWord >= word.Length)
        {
            worked = true;
            return;
        }

        HashSet<(int, int)> newSet = new HashSet<(int, int)>(visited);
        newSet.Add((i, j));

        List<(int, int)> neighbors = new List<(int, int)>();
        if (i - 1 >= 0 && board[i - 1][j] == word[idInWord] && newSet.Contains((i - 1, j)) == false)
        {
            neighbors.Add((i - 1, j));
        }
        if (i + 1 < board.Length && board[i + 1][j] == word[idInWord] && newSet.Contains((i + 1, j)) == false)
        {
            neighbors.Add((i + 1, j));
        }
        if (j - 1 >= 0 && board[i][j - 1] == word[idInWord] && newSet.Contains((i, j - 1)) == false)
        {
            neighbors.Add((i, j - 1));
        }
        if (j + 1 < board[0].Length && board[i][j + 1] == word[idInWord] && newSet.Contains((i, j + 1)) == false)
        {
            neighbors.Add((i, j + 1));
        }

        foreach (var neighbor in neighbors)
        {
            DFS(neighbor.Item1, neighbor.Item2, board, word, idInWord + 1, newSet);
            if(worked) return;
        }
    }

    public bool Exist(char[][] board, string word) {
        
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(board[i][j] == word[0])
                {
                    DFS(i, j, board, word, 1, new HashSet<(int, int)>() { (i, j) });
                    if(worked) return true;       
                }
            }
        }
        
        return false;
    }
}
