public class Solution {
    public string ReverseStr(string s, int k)
    {
        if(s.Length <= k)
        {
            return new string(s.Reverse().ToArray());
        }
        
        if (s.Length >= k && s.Length < 2 * k)
        {
            StringBuilder copy = new StringBuilder(s);
            for(int i = k - 1; i >= 0; i--)
            {
                copy[(k - 1) - i] = s[i];
            }
            return copy.ToString();
        }

        int leftOff = -1;
        for (int i = 0; i < s.Length; i += 2 * k)
        {
            if(i + k >= s.Length)
            {
                var rest = s.Substring(i).ToArray();
                StringBuilder b = new StringBuilder(s);
                for(int j = i; j < s.Length; j++)
                {
                    b[j] = rest[rest.Length - 1 - (j - i)];
                }

                return b.ToString();
            }
            
            var sub = s.Substring(i, k).Reverse().ToArray();

            StringBuilder builder = new StringBuilder(s);
            for(int j = i; j < i + k; j++)
            {
                builder[j] = sub[j - i];
            }

            s = builder.ToString();
            leftOff = i;
        }

      

        return s;
    }
    
    string Reverse(string a, int stop)
    {
        StringBuilder copy = new StringBuilder(a);
        for(int i = a.Length - 1; i >= stop; i--)
        {
            copy[i] = a[stop - i];
        }
        return copy.ToString();
    }
}
