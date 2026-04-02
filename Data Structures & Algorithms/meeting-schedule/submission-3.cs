/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */


/*

We can sort the intervals by the start time.
OR use a PriorityQueue

*/
public class Solution 
{
    public bool CanAttendMeetings(List<Interval> intervals) 
    {
        // End time -> Start time
        var pq = new PriorityQueue<int, int>();
        foreach(var interval in intervals)
        {
            pq.Enqueue(interval.end, interval.start);
        }
        int maxEnd = -1;
        while(pq.Count > 0)
        {
            pq.TryDequeue(out var end, out var start);
            if(start < maxEnd)
                return false;
            maxEnd = end;
        }
        return true;
    }
}
