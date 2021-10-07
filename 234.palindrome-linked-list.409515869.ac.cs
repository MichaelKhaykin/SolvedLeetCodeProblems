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
public class Solution {
    public bool IsPalindrome(ListNode head) {
        List<ListNode> nodes = new List<ListNode>();
        while(head != null)
        {
            nodes.Add(head);
            head = head.next;
        }
        
        for(int i = 0; i < nodes.Count / 2; i++)
        {
            if(nodes[i].val != nodes[nodes.Count - i - 1].val) return false;
        }
        return true;
    }
}
