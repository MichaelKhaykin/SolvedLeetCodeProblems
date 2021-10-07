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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
    
        int carry = 0;
        ListNode v = new ListNode();
        ListNode k = v;
        
        ListNode m1 = l1;
        ListNode m2 = l2;
        
        while(m1 != null || m2 != null)
        {
            int x = (m1 == null) ? 0 : m1.val;
            int y = (m2 == null) ? 0 : m2.val;
           
            int sum = x + y + carry;
            k.next = new ListNode(sum % 10);
            carry = sum / 10;
            
            k = k.next;
            if(m1 != null) m1 = m1.next;
            if(m2 != null) m2 = m2.next;
        }
        if(carry > 0)
        {
            k.next = new ListNode(carry);
        }
        
        return v.next;
    }
}
