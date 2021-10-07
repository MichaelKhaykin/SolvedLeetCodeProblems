public class Solution {
    
    List<(string, int)> validWords = new List<(string, int)>()
        {
            ("eight", 8),
            ("six", 6),
            ("seven", 7),
            ("zero", 0),
            ("two", 2),
            ("three", 3),
            ("four", 4),
            ("five", 5),
            ("nine", 9),
            ("one", 1)
        };

        Dictionary<string, Dictionary<char, int>> Counts = new Dictionary<string, Dictionary<char, int>>()
        {
            ["zero"] = new Dictionary<char, int>()
            {
                ['z'] = 1,
                ['e'] = 1,
                ['r'] = 1,
                ['o'] = 1
            },
            ["one"] = new Dictionary<char, int>()
            {
                ['o'] = 1,
                ['n'] = 1,
                ['e'] = 1
            },
            ["two"] = new Dictionary<char, int>()
            {
                ['t'] = 1,
                ['w'] = 1,
                ['o'] = 1,
            },
            ["three"] = new Dictionary<char, int>()
            {
                ['t'] = 1,
                ['h'] = 1,
                ['r'] = 1,
                ['e'] = 2
            },
            ["four"] = new Dictionary<char, int>()
            {
                ['f'] = 1,
                ['o'] = 1,
                ['u'] = 1,
                ['r'] = 1
            },
            ["five"] = new Dictionary<char, int>()
            {
                ['f'] = 1,
                ['i'] = 1,
                ['v'] = 1,
                ['e'] = 1
            },
            ["six"] = new Dictionary<char, int>()
            {
                ['s'] = 1,
                ['i'] = 1,
                ['x'] = 1
            },
            ["seven"] = new Dictionary<char, int>()
            {
                ['s'] = 1,
                ['e'] = 2,
                ['v'] = 1,
                ['n'] = 1
            },
            ["eight"] = new Dictionary<char, int>()
            {
                ['e'] = 1,
                ['i'] = 1,
                ['g'] = 1,
                ['h'] = 1,
                ['t'] = 1
            },
            ["nine"] = new Dictionary<char, int>()
            {
                ['n'] = 2,
                ['i'] = 1,
                ['e'] = 1
            }
        };

        public string OriginalDigits(string s)
        {

            int[] letters = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                letters[s[i] - 'a']++;
            }

            List<int> numbers = new List<int>();

            int j = 0;

            
            while (j < validWords.Count)
            {
                var dict = Counts[validWords[j].Item1];
                while (DoesFit(dict, letters))
                {
                    numbers.Add(validWords[j].Item2);

                    for (int i = 0; i < letters.Length; i++)
                    {
                        var letter = (char)(i + 'a');

                        if (dict.ContainsKey(letter) == false) continue;

                        letters[i] -= dict[letter];
                    }
                }

                j++;
            }


            numbers.Sort();

            StringBuilder ret = new StringBuilder();
            foreach (var num in numbers)
            {
                ret.Append($"{num}");
            }

            return ret.ToString();
        }
    
    public bool DoesFit(Dictionary<char, int> count, int[] letters)
    {
        int counter = 0;
        for(int i = 0; i < letters.Length; i++)
        {
            if(letters[i] == 0) continue;
            
            char letter = (char)(i + 'a');
            if(count.ContainsKey(letter) == false) continue;
            
            if(letters[i] < count[letter]) return false;
            counter++;
        }
        
        return counter == count.Count;
    }
}
