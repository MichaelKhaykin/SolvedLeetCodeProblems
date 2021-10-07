public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
     
        HashSet<string> allWords = new HashSet<string>(dictionary);
        
        var longestWordLength = dictionary.Select((x) => x.Length).Max();
        
        
        var words = sentence.Split(' ');
        
        StringBuilder final = new StringBuilder();
        
        foreach(var word in words)
        {
            bool sucess = false;
            
            for(int i = 1; i <= longestWordLength; i++)
            {
                if(i >= word.Length)
                {
                    sucess = true;
                    final.Append(word);
                    final.Append(" ");
                    break;
                }
                
                var prefix = word.Substring(0, i);
                if(allWords.Contains(prefix))
                {
                    sucess = true;
                    final.Append(prefix);
                    final.Append(" ");
                    break;
                }
            }
            
            if(!sucess)
            {
                final.Append(word);
                final.Append(" ");
            }
        }
        
        
        return final.ToString().Trim();
        
    }
}
