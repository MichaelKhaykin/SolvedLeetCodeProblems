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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        
        
        if(head == null) return null;
        
        
        if(left == 1)
        {
            head = ReverseLinkedList(head, right - 1);
            return head;
        }

        var findLeft = head;
        for(int i = 0; i < left - 2; i++){
            findLeft = findLeft.next;
        }
        
      
        findLeft.next = ReverseLinkedList(findLeft.next, right - left);
        
        return head;
    }
    
    public ListNode ReverseLinkedList(ListNode head, int end){

        if(head == null) return null;
        
        ListNode initialCur = head;
        
        ListNode prior = null;
        ListNode curr = head;
        for(int i = 0; i < end + 1; i++)
        {
            var next = curr.next;
            
            curr.next = prior;
            prior = curr;
            
            if(i == end){
                head = curr;
                initialCur.next = next;
                return head;
            }
            curr = next;
        }
        
        return head;
    }
}
