public class Solution {
  
          public int Distance(string a, string b)
        {
            int count = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != b[i])
                {
                    count++;
                    if (count > 1) return -1;
                }
            }
            return 1;
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<string>> combos = new Dictionary<string, List<string>>();
            if (!wordList.Contains(beginWord))
            {
                wordList.Add(beginWord);
            }
            foreach (var item in wordList)
            {
                bool didOccur = false;
                foreach (var otheritem in wordList)
                {
                    if (Distance(item, otheritem) == 1)
                    {
                        didOccur = true;
                        if (combos.ContainsKey(item))
                        {
                            combos[item].Add(otheritem);
                        }
                        else
                        {
                            combos.Add(item, new List<string>() { otheritem });
                        }
                    }
                }

                if (!didOccur && !combos.ContainsKey(item)) combos.Add(item, new List<string>());
            }

            HashSet<string> visited = new HashSet<string>();
            Queue<(string word, int level)> path = new Queue<(string, int)>();
            path.Enqueue((beginWord, 1));
            visited.Add(beginWord);
            while (path.Count > 0)
            {
                var current = path.Dequeue();

                var nextChildren = combos[current.word];
                foreach (var item in nextChildren)
                {
                    if (visited.Contains(item)) continue;

                    if (item == endWord) return current.level + 1;
                    visited.Add(item);
                    path.Enqueue((item, current.level + 1));
                }
            }

            return 0;
        }
    
        public int LadderLengthH(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<string>> combos = new Dictionary<string, List<string>>();
            if (!wordList.Contains(beginWord))
            {
                wordList.Add(beginWord);
            }
            foreach (var item in wordList)
            {
                List<string> generics = new List<string>();
                for (int i = 0; i < item.Length; i++)
                {
                    string current = "";
                    for (int x = 0; x < item.Length; x++)
                    {
                        if (i == x)
                        {
                            current += "*";
                            continue;
                        }
                        current += item[x];
                    }
                    generics.Add(current);
                }
                combos.Add(item, generics);
            }

            HashSet<string> visited = new HashSet<string>();
            Queue<(string word, int level)> path = new Queue<(string, int)>();
            path.Enqueue((beginWord, 1));
            visited.Add(beginWord);
            while (path.Count > 0)
            {
                var current = path.Dequeue();

                var nextChildren = combos[current.word];
                foreach (var item in nextChildren)
                {
                    for (int blah = 0; blah < wordList.Count; blah++)
                    {
                        bool add = true;
                        for (int i = 0; i < item.Length; i++)
                        {
                            if (wordList[blah][i] != item[i] && item[i] != '*')
                            {
                                add = false;
                                break;
                            }
                        }

                        if (add && !visited.Contains(wordList[blah]))
                        {
                            if (wordList[blah] == endWord) return current.level + 1;
                            visited.Add(wordList[blah]);
                            path.Enqueue((wordList[blah], current.level + 1));
                        }
                    }
                }
            }

            return 0;
        }
}
