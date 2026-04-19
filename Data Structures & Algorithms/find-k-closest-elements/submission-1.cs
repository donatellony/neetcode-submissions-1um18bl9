public class Solution {
    public List<int> FindClosestElements(int[] arr, int k, int x) 
    {
        if(arr.Length == k)
            return arr.ToList();

        List<int> result = [];

        // MaxQueue, Priority will be negative
        PriorityQueue<int, int> pq = new();

        foreach(var num in arr)
        {
            var numPrio = Math.Abs(x - num);

            if(pq.Count == k && pq.TryPeek(out var elem, out var prio))
            {
                // In a Max-Heap, we replace the top if the current num is better than the worst element
                // Tie-breaker: if distances are equal, num is only better if num < elem
                // -4 => 4
                prio = -prio;
                if((numPrio < prio) || (numPrio == prio && num < elem))
                {
                    pq.Dequeue();
                    pq.Enqueue(num, -numPrio);
                }
                continue;
            }
            pq.Enqueue(num, -numPrio);
        }
        while(pq.Count > 0)
            result.Add(pq.Dequeue());
        
        result.Sort();
        return result;
    }
}