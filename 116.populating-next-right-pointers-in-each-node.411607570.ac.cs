/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    
    public Node Traverse(Node root)
    {
        if(root == null) return null;
        
        Queue<Node> nodes = new Queue<Node>();
        nodes.Enqueue(root);
        
        while(nodes.Count > 0)
        {
            int initialSize = nodes.Count;
            
            List<Node> m = new List<Node>();
            while(initialSize > 0)
            {
                var curr = nodes.Dequeue();
                initialSize--;
                if(curr == null) continue;
                
                m.Add(curr);
                
                nodes.Enqueue(curr.left);
                nodes.Enqueue(curr.right);
            }
            
            for(int i = 0; i < m.Count - 1; i++)
            {
                m[i].next = m[i + 1];
            }
        }
        
        return root;
    }
    
    public Node Connect(Node root) {
        return Traverse(root);
    }
}
