public class Solution {
    public int[] SortArrayByParity(int[] A) {
     
        List<int> even = new List<int>();
        List<int> odd = new List<int>();
        
        for(int i = 0; i < A.Length; i++)
        {
            if(A[i] % 2 == 0)
            {
                even.Add(A[i]);
            }
            else
            {
                odd.Add(A[i]);
            }
        }        
        
        even.AddRange(odd);
        
        return even.ToArray();
    }
}
