public class Solution {
  
    public IList<int> FindSubstring(string s, string[] words) {
       
        
        Dictionary<string, int> wordoFreq = new Dictionary<string, int>();
            foreach(var item in words)
            {
                if(wordoFreq.ContainsKey(item))
                {
                    wordoFreq[item]++;
                }
                else
                {
                    wordoFreq.Add(item, 1);
                }
            }

            List<int> indexes = new List<int>();
            int sliceAmount = words[0].Length;
            int targetAmount = words.Length;

            var spanVersion = s.AsSpan();

            for(int i = 0; i < s.Length; i++)
            {
             //   if (s.Length - (i + sliceAmount) < 0) break;
                if(i + words.Length * sliceAmount > s.Length) break;
                
                Dictionary<string, int> occurences = new Dictionary<string, int>();

                var currentSlice = spanVersion.Slice(i, sliceAmount).ToString();
                occurences.Add(currentSlice, 1);
                if (!wordoFreq.ContainsKey(currentSlice)) continue;

                int current = 1;
                if (current == targetAmount)
                {
                    indexes.Add(i);
                    continue;
                }
            
                for(int j = i + sliceAmount; j < s.Length; j += sliceAmount)
                {
                    if (j + sliceAmount > spanVersion.Length) break;
                    
                    var newSlice = spanVersion.Slice(j, sliceAmount).ToString();

                    if (!wordoFreq.ContainsKey(newSlice)) break;
                    
                    if (occurences.ContainsKey(newSlice))
                    {
                        occurences[newSlice]++;
                    }
                    else
                    {
                        occurences.Add(newSlice, 1);
                    }

                    if (occurences[newSlice] > wordoFreq[newSlice]) break;
                    current++;

                    if (current == targetAmount)
                    {
                        indexes.Add(i);
                        break;
                    }
                }
                
            }

            return indexes;
    }
}
