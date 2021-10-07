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
     public int[] NextLargerNodes(ListNode head)
     {
              if (head == null) return new int[] { };

        var temp = head;

        Dictionary<ListNode, int> map = new Dictionary<ListNode, int>();

        int index = 0;
        while(temp != null)
        {
            map.Add(temp, index++);
            temp = temp.next;
        }

        int[] returnVals = new int[index];

        Stack<ListNode> current = new Stack<ListNode>();

        while (head != null)
        {
            while(current.Count > 0 && current.Peek().val < head.val)
            {
                returnVals[map[current.Pop()]] = head.val;
            }

            current.Push(head);
            head = head.next;
        }


        return returnVals;
}
}
