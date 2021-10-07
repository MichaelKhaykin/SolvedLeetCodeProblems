public class Solution {
    
        List<char> possible = new List<char>() { 'a', 'b', 'c' };

        void Traverse(List<string> possiblities, StringBuilder current, int index, int total)
        {
            if (index == total)
            {
                possiblities.Add(current.ToString());
                return;
            }

            for (int i = 0; i < possible.Count; i++)
            {
                StringBuilder n = new StringBuilder(current.ToString());

                while (current.Length > 0 && i < possible.Count && n[current.Length - 1] == possible[i])
                {
                    i++;
                }

                if (i >= possible.Count) continue;

                n.Append(possible[i]);

                Traverse(possiblities, n, index + 1, total);
            }
        }

        public string GetHappyString(int n, int k)
        {
            List<string> ret = new List<string>();
            Traverse(ret, new StringBuilder(), 0, n);

            if (ret.Count < k) return "";

            return ret[k - 1];
        }
}
