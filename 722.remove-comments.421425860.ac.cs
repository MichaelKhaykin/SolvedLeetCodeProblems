public class Solution {
    public IList<string> RemoveComments(string[] source) {
        
        List<string> result = new List<string>();
        
        bool isInBlockComment = false;
        bool isInLineComment = false;
        
        
        int ind = -1;
        
        StringBuilder builder = new StringBuilder();
        foreach(var line in source)
        {
            for(int i = 0; i < line.Length; i++)
            {
                if(i + 1 < line.Length && line[i] == '*' && line[i + 1] == '/' && isInBlockComment && ind != i && ind != -1)
                {
                    isInBlockComment = false;
                    i++;
                    continue;
                }
                
                if(isInBlockComment || isInLineComment) continue;
                
                if(i + 1 < line.Length && line[i] == '/' && line[i + 1] == '*' && !isInBlockComment && !isInLineComment)
                {
                    isInBlockComment = true;
                    ind = i + 1;
                }
                else if(i + 1 < line.Length && line[i] == '/' && line[i + 1] == '/' && !isInBlockComment && !isInLineComment)
                {
                    isInLineComment = true;
                }
                
                
                if(!isInBlockComment && !isInLineComment)
                {
                    builder.Append(line[i]);
                }
            }
            
            if(ind != -1)
            {
                ind *= 10000;
            }
            
            if(isInLineComment)
            {
                if(builder.Length != 0) 
                {
                    result.Add(builder.ToString());
                    builder.Clear();
                }
                isInLineComment = false;
            }
            
            if(!isInLineComment && !isInBlockComment)
            {
                if(builder.Length == 0) continue;
                
                result.Add(builder.ToString());
                builder.Clear();
            }
        }
        
        return result;
    }
}
