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
public class Solution 
{

    public void InOrder(TreeNode current, List<int> path)
    {
        if(current == null) return;

        InOrder(current.left, path);
        path.Add(current.val);
        InOrder(current.right, path);
    }

    public int MinDiffInBST(TreeNode root) {

        if(root == null) return 0;

        List<int> nums = new List<int>();
        InOrder(root, nums);

        int diff = int.MaxValue;
        for(int i = 0; i < nums.Count - 1; i++)
        {
            diff = Math.Min(diff, nums[i + 1] - nums[i]);
        }
        return diff;
    }
}
