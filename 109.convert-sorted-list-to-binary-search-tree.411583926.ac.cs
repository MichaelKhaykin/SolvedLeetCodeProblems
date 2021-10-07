/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    
    public TreeNode BuildTreeFromArray(List<int> vals, int low, int high)
        {
            if (high < low) return null;

            var index = (high + low)/ 2;
            int mid = vals[index];

            TreeNode root = new TreeNode(mid)
            {
                left = BuildTreeFromArray(vals, low, index - 1),
                right = BuildTreeFromArray(vals, index + 1, high)
            };

            return root;
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;

            List<int> vals = new List<int>();
            while (head != null)
            {
                vals.Add(head.val);
                head = head.next;
            }

            return BuildTreeFromArray(vals, 0, vals.Count - 1);
        }
}
