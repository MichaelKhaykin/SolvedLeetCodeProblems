/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        
        if(head == null) return false;
        if(head.next == null) return false;
        
        ListNode n = head;
        ListNode b = head.next;
        
        while(true)
        {
            if(n == b)
            {
                return true;
            }
            n = n.next;
            b = b.next?.next;
           
            if(n == null || b == null) return false;
        }
        
        return false;
    }
}
