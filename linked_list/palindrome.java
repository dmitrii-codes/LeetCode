// Given a singly linked list, determine if it is a palindrome.
// Example 1:
// Input: 1->2
// Output: false
// Example 2:
// Input: 1->2->2->1
// Output: true

public class ListNode {
    int val;
    ListNode next;
    ListNode(int x) { val = x; }
}

class Solution {
    public boolean isPalindrome(ListNode head) {
        if (head == null || head.next == null)
            return true;
        ArrayList<Integer> firstHalf = new ArrayList<Integer>();     
        int len = Solution.getLength(head);
        int queuePointer = len/2;
        ListNode pointer = head;
        for (int i = 0; i < len/2; i++){
            firstHalf.add(pointer.val);
            pointer = pointer.next;
        }
        if ( len % 2 != 0 ){
            pointer = pointer.next;
        }
        while (pointer != null){
            if (pointer.val != firstHalf.get(--queuePointer)){
                return false;
            }
            pointer = pointer.next;
        }
        return true;
    }
    
    public static int getLength(ListNode head){
        ListNode pointer = head;
        int result = 0;
        while (pointer != null){
            pointer = pointer.next;
            result++;
        }
        return result;
    }
}