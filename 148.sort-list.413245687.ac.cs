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
       public ListNode MergeSort(ListNode head)
        {
            static int CountNodes(ListNode head)
            {
                int count = 0;
                while (head != null)
                {
                    count++;
                    head = head.next;
                }
                return count;
            }

            if (head.next == null) return head;
            if (head.next.next == null)
            {
                //2 node case
                ListNode newNode = new ListNode(-1);
                if (head.next.val < head.val)
                {
                    newNode.val = head.next.val;
                    newNode.next = new ListNode(head.val);
                }
                else
                {
                    newNode.val = head.val;
                    newNode.next = new ListNode(head.next.val);
                }
                return newNode;
            }

            int number = CountNodes(head);

            int seperateCounter = 0;
            ListNode current = head;
            ListNode og = current;
            while (seperateCounter < number / 2)
            {
                current = current.next;
                seperateCounter++;
            }
            var restartPlace = current.next;
            current.next = null;

            ListNode l = MergeSort(og);
            ListNode r = MergeSort(restartPlace);

            ListNode big = new ListNode(-1);
            var lol = big;
            while(l != null || r != null)
            {
                if(l == null)
                {
                    big.next = r;
                    r = r.next;
                    big = big.next;
                    continue;
                }
                else if(r == null)
                {
                    big.next = l;
                    l = l.next;
                    big = big.next;
                    continue;
                }

                if (l.val < r.val)
                {
                    big.next = l;
                    l = l.next;
                }
                else
                {
                    big.next = r;
                    r = r.next;
                }
                big = big.next;
            }

            return lol.next;
        }


        public ListNode SortList(ListNode head)
        {

            if (head == null || head.next == null) return head;

            return MergeSort(head);
        }
}
