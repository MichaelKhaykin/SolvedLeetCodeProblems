public class Solution {
            public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            string newString = new string(s.Where((t) => (t >= 'a' && t <= 'z') 
                                                  || (t >= '0' && t <= '9')).ToArray());

            string reverse = "";
            for(int i = newString.Length - 1; i >= 0; i--)
            {
                reverse += newString[i];
            }

            return newString == reverse;
            }
}
