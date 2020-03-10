<Query Kind="Program" />

void Main()
{
	MyCalendar cal = new MyCalendar();
	cal.Book(37,50).Dump();
	cal.Book(33,50).Dump();
	cal.Book(4,17).Dump();
	cal.Book(35,48).Dump();
	cal.Book(8,25).Dump();
	
}

// Define other methods and classes here
public class MyCalendar {
	
	List<CEvent> eventList = new List<CEvent>();
	
    public MyCalendar() {
		
    }
    
    public bool Book(int start, int end) {
        if(eventList.Where(a=> a.IsDupEnd(end) || a.IsDupStart(start) || a.IsIncluded(start, end)).Any())
		{
			Console.WriteLine ("{0} {1}", start, end);
			eventList
			.Where(a=> a.IsDupEnd(end) || a.IsDupStart(start))
			.ToList()
			.ForEach(a=>Console.WriteLine ("{0}-{1}", a.Start, a.End));
			
			
			return false;
		}
		else
		{
			eventList.Add(new CEvent(){Start=start,End=end});
		}
		
		return true;
    }
	
	public class CEvent
	{
		public int Start { get; set; }
		public int End { get; set; }
		
		public bool IsDupStart(int otherStart)
		{
			if(Start <= otherStart && otherStart < End)
				return true;
			
			return false;
		}
		
		public bool IsDupEnd(int otherEnd)
		{
			if(Start < otherEnd && otherEnd < End)
				return true;
			
			return false;
		}
		
		public bool IsIncluded(int start, int end)
		{
			if(start<= this.Start && this.Start < end)
				return true;
			return false;
		}
		
		
		
	}
	
	
}
