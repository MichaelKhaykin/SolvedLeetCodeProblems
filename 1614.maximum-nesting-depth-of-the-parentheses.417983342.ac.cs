public class Solution {
    public int MaxDepth(string s) {
        int parensSeenSoFar = 0;
        int max = int.MinValue;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '(')
            {
                parensSeenSoFar++;
            }
            else if(s[i] == ')') 
            {
                parensSeenSoFar--;
            }
            max = Math.Max(max, parensSeenSoFar);
        }
        return max;
    }
}
