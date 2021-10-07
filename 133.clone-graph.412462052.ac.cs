/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node)
        {
            if(node == null) return null;
        
            Dictionary<int, Node> ogs = new Dictionary<int, Node>();
            Queue<Node> path = new Queue<Node>();
            path.Enqueue(node);
            while (path.Count > 0)
            {
                var curr = path.Dequeue();
                if (ogs.ContainsKey(curr.val)) continue;
                ogs.Add(curr.val, curr);

                foreach (var item in curr.neighbors)
                {
                    if (path.Contains(item) || item == curr) continue;
                    path.Enqueue(item);
                }
            }

            Node start = new Node(node.val);
            Queue<Node> nexts = new Queue<Node>();
            nexts.Enqueue(start);

            Dictionary<int, Node> current = new Dictionary<int, Node>();
            current.Add(start.val, start);
            while(nexts.Count > 0)
            {
                var curr = nexts.Dequeue();
                if (current[curr.val].neighbors.Count > 0) continue;
                
                if (!current.ContainsKey(curr.val))
                {
                    current.Add(curr.val, curr);
                }

                var children = ogs[curr.val].neighbors;
                
                foreach(var child in children)
                {
                    if (!current.ContainsKey(child.val))
                    {
                        current.Add(child.val, new Node(child.val));
                    }
                    curr.neighbors.Add(current[child.val]);
                    nexts.Enqueue(current[child.val]);
                }
            }


            return start;
        }
}
