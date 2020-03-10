<Query Kind="Program" />

void Main()
{
	int[] nums = {1,3,-1,-3,5,3,6,7};
	int k = 3;
	
	(new Solution()).MaxSlidingWindow(nums, k).Dump();
}

public class Solution {
	
	public int[] MaxSlidingWindow(int[] nums, int k) {
        
        List<int> result = new List<int>();
        
        if(nums == null || nums.Length == 0)
			return result.ToArray();
		
		
		BinarySearchTree binTree = new BinarySearchTree();
		
		int i,j;
		
		// build bin try
		i=0;
		j=k-1;
		for (int l = i; l <= j; l++)
		{
			binTree.insert(nums[l]);
		}
		result.Add(binTree.GetMax());
		
		for (i = 1; j<nums.Length-1; i++)
		{
			j++;
			
			int toDelete = nums[i-1];
			int toAdd = nums[j];
			
			binTree.insert(toAdd);
			binTree.delete(toDelete);
			
			result.Add(binTree.GetMax());
		}
		return result.ToArray();
    }
	
	
	
	
	public class BinarySearchTree
	{

		public class Node
		{
			public int data;
			public Node left;
			public Node right;
			public Node(int data)
			{
				this.data = data;
				left = null;
				right = null;
			}
		}
	
		public Node root = null;
		public BinarySearchTree()
		{
			this.root = null;
		}
		
		public int GetMax()
		{
			if(root == null)
				return 0;
			
			Node cursor = null;
			cursor = root;
			while(cursor != null)
			{
				if(cursor.right !=null)
					cursor = cursor.right;
				else
					break;
			}
			
			return cursor.data;
		}
	
		public bool find(int id)
		{
			Node current = root;
			while (current != null)
			{
				if (current.data == id)
				{
					return true;
				}
				else if (current.data > id)
				{
					current = current.left;
				}
				else
				{
					current = current.right;
				}
			}
			return false;
		}
		public bool delete(int id)
		{
			Node parent = root;
			Node current = root;
			bool isLeftChild = false;
			while (current.data != id)
			{
				parent = current;
				if (current.data > id)
				{
					isLeftChild = true;
					current = current.left;
				}
				else
				{
					isLeftChild = false;
					current = current.right;
				}
				if (current == null)
				{
					return false;
				}
			}
			//if i am here that means we have found the node
			//Case 1: if node to be deleted has no children
			if (current.left == null && current.right == null)
			{
				if (current == root)
				{
					root = null;
				}
				if (isLeftChild == true)
				{
					parent.left = null;
				}
				else
				{
					parent.right = null;
				}
			}
			//Case 2 : if node to be deleted has only one child
			else if (current.right == null)
			{
				if (current == root)
				{
					root = current.left;
				}
				else if (isLeftChild)
				{
					parent.left = current.left;
				}
				else
				{
					parent.right = current.left;
				}
			}
			else if (current.left == null)
			{
				if (current == root)
				{
					root = current.right;
				}
				else if (isLeftChild)
				{
					parent.left = current.right;
				}
				else
				{
					parent.right = current.right;
				}
			}
			else if (current.left != null && current.right != null)
			{
	
				//now we have found the minimum element in the right sub tree
				Node successor = getSuccessor(current);
				if (current == root)
				{
					root = successor;
				}
				else if (isLeftChild)
				{
					parent.left = successor;
				}
				else
				{
					parent.right = successor;
				}
				successor.left = current.left;
			}
			return true;
		}
	
		public Node getSuccessor(Node deleleNode)
		{
			Node successsor = null;
			Node successsorParent = null;
			Node current = deleleNode.right;
			while (current != null)
			{
				successsorParent = successsor;
				successsor = current;
				current = current.left;
			}
			//check if successor has the right child, it cannot have left child for sure
			// if it does have the right child, add it to the left of successorParent.
			//		successsorParent
			if (successsor != deleleNode.right)
			{
				successsorParent.left = successsor.right;
				successsor.right = deleleNode.right;
			}
			return successsor;
		}
		public void insert(int id)
		{
			Node newNode = new Node(id);
			if (root == null)
			{
				root = newNode;
				return;
			}
			Node current = root;
			Node parent = null;
			while (true)
			{
				parent = current;
				if (id < current.data)
				{
					current = current.left;
					if (current == null)
					{
						parent.left = newNode;
						return;
					}
				}
				else
				{
					current = current.right;
					if (current == null)
					{
						parent.right = newNode;
						return;
					}
				}
			}
		}
		public void display(Node root)
		{
			if (root != null)
			{
				display(root.left);
				Console.Write(" " + root.data);
				display(root.right);
			}
		}
	
	}
}
