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

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        intervals = intervals.OrderBy(x => x.start).ToList();
        var pq = new PriorityQueue<int, int>();
        foreach(var i in intervals)
        { 
            if(pq.TryPeek(out var _, out var end) && end <= i.start)
                pq.Dequeue();
            pq.Enqueue(i.end, i.end);
        }
        return pq.Count;
    }
}
