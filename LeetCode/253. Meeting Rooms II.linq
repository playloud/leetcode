<Query Kind="Program" />

//253. Meeting Rooms II
//https://leetcode.com/problems/meeting-rooms-ii/
/*
It is a funny question. 
Orderby.ThenBy caused timeoutException
therefore, sort given data first, then find first nearest schedule -> it works
Duration -> is not used. canbe removed. 
REMEMBER how to init jagged array
*/
void Main()
{
//	int[][] input = new int[3][];
//	input[0] = new int[] {0, 30};
//	input[1] = new int[] {5, 10};
//	input[2] = new int[] {15, 20};

	int[][] input = new int[5][];
	input[0] = new int[] { 26,29 };
	input[1] = new int[] { 19,26};
	input[2] = new int[] { 19,28 };
	input[3] = new int[] { 4,19 };
	input[4] = new int[] { 4,25 };

	(new Solution()).MinMeetingRooms(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MinMeetingRooms(int[][] intervals)
	{
		List<Meeting> meetings = new List<Meeting>();
		List<Room> rooms = new List<Room>();
		
		for (int i = 0; i < intervals.Length; i++)
		{
			meetings.Add(new Meeting(intervals[i][0], intervals[i][1])); 
		}
		
		meetings = meetings.OrderBy(a=> a.Start).ToList();
		
		while(meetings.Count > 0) 
		{
			var firstMeeting = meetings.OrderBy(a=> a.Start).FirstOrDefault();
			
			if(firstMeeting != null) 
			{
				Room room = new Room();
				room.meetingList.Add(firstMeeting);
				meetings.Remove(firstMeeting);
				
				Meeting curMeeting = firstMeeting;
				while(true)
				{
					// find next meeting
					//var queryNextMeeting = meetings.Where(a=> curMeeting.End <= a.Start).OrderBy(a=> a.Start).ThenBy(a=>a.Duration);
					var queryNextMeeting = meetings.FirstOrDefault(a=> curMeeting.End <= a.Start);
					if(queryNextMeeting != null) 
					{
						Meeting foundMeeting = queryNextMeeting;
						room.meetingList.Add(foundMeeting);
						curMeeting = foundMeeting;
						meetings.Remove(curMeeting);
					} 
					else
					{
						break;
					}
					
				}
				rooms.Add(room);
			}
		}
		//rooms.Dump();
		return rooms.Count;
	}
}

class Room 
{
	public List<Meeting> meetingList { get; set; }
	
	public Room() 
	{
		this.meetingList = new List<Meeting>();
	}
}

class Meeting
{
	public int Start { get; set; }
	public int End { get; set; }
	public int Duration { get; set; }

	public Meeting(int start, int end) 
	{
		this.Start = start;
		this.End = end;
		this.Duration = (end-start);
		
	}
}
