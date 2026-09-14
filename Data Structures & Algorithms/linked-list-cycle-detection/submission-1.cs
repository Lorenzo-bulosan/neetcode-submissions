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
    public bool HasCycle(ListNode head) {

        if (head == null) return false;
        
        // init pointers, both start at same position but different speed traversal
        var slow = head;
        var fast = head;

        while(fast != null && fast.next != null){ // check ahead as it will error if fast is already null

            // traverse
            slow = slow.next;
            fast = fast.next.next;            

            // cycle detected when both pointers at same node
            if (slow == fast) return true;
        }

        return false;
    }
}
