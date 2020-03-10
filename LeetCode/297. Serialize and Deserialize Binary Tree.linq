<Query Kind="Program" />

void Main()
{

	TreeNode root = new TreeNode(10);
	root.left = new TreeNode(12);
	root.right = new TreeNode(23);
	root.right.left = new TreeNode(7);
	root.right.right = new TreeNode(15);
	root.right.right.left = new TreeNode(2);
	root.right.right.right = new TreeNode(9);
	
	root.Dump();
	string encrypted = (new Codec()).serialize(root);
	encrypted.Dump();
	
	(new Codec()).deserialize(encrypted).Dump();
	
}

// Define other methods and classes here
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
 
public class Codec
{

	// Encodes a tree to a single string.
	public string serialize(TreeNode root)
	{
		Queue<TreeNode> q = new Queue<TreeNode>();
		Dictionary<int, string> dic = new Dictionary<int, string>();
		
		int i=0;
		if(root != null)
		{
			q.Enqueue(root);
			dic.Add(0,root.val.ToString());
		}
		
		while(q.Count > 0)
		{
			TreeNode n = q.Dequeue();
			if(n != null)
			{
				dic.Add(i * 2 +1, n.left!=null ? n.left.val.ToString():"NULL");
				q.Enqueue(n.left);
				
				dic.Add(i * 2 + 2, n.right!=null ? n.right.val.ToString():"NULL");
				q.Enqueue(n.right);
			}
			i++;
		}

		string[] strArr = null;
		if (dic.Keys.Count > 0)
			strArr = new string[dic.Keys.Max() + 1];
		else
			return "[]";
			
		foreach (int key in dic.Keys)
			strArr[key] = dic[key];
		for (int j = 0; j < strArr.Length; j++)
		{
			if(strArr[j] == null)
				strArr[j] = "NULL";
		}
		string result = string.Join("," ,strArr);
		return string.Format("[{0}]", result);
	}

	// Decodes your encoded data to tree.
	public TreeNode deserialize(string data)
	{
		// make data to array
		char[] param = {','};
		string[] arr = data.Remove(data.Length-1, 1).Remove(0, 1).Split(param).ToArray();
		
		// first root
		TreeNode root = new TreeNode(0);
		Queue<TreeNode> q = new Queue<TreeNode>();
		q.Enqueue(root);
		int temp = 0;
		
		if(arr[0] != "NULL" && int.TryParse(arr[0], out temp))
		{
			root.val = int.Parse(arr[0]);
		}
		else
		{
			return null;
		}
		
		// main loop : taking nodes
		for (int i = 0; i < arr.Length; i++)
		{
			if (q.Count > 0)
			{
				TreeNode n = q.Dequeue();
				if(n != null)
				{
					// left
					if((2*i) + 1 < arr.Length)
					{
						string leftVal = arr[2*i +1];	
						if(leftVal != "NULL")
						{
							n.left = new TreeNode(int.Parse(leftVal));
						}
						
					}
					else 
					{
						n.left = null;
					}
					q.Enqueue(n.left);
	
					// right
					if (2 * i + 2 < arr.Length)
					{
						string rightVal = arr[2 * i + 2];
						if (rightVal != "NULL")
						{
							n.right = new TreeNode(int.Parse(rightVal));
						}
						
					}
					else
					{
						n.right = null;
					}
					q.Enqueue(n.right);
				}
			}
		}
		
		return root;
	}
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));