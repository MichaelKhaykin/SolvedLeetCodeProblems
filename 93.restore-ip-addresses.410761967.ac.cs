public class Solution {
    
    public void GenerateAll(string s, List<string> values, string current, string withoutDots, int dotCount)
        {
            if (withoutDots.Length == s.Length && dotCount == 4)
            {
                values.Add(current.Trim('.'));
                return;
            }

            if (dotCount > 4 || withoutDots.Length >= s.Length) return;

            if (s[withoutDots.Length] == '0')
            {
                GenerateAll(s, values, current + '0' + '.', withoutDots + '0', dotCount + 1);
                return;
            }

            string b = current;
            string c = withoutDots;
            string newn = "";
            for (int i = withoutDots.Length; i < withoutDots.Length + 3; i++)
            {
                if (i >= s.Length) return;

                b += s[i];
                c += s[i];
                newn += s[i]; 
                if (int.Parse(newn) <= 255) GenerateAll(s, values, b + '.', c, dotCount + 1);
            }
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            if (s.Length == 0) return new List<string>();

            List<string> values = new List<string>();
            GenerateAll(s, values, "", "", 0);
            return values;
        }
}
