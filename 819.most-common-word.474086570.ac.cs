public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        
        Dictionary<string, int> occured = new Dictionary<string, int>();
        
        HashSet<string> bannedWords = new HashSet<string>(banned);
        
        var words = paragraph.Split(' ');
        words = words.Select(x => x.ToLower()).ToArray();
        words = words.Select(x => Fix(x)).ToArray();
        
        int max = 0;
        string maxstr = "";
        
        foreach(var word in words)
        {
            if(bannedWords.Contains(word)) continue;
            
            if(occured.ContainsKey(word))
            {
                occured[word]++;
            
                if(occured[word] > max)
                {
                    max = occured[word];
                    maxstr = word;
                }
            }
            else if(occured.ContainsKey(word) == false)
            {
                occured.Add(word, 1);
                
                if(max < 1){
                    max = 1;
                    maxstr = word;
                }
                
            }
        }
        
        return maxstr;
    }
    
    public string Fix(string word)
    {
        string x = "";
                
        for(int i = 0; i < word.Length; i++)
        {
            if(word[i] < 'a' || word[i] > 'z'){
                return x;
            }
            else{
                x += word[i];
            }
        }
            
        return x;
    }
}
