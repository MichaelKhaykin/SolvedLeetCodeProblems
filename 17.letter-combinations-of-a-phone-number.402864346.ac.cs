public class Solution {
    
    public void Recursive(List<char> initial, List<List<char>> rest, string prefix, IList<string> returnVals)
        {
            if (rest.Count == 0)
            {
                for(int i = 0; i < initial.Count; i++)
                {
                    returnVals.Add(prefix + initial[i]);
                }
                return;
            }

           
            for(int i = 0; i < initial.Count; i++)
            {
                 List<List<char>> newrest = new List<List<char>>();
            for(int b = 1; b < rest.Count; b++)
            {
                newrest.Add(rest[b]);
            }
                Recursive(rest[0], newrest, prefix + initial[i], returnVals);
            }
        }
    
    public IList<string> LetterCombinations(string digits) {
        if(digits == "") return new List<string>();
        
        var DigitMapping = new Dictionary<int, List<char>>()
            {
                [0] = new List<char>() { },
                [1] = new List<char>() { },
                [2] = new List<char>() { 'a', 'b', 'c' },
                [3] = new List<char>() { 'd', 'e', 'f' },
                [4] = new List<char>() { 'g', 'h', 'i' },
                [5] = new List<char>() { 'j', 'k', 'l' },
                [6] = new List<char>() { 'm', 'n', 'o' },
                [7] = new List<char>() { 'p', 'q', 'r', 's' },
                [8] = new List<char>() { 't', 'u', 'v' },
                [9] = new List<char>() { 'w', 'x', 'y', 'z' },
            };

            List<List<char>> possibilites = new List<List<char>>();
            foreach (var item in digits)
            {
                possibilites.Add(DigitMapping[int.Parse(item.ToString())]);
            }

            if (possibilites.Count == 1)
            {
                IList<string> ret = new List<string>();
                foreach (var item in possibilites[0])
                {
                    ret.Add("" + item);
                }
                return ret;
            }

            IList<string> strings = new List<string>();
            var initial = possibilites[0];
            possibilites.RemoveAt(0);
            Recursive(initial, possibilites, "", strings);

            return strings;
    }
}
