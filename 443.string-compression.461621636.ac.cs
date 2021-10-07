public class Solution {
    public int Compress(char[] chars) {
        
        int index = 0;
        int runningCount = 1;
        
        int arrayIndex = 0;
        
        while(index < chars.Length)
        {
            if(index + 1 < chars.Length)
            {
                if(chars[index] != chars[index + 1])
                {
                    if(runningCount == 1)
                    {
                        chars[arrayIndex] = chars[index];
                        arrayIndex++;
                    }
                    else
                    {
                        chars[arrayIndex] = chars[index];
                        arrayIndex++;
                        
                        var str = runningCount.ToString();
                        for(int i = 0; i < str.Length; i++)
                        {
                            chars[arrayIndex++] = str[i];
                        }
                        
                        runningCount = 1;
                    }
                }
                else
                {
                    runningCount++;
                }
            }
            else
            {
                if(runningCount == 1)
                {
                    chars[arrayIndex] = chars[index];
                    arrayIndex++;
                }
                else
                {
                    chars[arrayIndex] = chars[index];
                    arrayIndex++;

                    var str = runningCount.ToString();
                    for(int i = 0; i < str.Length; i++)
                    {
                        chars[arrayIndex++] = str[i];
                    }

                    runningCount = 1;
                }
            }
            index++;
        }
        
        return arrayIndex;
    }
}
