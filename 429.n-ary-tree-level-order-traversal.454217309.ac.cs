/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        
        if(root == null) return new List<IList<int>>();
        
        List<IList<int>> result = new List<IList<int>>();
        
        Queue<Node> bfs = new Queue<Node>();
        bfs.Enqueue(root);
        
        while(bfs.Count > 0)
        {
            var count = bfs.Count;
             
            List<int> cur = new List<int>();
            
            while(count > 0)
            {
                var popped = bfs.Dequeue();
                
                cur.Add(popped.val);
                
                foreach(var item in popped.children)
                {
                    bfs.Enqueue(item);
                }
                
                count--;
            }
            
            result.Add(cur);
        }
       
        return result;
    }
}
