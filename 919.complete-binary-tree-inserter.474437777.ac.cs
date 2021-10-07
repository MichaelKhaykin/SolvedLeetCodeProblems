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
public class CBTInserter {

    TreeNode root;
    
    Queue<TreeNode> memo;
    
    public CBTInserter(TreeNode root) {
        this.root = root;
        
        memo = new Queue<TreeNode>();
        memo.Enqueue(root);
        
        while(memo.Count > 0)
        {
            var peek = memo.Peek();
            
            if(peek.left == null || peek.right == null)
            {
                if(peek.left != null){
                    memo.Enqueue(peek.left);
                }
                break;
            }
            
            memo.Dequeue();
            
            memo.Enqueue(peek.left);
            memo.Enqueue(peek.right);
        }
    }
    
    public int Insert(int v) {
        
        TreeNode newNode = new TreeNode(v);
        memo.Enqueue(newNode);
        
        var top = memo.Peek();
        
        if(top.left == null)
        {
            top.left = newNode;
        }
        else
        {
            memo.Dequeue();
            top.right = newNode;
        }
        
        return top.val;
    }
    
    
    public TreeNode Get_root() {
        return root;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */
