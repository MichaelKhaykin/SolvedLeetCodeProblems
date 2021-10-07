public class TrieNode
{
    public char val;
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;
    
    public TrieNode(char val)
    {
        this.val = val;
        children = new Dictionary<char, TrieNode>();
    }
}

public class Trie {

    /** Initialize your data structure here. */
    
    TrieNode Head;
    public Trie() {
        Head = new TrieNode('$');
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        var current = Head;
        int i = 0; 
        while(i < word.Length && current.children.ContainsKey(word[i]))
        {   
           current = current.children[word[i]];
           i++; 
        }
        
        for(int x = i; x < word.Length; x++)
        {
            current.children.Add(word[x], new TrieNode(word[x]));
            current = current.children[word[x]];
        }
        
        current.isEndOfWord = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        var current = Head;
        for(int i = 0; i < word.Length; i++)
        {
            if(!current.children.ContainsKey(word[i])) return false;
            current = current.children[word[i]];
        }
        
        return current.isEndOfWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        var current = Head;
        for(int i = 0; i < prefix.Length; i++)
        {
            if(!current.children.ContainsKey(prefix[i])) return false;
            current = current.children[prefix[i]];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
