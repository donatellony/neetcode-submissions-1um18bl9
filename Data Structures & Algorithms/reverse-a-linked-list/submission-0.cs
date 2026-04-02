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
        // [0,1,2,3]
        // 0.next -> 0
        // 0 -> null
        ListNode prev = null;
        ListNode curr = head;
        while(head != null)
        {
            curr = head;
            head = head.next;
            curr.next = prev;
            prev = curr;
        }
        return curr;
    }
}
