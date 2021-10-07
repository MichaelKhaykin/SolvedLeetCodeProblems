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
    public ListNode DeleteDuplicates(ListNode head) {
        
        if(head == null || head.next == null) return head;
        
        ListNode x = new ListNode(head.val);
        ListNode original = x;
        
        ListNode mover = head;
        ListNode previous = head;
        
        while(mover != null)
        {
            if(mover.val != x.val)
            {
                x.next = new ListNode(mover.val);
                x = x.next;
            }
            previous = mover;
            mover = mover.next;
        }
        if(x.val != previous.val)
        {
            x.next = new ListNode(previous.val);
        }
        return original;
    }
}
