<Query Kind="Program" />

void Main()
{
	ListNode root = new ListNode(1);
//	root.next = new ListNode(11);
//	root.next.next = new ListNode(22);
//	root.next.next.next = new ListNode(33);
//	root.next.next.next.next = new ListNode(44);
//	root.next.next.next.next.next = new ListNode(55);
//	root.next.next.next.next.next.next = new ListNode(66);
	
	
	(new Solution()).ReverseList(root).Dump();
}

// Define other methods and classes here
// Definition for singly-linked list.
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
 
public class Solution {
    public ListNode ReverseList(ListNode head) {
		
		ListNode tail = null;
    	ListNode cursor = null;
		ListNode last = null;
		Stack<ListNode> stack = new Stack<ListNode>();
	
		cursor = head;
		
		while(cursor != null)
		{
			stack.Push(cursor);
			last = cursor;
			cursor = cursor.next;
		}
		
		tail = last;
		cursor = last;
		while(stack.Count > 0)
		{
			cursor.next = stack.Pop();
			cursor = cursor.next;
		}
		
		return tail;
    }
}