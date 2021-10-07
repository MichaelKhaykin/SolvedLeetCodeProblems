public class Solution {
    public char FindKthBit(int n, int k) {
        return Generate(n)[k - 1];
    }
    
    public string Generate(int n)
    {
        if(n == 1) return "0";
        
        var previous = Generate(n - 1);
        string s = previous + "1" + reverse(invert(previous)); 
        
        return s;
    }
    
    public string reverse(string input)
    {
        StringBuilder b = new StringBuilder();
        for(int i = input.Length - 1; i >= 0; i--)
        {
            b.Append(input[i]);
        }
        return b.ToString();
    }
    
    public string invert(string input)
    {
        StringBuilder b = new StringBuilder();
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i] == '0')
            {
                b.Append("1");
            }
            else
            {
                b.Append("0");
            }
        }
        return b.ToString();
    }
}
