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
    
    private int sum = 0;

    public TreeNode ConvertBST(TreeNode root) {
        if (root != null) {
            ConvertBST(root.right);
            sum += root.val;
            root.val = sum;
            ConvertBST(root.left);
        }
        return root;
    }
    
    public TreeNode ConvertBSTs(TreeNode root) {
        
        if(root == null) {
            return null;
        }
        
        List<int> keys = new List<int>();
        Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
        GetAllKeys(root, keys, map);
        
        int[] dp = new int[keys.Count];
        dp[dp.Length - 1] = 0 + keys[keys.Count - 1];
        
        for(int i = keys.Count - 2; i >= 0; i--)
        {
            dp[i] = keys[i] + dp[i + 1];
        }
        Make(root, dp, map);
        return root;
    }
    
    public void Make(TreeNode root, int[] dp, Dictionary<TreeNode, int> map)
    {
        if(root == null)
        {
            return;
        }
        
        root.val = dp[map[root]];
        Make(root.left, dp, map);
        Make(root.right, dp, map);
    }
    
    public void GetAllKeys(TreeNode root, List<int> list, Dictionary<TreeNode, int> map)
    {
        if(root == null) return;
        
        GetAllKeys(root.left, list, map);
        list.Add(root.val);
        map.Add(root, list.Count - 1);
        GetAllKeys(root.right, list, map);
    }
}
