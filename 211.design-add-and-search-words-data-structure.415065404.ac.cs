public class Node
{
    public char val;
    public Dictionary<char, Node> children;
    public bool IsWord = false;
    
    public Node(char val)
    {
        this.val = val;
        children = new Dictionary<char, Node>();
    }
}

public class WordDictionary {

    /** Initialize your data structure here. */
    Node Head = new Node('$');
    public WordDictionary() {
        
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        var curr = Head;
        int x = 0;
        while(x < word.Length && curr.children.ContainsKey(word[x]))
        {
            curr = curr.children[word[x]];
            x++;
        }
        
        for(int i = x; i < word.Length; i++)
        {
            curr.children.Add(word[i], new Node(word[i]));
            curr = curr.children[word[i]];
        }
        
        curr.IsWord = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
          return Helper(Head, 0, word);
    }
    
    public bool Helper(Node current, int index, string word)
    {
        if(index == word.Length)
        {
            return current.IsWord;
        }
        
        if(current.children.ContainsKey(word[index]))
        {
            return Helper(current.children[word[index]], index + 1, word);    
        }
        else if(word[index] == '.')
        {
            foreach(var item in current.children)
            {
                if(Helper(item.Value, index + 1, word))
                {
                    return true;
                }
            }
        }
    
        return false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
