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
    public ListNode InsertionSortList(ListNode head) {
        if (head == null || head.next == null) return head;
        
        ListNode newHead = new ListNode();
        
        ListNode previous = null;
        ListNode nextNode = null;
        var current = head;
        
        while(current != null)
        {
            previous = newHead;
            nextNode = newHead.next;
            
            while(nextNode != null)
            {
                if(nextNode.val > current.val)
                    break;
                
                nextNode = nextNode.next;
                previous = previous.next;
            }
            
            var old = current.next;
            
            current.next = nextNode;
            previous.next = current;
            current = old;
        }
        
        return newHead.next;
    }
}
