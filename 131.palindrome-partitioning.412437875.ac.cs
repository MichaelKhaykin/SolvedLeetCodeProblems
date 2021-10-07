public class Solution {
    
    public Dictionary<string, bool> seen = new Dictionary<string, bool>();
            
    
   public void AllPossible(ReadOnlySpan<char> s, int index, List<string> build, List<IList<string>> all)
        {
            if (index == s.Length)
            {
                all.Add(build);
                return;
            }

            for (int x = 1; x <= s.Length; x++)
            {
                if (x + index > s.Length) break;

                var news = new List<string>(build);

                var substring = s.Slice(index, x).ToString();
                if (IsPalindrome(substring))
                {
                    news.Add(substring);

                    AllPossible(s, index + x, news, all);
                }
            }
        }

        public bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            
            while(s[start] == s[end])
            {
                if (start >= end && s[start] == s[end]) return true;
                
                start++;
                end--;
            }
            return false;
        }
        public IList<IList<string>> Partition(string s)
        {   
            if (s.Length == 1) return new List<IList<string>>() { new List<string>() { s } };
            
            var all = new List<IList<string>>();
            AllPossible(s.AsSpan(), 0, new List<string>(), all);

            return all;
        }
}
