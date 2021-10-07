public class Solution {
    public int SubarrayBitwiseORs(int[] A) {
        
        HashSet<int> result = new HashSet<int>();
        HashSet<int> curr = new HashSet<int>();
        curr.Add(0);
        
        for(int i = 0; i < A.Length; i++)
        {
            HashSet<int> curr2 = new HashSet<int>();
            foreach(var item in curr)
            {
                curr2.Add(item | A[i]);
                result.Add(item | A[i]);
            }
            
            curr2.Add(A[i]);
            result.Add(A[i]);
            
            curr = curr2;
        }
        
        return result.Count;
        
    }
}
