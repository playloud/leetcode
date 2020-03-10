<Query Kind="Program" />

void Main()
{
	ListNode head = new ListNode(1);
//	head.next = new ListNode(2);
//	head.next.next = new ListNode(3);
//	head.next.next.next = new ListNode(4);
//	head.next.next.next.next = new ListNode(5);
	//head.next.next.next.next.next = new ListNode(6);
	
	Solution sol = new Solution();
	sol.RemoveNthFromEnd(head, 1).Dump();
	
}

// Define other methods and classes here
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public class Solution
{
	
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		Hashtable htChildParent = new Hashtable();
		List<ListNode> nodes = new List<ListNode>();
		
		ListNode iter = null;
		iter = head;
		int index = 0;
		
		while(iter != null)
		{
			// save to list 
			nodes.Add(iter);
			
			// save child-parent
			if(iter.next != null)
				htChildParent.Add(iter.next, iter);
			
			iter = iter.next;
		}
		
		ListNode toDelete = nodes[nodes.Count - n];
		ListNode parent = (ListNode)htChildParent[toDelete];
		
		if(parent != null)
			parent.next = toDelete.next;
		
		if(toDelete == head)
			head = toDelete.next;
		
		return head;
	}
}