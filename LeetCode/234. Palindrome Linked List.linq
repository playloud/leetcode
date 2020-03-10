<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
public class Solution
{
	public bool IsPalindrome(ListNode head)
	{
		Stack<ListNode> stack = new Stack<ListNode>();
		Queue<ListNode> queue = new Queue<ListNode>();
		
		ListNode cursor = null;
		cursor = head;
		while(cursor != null)
		{
			stack.Push(cursor);
			queue.Enqueue(cursor);
			cursor = cursor.next;
		}
		
		for (int i = 0; i < stack.Count; i++)
		{
			ListNode node1 = stack.Pop();
			ListNode node2 = queue.Dequeue();
			
			if(node1.val != node2.val)
				return false;
		}
		
		return true;
	}
}