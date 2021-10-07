/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode aMover = headA;
        ListNode bMover = headB;
        
        HashSet<ListNode> seen = new HashSet<ListNode>();
        
        while(aMover != null)
        {
            seen.Add(aMover);
            aMover = aMover.next;
        }
        
        while(bMover != null)
        {
            if(!seen.Add(bMover)) return bMover;
            bMover = bMover.next;
        }
        return null;
    }
}
