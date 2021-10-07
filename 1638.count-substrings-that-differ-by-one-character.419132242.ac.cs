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
    {
        Head = new TrieNode('$');
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
        if(current.IsEndOfWord)
        {
            counter++;
            return;
        }
        
        if(word[ind] == '*')
        {
            foreach(var item in current.Children)
            {
                Matches(word, item.Value, ind + 1);
            }
        }
        
        if(current.Children.ContainsKey(word[ind]))
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

public class Solution {
    
    public int CountSubstrings(string s, string t) {
        List<string> allsubs = new List<string>();
        
        for(int i = 0; i < s.Length; i++)
        {
            StringBuilder b = new StringBuilder(s[i].ToString());
            allsubs.Add(b.ToString());
            for(int j = i + 1; j < s.Length; j++)
            {
                b.Append(s[j]);        
                allsubs.Add(b.ToString());
            }
        }
        
        TrieTree tree = new TrieTree();
        
        List<string> othersubs = new List<string>();
        
        for(int i = 0; i < t.Length; i++)
        {
            StringBuilder b = new StringBuilder(t[i].ToString());
         //   tree.AddWord(b.ToString());
            othersubs.Add(b.ToString());
            for(int j = i + 1; j < t.Length; j++)
            {
                b.Append(t[j]);
          //      tree.AddWord(b.ToString());
                othersubs.Add(b.ToString());
            }
        }
        
        int total = 0;
        foreach(var item in allsubs)
        {
            foreach(var x in othersubs)
            {
                if(item.Length != x.Length) continue;
                
                if(DifferByOne(x, item))
                {
                    total++;                    
                }
            }
        }
        
        return total;
    }
    
    public bool DifferByOne(string a, string b)
    {
        int diffs = 0;
        for(int i = 0; i < a.Length; i++)
        {
            if(a[i] != b[i])
            {
                diffs++;
                if(diffs > 1) return false;
            }
        }
        
        return diffs == 1;
    }
}
