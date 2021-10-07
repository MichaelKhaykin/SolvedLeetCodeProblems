public class Solution {
    public int MinSetSize(int[] arr) {
        
        Dictionary<int, int> freq = new Dictionary<int, int>();
        for(int i = 0; i < arr.Length; i++)
        {
            if(freq.ContainsKey(arr[i]))
            {
                freq[arr[i]]++;
            }
            else
            {
                freq.Add(arr[i], 1);   
            }
        }
        
        var vals = freq.Select((kvp) => kvp.Value).ToList();
        vals.Sort();
        
        var goal = arr.Length / 2;
        
        int sum = 0;
        int idk = 0;
        
        for(int i = vals.Count - 1; i >= 0; i--)
        {
            sum += vals[i];
            idk++;
            if(sum >= goal)
            {
                return idk; 
            }
        }
        
        return -1;
    }
}
