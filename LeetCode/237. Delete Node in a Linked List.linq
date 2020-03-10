<Query Kind="Program" />

//237. Delete Node in a Linked List
//PSH 02/01/20 23:41:41 Saturday
// this is bad question, head and what to nth is missing
void Main()
{
	
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
	public void DeleteNode(ListNode node)
	{
		ListNode n = node;
		ListNode toFind = null;
		
		Dictionary<ListNode, ListNode> dic = new Dictionary<ListNode, ListNode>();
		while(n.next != null) 
		{
			ListNode parent = n;
			ListNode child = n.next;
			n = n.next;
			dic.Add(child, parent);
			
			//if(
		}
		
		
		
		
		
	}
}