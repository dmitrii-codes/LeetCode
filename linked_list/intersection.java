// Write a program to find the node at which the intersection of two singly linked lists begins.
// For example, the following two linked lists:
// A:          a1 → a2
//                    ↘
//                      c1 → c2 → c3
//                    ↗            
// B:     b1 → b2 → b3
// begin to intersect at node c1.

// Notes:
//     If the two linked lists have no intersection at all, return null.
//     The linked lists must retain their original structure after the function returns.
//     You may assume there are no cycles anywhere in the entire linked structure.
//     Your code should preferably run in O(n) time and use only O(1) memory.



 public class ListNode {
     int val;
     ListNode next;
     ListNode(int x) {
         val = x;
         next = null;
     }
 }
public class Solution {
    public ListNode getIntersectionNode(ListNode headA, ListNode headB) {
        int lengthA = 0;
        int lengthB = 0;
        ListNode p1 = headA;
        ListNode p2 = headB;
        while (p1!=null){
            lengthA++;
            p1 = p1.next;
        }
        while (p2!=null){
            lengthB++;
            p2 = p2.next;
        }
        p1 = headA; 
        p2 = headB;
        if (lengthA > lengthB){
            for (int i = 0; i < lengthA - lengthB; i++){
                p1 = p1.next;
            }
        }
        else if (lengthA < lengthB){
            for (int i = 0; i < lengthB - lengthA; i++){
                p2 = p2.next;
            }
        }
        while(p1!=null && p2!=null){
            if (p1 == p2){
                return p1;
            }
            p1 = p1.next;
            p2 = p2.next;
        }
        return null;
    }
}