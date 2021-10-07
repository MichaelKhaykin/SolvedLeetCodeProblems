/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class FindElements {

    HashSet<int> seen = new HashSet<int>();
    
    public FindElements(TreeNode root) {
        
        root.val = 0;
        
        Queue<TreeNode> nodes = new Queue<TreeNode>();
        nodes.Enqueue(root);
        while(nodes.Count > 0)
        {
            var curr = nodes.Dequeue();
            seen.Add(curr.val);
            
            if(curr.left != null)
            {
                curr.left.val = curr.val * 2 + 1;
                nodes.Enqueue(curr.left);
            }
            if(curr.right != null)
            {
                curr.right.val = curr.val * 2 + 2;
                nodes.Enqueue(curr.right);
            }
        }
        
    }
    
    public bool Find(int target) {
        return seen.Contains(target);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */
