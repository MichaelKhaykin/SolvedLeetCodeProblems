public class Solution {
    public int CountCharacters(string[] words, string chars) {
        
        int sum = 0;
        
        List<char> charList = new List<char>();
        foreach(var @char in chars)
        {
            charList.Add(@char);
        }
        
        foreach(var str in words){
            
            bool good = true;
            
            List<char> cur = new List<char>(charList);
            
            foreach(var @char in str){
                
                int index = cur.IndexOf(@char);
                
                if(index == -1)
                {
                    good = false;
                    break;
                }
                else
                {
                    cur.RemoveAt(index);
                }
            }
            
            if(!good) continue;
            
            sum += str.Length;
        }
        
        return sum;
    }
}
