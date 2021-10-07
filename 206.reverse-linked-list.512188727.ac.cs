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
    public ListNode ReverseList(ListNode head) {
     
        if(head == null) return null;
        
        ListNode prior = null;
        ListNode curr = head;
        while(curr != null){
            var next = curr.next;
            
            curr.next = prior;
            prior = curr;
            
            if(next == null){
                head = curr;
            }
            curr = next;
        }
        
        return head;
    }
}
