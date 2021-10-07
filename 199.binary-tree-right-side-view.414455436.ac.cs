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
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();

        if (root == null) {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var size = queue.Count;

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (i == size - 1) {
                    result.Add(cur.val);
                }

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }

                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
        }

        return result;
    }
}
