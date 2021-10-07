/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    
    public enum Direction
    {
        Left,
        Right
    }
    
    List<Direction> total = new List<Direction>();
    public void Traverse(TreeNode root, TreeNode target, List<Direction> current)
    {
        if(root == null) return;
        
        if(root == target)
        {
            total.AddRange(new List<Direction>(current));
            return;
        }
        
        Traverse(root.left, target, new List<Direction>(current) { Direction.Left });
        Traverse(root.right, target, new List<Direction>(current) { Direction.Right });
    }
    
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        
        Traverse(original, target, new List<Direction>());
        
        TreeNode mover = cloned;
        for(int i = 0; i < total.Count; i++)
        {
            if(total[i] == Direction.Left)
            {
                mover = mover.left;
            }
            else
            {
                mover = mover.right;
            }
        }
        
        return mover;
    }
}
