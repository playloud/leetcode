<Query Kind="Program" />

//155.Min Stack
//https://leetcode.com/problems/min-stack/
/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
getMin() -- Retrieve the minimum element in the stack.
*/
// PSH 02/19/20 : Not a good solution but working
void Main()
{
	
}

// Define other methods and classes here
public class MinStack {
	
	List<int> list = null;
	Stack<int> stack = null;

    public MinStack() 
	{
        list = new List<int>();
		stack = new Stack<int>();
    }
    
    public void Push(int x) 
	{
        list.Add(x);
		stack.Push(x);
		list.Sort();
    }
    
    public void Pop() 
	{
        int popped = stack.Pop();
		list.Remove(popped);
    }
    
    public int Top() 
	{
		return stack.Peek();
    }
    
    public int GetMin() 
	{
        return list.ElementAt(0);
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */