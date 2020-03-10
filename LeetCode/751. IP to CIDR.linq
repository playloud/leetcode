<Query Kind="Program" />

void Main()
{
	(new Solution()).intToBinStr(234).Dump();
	(new Solution()).IpToBin("234.1.1.312").Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> IpToCIDR(string ip, int range)
	{
		//
		
		
		return null;
	}
	
	public string IpToBin(string ip)
	{
		var sbuf = new StringBuilder();
		char[] sepa = {'.'};
		string[] elements = ip.Split(sepa);
		elements.ToList().ForEach(a=> sbuf.Append(intToBinStr(int.Parse(a))+" "));
		return sbuf.ToString().Trim();
	}
	
	public string intToBinStr(int n)
	{
		return string.Format("{0,8}", Convert.ToString(n,2)).Replace(" ","0");
	}
}