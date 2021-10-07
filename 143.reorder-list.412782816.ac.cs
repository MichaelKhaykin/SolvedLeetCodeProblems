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
    public void ReorderList(ListNode head)
    {
        if(head == null || head.next == null) return;
        
        var curr = head;
        Stack<ListNode> nodes = new Stack<ListNode>();
        List<ListNode> reference = new List<ListNode>();
        while (curr != null)
        {
            nodes.Push(curr);
            reference.Add(curr);
            curr = curr.next;
        }

        foreach(var item in reference)
        {
            item.next = null;
        }

        int top = 0;
        while(nodes.Peek() != reference[top])
        {
            var popped = nodes.Pop();
            reference[top].next = popped;
            if (reference[top + 1] == popped) return;
            popped.next = reference[top + 1];
            top++;
        }
    }
}
