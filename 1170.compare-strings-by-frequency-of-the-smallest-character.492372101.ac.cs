public class Solution {
    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        
        int[] res = new int[queries.Length];
        
        for(int q = 0; q < queries.Length; q++)
        {
            int count = 0;
            for(int i = 0; i < words.Length; i++)
            {
                if(f(queries[q]) < f(words[i])){
                    count++;
                }
            }
            
            res[q] = count;
        }
        
        return res;
    }
    
    public int f(string word)
    {
        int[] frequency = new int[26];
        for(int i = 0; i < word.Length; i++)
        {
            frequency[word[i] - 'a']++;   
        }
        
        for(int i = 0; i < frequency.Length; i++)
        {
            if(frequency[i] != 0){
                return frequency[i];
            }
        }
        
        //Empty string
        return -1;
    }
}
