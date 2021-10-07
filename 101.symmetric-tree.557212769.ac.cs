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
public class Solution {
    
    bool IsSymmetric(TreeNode a, TreeNode b)
    {
        return false;
    }
    
    static bool BothNullOrEqual(TreeNode a, TreeNode b) {
        if(a == null ^ b == null) {
            return false;
        }
        if(a == null && b == null) {
            return true;
        }
        return a.val == b.val;
    }
    
    public bool IsSymmetric(TreeNode root) {
        if(root == null) {
            return true;
        }
        
        Queue<TreeNode> lhs = new Queue<TreeNode>();
        Queue<TreeNode> rhs = new Queue<TreeNode>();
        
        lhs.Enqueue(root);
        rhs.Enqueue(root);
        while(lhs.Count > 0 && rhs.Count > 0) {
            TreeNode l = lhs.Dequeue();
            TreeNode r = rhs.Dequeue();
            if(!BothNullOrEqual(l, r)) {
                return false;
            }
            else {
                if(l != null) {
                    lhs.Enqueue(l.left);
                    lhs.Enqueue(l.right);
                }
                if(r != null) {
                    rhs.Enqueue(r.right);
                    rhs.Enqueue(r.left);
                }
            }
        }
        return lhs.Count == rhs.Count;
    }
}
