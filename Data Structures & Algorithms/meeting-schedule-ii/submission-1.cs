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
        // Start -> End
        var pq = new PriorityQueue<int, int>();
        int maxCounter = 0;
        foreach(var i in intervals)
        { 
            while(pq.TryPeek(out var element, out var currEnd) && i.start >= currEnd)
            {
                pq.Dequeue();
            }
            pq.Enqueue(i.start, i.end);
            maxCounter = Math.Max(maxCounter, pq.Count);
        }
        return maxCounter;
    }
}
