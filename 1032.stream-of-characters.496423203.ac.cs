public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public char Value { get; set; }
    public bool IsEndOfWord { get; set; }
    
    public TrieNode(char v){
        Value = v;
    }
}

public class Trie
{
    public TrieNode root = new TrieNode('$');
    
    public Trie()
    {
        
    }
    
    public void Add(string word)
    {
        var mover = root;
        
        for(int i = 0; i < word.Length; i++)
        {
            if(!mover.Children.ContainsKey(word[i]))
            {
                mover.Children.Add(word[i], new TrieNode(word[i]));
            }
           
            mover = mover.Children[word[i]];
            
            if(i == word.Length - 1)
            {
                mover.IsEndOfWord = true;
            }
        }
    }
}

public class StreamChecker {

    Trie tree = new Trie();
    
    LinkedList<TrieNode> links = new LinkedList<TrieNode>();
    
    public StreamChecker(string[] words) {
        
        foreach(var word in words)
        {
            tree.Add(word);
        }
    }
    
    public bool Query(char letter) {
        
        bool res = false;
        
        if(links.Count > 0)
        {
            var current = links.First;
            while(current != null)
            {
                var next = current.Next;
                
                if(current.Value.Children.ContainsKey(letter))
                {
                    current.Value = current.Value.Children[letter];
                    if(current.Value.IsEndOfWord)
                    {
                        res = true;
                    }
                }
                else
                {
                    links.Remove(current);
                }
                
                current = next;
            }
        }
        
        if(tree.root.Children.ContainsKey(letter))
        {
            links.AddLast(tree.root.Children[letter]);
            if(tree.root.Children[letter].IsEndOfWord)
            {
                res = true;
            }
        }
        
        return res;
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
