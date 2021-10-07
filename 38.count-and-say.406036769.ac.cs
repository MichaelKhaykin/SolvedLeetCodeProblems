public class Solution {
    public string CountAndSay(int n) {
        
        Dictionary<int, string> baseCases = new Dictionary<int, string>()
        {
            [1] = "1",
            [2] = "11",
            [3] = "21",
            [4] = "1211",
            [5] = "111221"
        };
        
        if(baseCases.ContainsKey(n)) return baseCases[n];
        
        string build = baseCases[5];
        for(int i = 5; i < n; i++)
        {
            build = AddOn(build);
        }
        
        return build;
    }
    
    public string AddOn(string current)
    {
            char element = current[0];
            int num = 1;
           
            string returnValue = "";
        
            for (int i = 1; i < current.Length; i++)
            {
                if (element != current[i])
                {
                    returnValue += $"{num}{element}";

                    element = current[i];
                    num = 1;
                }
                else
                {
                    num++;
                }
            }
            returnValue += $"{num}{element}";

           

            return returnValue;
    }
}
