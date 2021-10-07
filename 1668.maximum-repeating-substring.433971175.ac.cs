public class Solution {
    
            private void KnuthMorrisPrattSearch(string txt, string pattern, IList<int> foundStartIndices)
            {
                int patternLength = pattern.Length;
                int textLength = txt.Length;

                int[] lps = new int[patternLength];
                int j = 0;

                ComputeLPSArray(pattern, patternLength, lps);

                int i = 0;
                while (i < textLength)
                {
                    if (pattern[j] == txt[i])
                    {
                        j++;
                        i++;
                    }
                    if (j == patternLength)
                    {
                        foundStartIndices.Add((i - j));
                        j = lps[j - 1];
                    }
                    else if (i < textLength && pattern[j] != txt[i])
                    {
                        if (j != 0)
                        {
                            j = lps[j - 1];
                        }
                        else
                        {
                            i = i + 1;
                        }
                    }
                }
            }


        private static void ComputeLPSArray(string pattern, int patternLength, int[] lps)
        {
            lps[0] = 0;

            for (int i = 1; i < patternLength; i++)
            {
                int k = lps[i - 1];
                while (k > 0 && pattern[i] != pattern[k])
                {
                    k = lps[k - 1];
                }

                if (pattern[i] == pattern[k])
                {
                    k++;
                }

                lps[i] = k;
            }
        }

            public int MaxRepeating(string sequence, string word)
            {
                IList<int> indices = new List<int>();
                KnuthMorrisPrattSearch(sequence, word, indices);

                int res = 0;
                IDictionary<int, int> map = new Dictionary<int, int>();

                foreach (var index in indices)
                {
                    map[index] = 1;
                    if (map.ContainsKey(index - word.Length))
                    {
                        map[index] = map[index - word.Length] + 1;
                    }

                    res = Math.Max(res, map[index]);
                }

                return res;
            }
}
