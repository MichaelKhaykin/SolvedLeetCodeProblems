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
    int current = 0;

        public TreeNode Build2(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0) return null;
            if (inorder.Length == 1)
            {
                current++;
                return new TreeNode(inorder[0]);
            }

            int index = -1;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (postorder[current] == inorder[i])
                {
                    index = i;
                    break;
                }
            }

            var root = new TreeNode(inorder[index]);
            current++;


            var rightSide = new int[inorder.Length - index - 1];
            for (int i = index + 1; i < inorder.Length; i++)
            {
                rightSide[i - (index + 1)] = inorder[i];
            }
            root.right = Build2(rightSide, postorder);

            var leftSide = new int[index];
            for (int i = 0; i < index; i++)
            {
                leftSide[i] = inorder[i];
            }
            root.left = Build2(leftSide, postorder);

            return root;
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {

            int[] newPostOrder = new int[postorder.Length];
            int curr = 0;
            for (int i = postorder.Length - 1; i >= 0; i--)
            {
                newPostOrder[curr] = postorder[i];
                curr++;
            }

            return Build2(inorder, newPostOrder);
        }
}
