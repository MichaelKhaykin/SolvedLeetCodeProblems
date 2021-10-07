public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) {
        
        Dictionary<int, List<int>> better = new Dictionary<int, List<int>>();
        
        for(int i = 0; i < pieces.Length; i++)
        {
            better.Add(pieces[i][0], new List<int>());
            
            for(int j = 1; j < pieces[i].Length; j++)
            {
                better[pieces[i][0]].Add(pieces[i][j]);
            }
        }
        
        
        for(int i = 0; i < arr.Length; i++)
        {
            if(better.ContainsKey(arr[i]) == false) return false;
            
            var current = better[arr[i]];
            for(int j = 0; j < current.Count; j++)
            {
                if(i + j + 1 >= arr.Length) return false;
                if(arr[i + j + 1] != current[j]) return false;
            }
            i += current.Count;
        }
        
        return true;
    }
}
