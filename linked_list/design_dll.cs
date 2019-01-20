// Design your implementation of the linked list. Assume all nodes in the linked list are 0-indexed.

// Implement these functions in your linked list class:

//     get(index) : Get the value of the index-th node in the linked list. If the index is invalid, return -1.
//     addAtHead(val) : Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
//     addAtTail(val) : Append a node of value val to the last element of the linked list.
//     addAtIndex(index, val) : Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted.
//     deleteAtIndex(index) : Delete the index-th node in the linked list, if the index is valid.

// Example:

// MyLinkedList linkedList = new MyLinkedList();
// linkedList.addAtHead(1);
// linkedList.addAtTail(3);
// linkedList.addAtIndex(1, 2);  // linked list becomes 1->2->3
// linkedList.get(1);            // returns 2
// linkedList.deleteAtIndex(1);  // now the linked list is 1->3
// linkedList.get(1);            // returns 3

// Note:

//     All values will be in the range of [1, 1000].
//     The number of operations will be in the range of [1, 1000].
//     Please do not use the built-in LinkedList library.

public class MyLinkedList {
    ListNode head;
    ListNode tail;
    int count;

    /** Initialize your data structure here. */
    public MyLinkedList() {
        head = new ListNode(0);
        tail = new ListNode(0);
        head.next = tail;
        tail.prev = head;
        count = 0;
    }

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        if (index < 0 || index >= count)
            return -1;
        ListNode temp = head.next;
        for (int i = 0; i < index; i++)
            temp = temp.next;
        return temp.val;
    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        ListNode node = new ListNode(val, head, head.next);
        head.next.prev = node;
        head.next = node;
        count++;
    }

    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        ListNode node = new ListNode(val, tail.prev, tail);
        tail.prev.next = node;
        tail.prev = node;
        count++;
    }

    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        if (index == 0)
            AddAtHead(val);
        else if (index == count)
            AddAtTail(val);
        else if (index < 0 || index > count)
            return;
        else {
            ListNode temp = head.next;
            for(int i = 0; i < index; ++i)
                temp = temp.next;
            ListNode node = new ListNode(val, temp.prev, temp);
            temp.prev.next = node;
            temp.prev = node;
            count++;
        }
    }

    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        if(index < 0 || index >= count)
            return;
        ListNode temp = head.next;
        for(int i = 0; i < index; ++i)
            temp = temp.next;
        temp.prev.next = temp.next;
        temp.next.prev = temp.prev;
        count--;
    }
}

public class ListNode{
    public int val;
    public ListNode prev;
    public ListNode next;

    public ListNode (int x) {
        this.val = x;
    }

    public ListNode (int x, ListNode p, ListNode n) {
        this.val = x;
        this.prev = p;
        this.next = n;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */