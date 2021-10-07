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

    Dictionary<TreeNode, int> depth;
    int max_depth;
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        depth = new Dictionary<TreeNode, int>();
     
        dfs(root, null, -1);
        max_depth = -1;
        foreach(var kvp in depth)
            max_depth = Math.Max(max_depth, kvp.Value);

        return answer(root);
    }

    public void dfs(TreeNode node, TreeNode parent, int f) {
        if (node != null) {
            depth.Add(node, f + 1);
            dfs(node.left, node, f + 1);
            dfs(node.right, node, f + 1);
        }
    }

    public TreeNode answer(TreeNode node) {
        if (node == null || depth[node] == max_depth)
            return node;
        TreeNode L = answer(node.left),
                 R = answer(node.right);
        if (L != null && R != null) return node;
        if (L != null) return L;
        if (R != null) return R;
        return null;
    }
}
