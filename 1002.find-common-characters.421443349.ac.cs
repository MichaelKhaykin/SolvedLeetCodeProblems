public class Solution {
        
    public IList<string> CommonChars(string[] A)
        {

            List<Dictionary<char, int>> maps = new List<Dictionary<char, int>>();
            int minLeng = int.MaxValue;
            int index = -1;
            for (int x = 0; x < A.Length; x++)
            {
                var item = A[x];

                if (minLeng > item.Length)
                {
                    minLeng = item.Length;
                    index = x;
                }

                Dictionary<char, int> current = new Dictionary<char, int>();
                for (int i = 0; i < item.Length; i++)
                {
                    if (current.ContainsKey(item[i]))
                    {
                        current[item[i]]++;
                    }
                    else
                    {
                        current.Add(item[i], 1);
                    }
                }

                maps.Add(current);
            }

            var str = A[index];

            List<string> result = new List<string>();

            HashSet<char> okdsa = new HashSet<char>();
            foreach (var character in str)
            {
                if (okdsa.Add(character) == false) continue;


                int min = int.MaxValue;
                bool add = true;
                foreach (var map in maps)
                {
                    if (!map.ContainsKey(character))
                    {
                        add = false;
                        break;
                    }

                    min = Math.Min(min, map[character]);
                }

                if (!add) continue;

                for (int i = 0; i < min; i++)
                {
                    result.Add(character.ToString());
                }
            }

            return result;
        }
}
