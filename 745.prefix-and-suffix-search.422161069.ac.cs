public class TrieNode
    {
        public char Value { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }
        public TrieNode(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNode>();
        }
    }

public class TrieTree
{
    public TrieNode Head { get; }
    public TrieTree()
    {
        Head = new TrieNode('$');
    }

    public TrieTree(IEnumerable<string> collection)
        : base()
    {
        foreach(var item in collection)
        {
            AddWord(item);
        }
    }

    public void AddWord(string word)
    {
        TrieNode current = Head;
        foreach (var item in word)
        {
            if (current.Children.ContainsKey(item))
            {
                current = current.Children[item];
                continue;
            }

            TrieNode child = new TrieNode(item)
            {
                IsEndOfWord = item == word[word.Length - 1]
            };
            current.Children.Add(item, child);
            current = child;
        }
    }

    int counter = 0;

    public int Matches(string word)
    {
        counter = 0;

        Matches(word, Head, 0);

        return counter;
    }

    private void Matches(string word, TrieNode current, int ind)
    {
        if (ind == word.Length && current.IsEndOfWord)
        {
            counter++;
            return;
        }

        if (word[ind] == '*')
        {
            foreach (var item in current.Children)
            {
                Matches(word, item.Value, ind + 1);
            }
        }

        if (current.Children.ContainsKey(word[ind]))
        {
            Matches(word, current.Children[word[ind]], ind + 1);
        }
    }

    public List<string> GetWords(string prefix)
    {
        TrieNode current = Head;
        foreach (var item in prefix)
        {
            if (current.Children.ContainsKey(item))
            {
                current = current.Children[item];
            }
            else
            {
                return new List<string>();
            }
        }

        List<string> words = new List<string>();
        GetWords(current, prefix, words);
        return words;
    }

    private void GetWords(TrieNode current, string prefix, List<string> words)
    {
        if (current.IsEndOfWord)
        {
            words.Add(prefix);
        }

        foreach (var child in current.Children)
        {
            GetWords(child.Value, prefix + child.Key, words);
        }
    }
}

public class WordFilter {

    TrieTree tree;
    Dictionary<string, List<int>> x = new Dictionary<string, List<int>>();
    public WordFilter(string[] words) {
        tree = new TrieTree();
        
        for(int i = 0; i < words.Length; i++)
        {
            StringBuilder build = new StringBuilder(words[i]);
            build.Insert(0, '#');
            tree.AddWord(build.ToString());
            
            for(int b = words[i].Length - 1; b >= 0; b--)
            {
                build.Insert(0, words[i][b]);
                tree.AddWord(build.ToString());
            }
            
            if(!x.ContainsKey(words[i]))
            {
                x.Add(words[i], new List<int>() { i });
            }
            else
            {
                x[words[i]].Add(i);
            }
        }
    }
    
    public int F(string prefix, string suffix) {
        var words = tree.GetWords(suffix + "#" + prefix);
        
        int ind = -1;
        foreach(var word in words)
        {
            var arr = word.Split('#');
            var actual = arr[arr.Length - 1];
            
            if(!x.ContainsKey(actual)) continue;
            
            ind = Math.Max(x[actual][^1], ind);
        }
        
        return ind;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */
