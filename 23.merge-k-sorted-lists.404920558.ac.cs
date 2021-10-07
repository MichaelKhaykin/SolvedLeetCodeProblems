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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode[] currents = new ListNode[lists.Length];
        for(int i = 0; i < lists.Length; i++)
        {
            currents[i] = lists[i];   
        }
        
        ListNode mover = new ListNode(-100);
        ListNode original = mover;
        
        //choose best
        bool keepGoing = true;
        while(keepGoing)
        {
            keepGoing = false;
            ListNode min = new ListNode(int.MaxValue);
            int index = 0;
            for(int i = 0; i < currents.Length; i++)
            {
                if(currents[i] == null) continue;
                
                if(currents[i].val < min.val)
                {
                    min = currents[i];
                    index = i;
                }
                
                keepGoing = true;
            }
            
            if(!keepGoing) break;
            
            mover.next = min;
            mover = mover.next;
            
            currents[index] = currents[index].next;
        }
        
        return original.next;
    }
}
