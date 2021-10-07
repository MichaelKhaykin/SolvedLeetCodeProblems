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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        
        if(l1 == null && l2 == null) return null;
        if(l1 == null && l2 != null) return l2;
        if(l1 != null && l2 == null) return l1;
        
        
        ListNode newNode = l1.val < l2.val ? l1 : l2; 
        ListNode l1Mover = null;
        ListNode l2Mover = null;
        if(newNode == l1)
        {
            l1Mover = l1.next;
            l2Mover = l2;
        }
        else
        {
            l2Mover = l2.next;
            l1Mover = l1;
        }
        
        ListNode mover = newNode;
        while(l1Mover != null || l2Mover != null)
        {
            if(l1Mover != null && l2Mover != null)
            {
                mover.next = l1Mover.val < l2Mover.val ? l1Mover : l2Mover;
                mover = mover.next;
                
                if(l1Mover.val < l2Mover.val)
                {
                    l1Mover = l1Mover.next;
                }
                else
                {
                    l2Mover = l2Mover.next;
                }
            }
            else if(l1Mover == null && l2Mover != null)
            {
                mover.next = l2Mover;
                mover = mover.next;
                l2Mover = l2Mover.next;
            }
            else if(l1Mover != null && l2Mover == null)
            {
                mover.next = l1Mover;
                mover = mover.next;
                l1Mover = l1Mover.next;
            }
        }
        
        return newNode;
    }
}
