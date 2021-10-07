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
    
     public void Recursive(TrieNode a, TrieNode b, string aprefix, string bprefix, List<int> xorValues)
        {
            if(a.Children.Count == 0 && b.Children.Count == 0)
            {
                aprefix += a.Value;
                bprefix += b.Value;

                int num1 = Convert.ToInt32(aprefix, 2);
                int num2 = Convert.ToInt32(bprefix, 2);
                xorValues.Add(num1 ^ num2);
                return;
            }

            aprefix += a.Value;
            bprefix += b.Value;
            foreach(var item in a.Children)
            {
                Recursive(item.Value, b.Children.Count == 1 ? b.Children.First().Value : item.Value.Value == '0' ? b.Children['1'] : b.Children['0'], aprefix, bprefix, xorValues);
            }
        }
    
    
    public int FindMaximumXOR(int[] nums) {
        List<string> strings = new List<string>();
            int maxLength = 0; 
            foreach(var num in nums)
            {
                string binaryForm = Convert.ToString(num, 2);
                if(binaryForm.Length > maxLength)
                {
                    maxLength = binaryForm.Length;
                }
                strings.Add(binaryForm);
            }

            for(int i = 0; i < strings.Count; i++)
            {
                string padding = new string(Enumerable.Repeat('0', maxLength - strings[i].Length).ToArray());
                strings[i] = padding + strings[i];
            }

            TrieTree tree = new TrieTree(strings);

            TrieNode leftNode;
            TrieNode rightNode;
            if(tree.Head.Children.Count == 1)
            {
                leftNode = tree.Head.Children.First().Value;
                rightNode = tree.Head.Children.First().Value;
            }
            else
            {
                leftNode = tree.Head.Children['0'];
                rightNode = tree.Head.Children['1'];
            }

            string aPrefix = "";
            string bPrefix = "";

            List<int> maybe = new List<int>();
            Recursive(leftNode, rightNode, aPrefix, bPrefix, maybe);

            return maybe.Max();
    }
}
