public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> mapping = new Dictionary<char, int>()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };
        
        Dictionary<string, int> specials = new Dictionary<string, int>()
        {
            ["IV"] = 4,
            ["IX"] = 9,
            ["XL"] = 40,
            ["XC"] = 90,
            ["CD"] = 400,
            ["CM"] = 900
        };
        
        int result = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(i + 1 < s.Length)
            {
                if(specials.ContainsKey("" + s[i] + s[i + 1]))
                {
                    result += specials["" + s[i] + s[i + 1]];
                    i++;
                    continue;
                }
            }
            if(mapping.ContainsKey(s[i]))
            {
                result += mapping[s[i]];
            }
        }
        return result;
    }
}
