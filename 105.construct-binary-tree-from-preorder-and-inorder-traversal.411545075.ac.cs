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
    
        public int current = 0;
    
       public TreeNode Build(int[] preOrder, int[] inOrder)
        {
            if (inOrder.Length == 0) return null;

            int inOrderIndex = -1;
          
            for (int j = 0; j < inOrder.Length; j++)
            {
                if (preOrder[current] == inOrder[j])
                {
                    inOrderIndex = j;
                    break;
                }
            }


            var root = new TreeNode(preOrder[current]);
            current++;
           
            var leftInOrder = new int[inOrderIndex];

            for (int i = 0; i < inOrderIndex; i++)
            {
                leftInOrder[i] = inOrder[i];
            }
            root.left = Build(preOrder, leftInOrder);

            var rightInorder = new int[inOrder.Length - inOrderIndex - 1];
            for (int i = inOrderIndex + 1; i < inOrder.Length; i++)
            {
                rightInorder[i - inOrderIndex - 1] = inOrder[i];
            }

            root.right = Build(preOrder, rightInorder);

            return root;
        }
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return Build(preorder, inorder);
    }
}
