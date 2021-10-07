public class Solution {
    
    public class Node
        {
            public int Index { get; set; }

            public int BadIndex { get; set; }

            public List<int> Ahead = new List<int>();

            public List<int> Guarentee = new List<int>();
            public Node(int a)
            {
                Index = a;
            }
        }

          public int MaxRepOpt1(string text)
        {

            List<Node> nodes = new List<Node>(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                nodes.Add(new Node(i));
                nodes[i].Guarentee.Add(i);
                bool didGoAnyBad = false;

                int bad = 0;
                for (int j = i + 1; j < text.Length; j++)
                {
                    if (text[i] != text[j])
                    {
                        if (bad == 1) break;

                        didGoAnyBad = true;
                        nodes[i].BadIndex = j;
                        bad++;
                    }
                    else if(bad == 0)
                    {
                        nodes[i].Guarentee.Add(j);
                    }
                    nodes[i].Ahead.Add(j);
                }

                if (didGoAnyBad == false && i == 0)
                {
                    Console.WriteLine("fuck");
                    return text.Length;
                }
            }

            int max = 1;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Ahead.Count == 0) continue;

                for (int j = nodes.Count - 1; j >= 0; j--)
                {
                    var ah = nodes[i].Ahead;
                    var g = nodes[i].Guarentee;
                    
                    if((j < g[0] || j > g[g.Count - 1]) && text[j] == text[nodes[i].Index])
                    {
                        max = Math.Max(max, g.Count + 1);
                    }

                    if((j < ah[0] - 1 || j > ah[ah.Count - 1]) && text[j] == text[nodes[i].Index])
                    {
                        max = Math.Max(max, nodes[i].Ahead.Count + 1);
                        break;
                    }
                }
                
            }


            return max;
        }
    
    public int GetLength(string x)
    {
        int longest = 0;
        int temp = 0;
        
        for(int i = 0; i < x.Length - 1; i++)
        {
            if(x[i] != x[i + 1])
            {
                longest = Math.Max(longest, temp);
                temp = 0;
            }
            else
            {
                temp++;
            }
        }
        longest = Math.Max(longest, temp);
        
        return longest + 1;
    }
}
