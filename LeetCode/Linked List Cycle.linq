<Query Kind="Program" />

void Main()
{
	// passed
}

// Define other methods and classes here
public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int x) {
		val = x;
		next = null;
	}
}

public class Solution {
    public bool HasCycle(ListNode head) {
		HashSet<ListNode> set = new HashSet<ListNode>();
		
		ListNode cursor = null;
		cursor = head;
		while(cursor != null)
		{
			if(cursor.next != null && set.Contains(cursor.next))
				return true;
			
			set.Add(cursor);
			cursor = cursor.next;
		}
		return false;
    }
}