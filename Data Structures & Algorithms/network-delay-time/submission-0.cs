public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        // Key -> Source, Value -> (Target, Time)
        var relations = new Dictionary<int, List<(int, int)>>();
        // Key -> Source, Value -> MinTime
        var visited = new Dictionary<int, int>();

        foreach(var time in times)
        {
            if(!relations.ContainsKey(time[0]))
            {
                relations[time[0]] = new List<(int, int)>();
            }
            relations[time[0]].Add((time[1], time[2]));
        }

        // <int, int> -> <Element (Source), Priority (Time)>
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        while(pq.Count > 0)
        {
            pq.TryDequeue(out var currNodeElem, out var currNodePrio);
            if(visited.ContainsKey(currNodeElem))
                continue;
            visited[currNodeElem] = currNodePrio;

            if(!relations.ContainsKey(currNodeElem))
                continue;
            var currRels = relations[currNodeElem];
            foreach(var (currRelTarget, currRelTime) in currRels)
            {
                if(visited.ContainsKey(currRelTarget))
                {
                    continue;
                }
                pq.Enqueue(currRelTarget, currNodePrio + currRelTime);
            }
        }

        if(visited.Count != n)
            return -1;
        
        var sum = 0;
        foreach(var kv in visited)
        {
            sum = Math.Max(sum, kv.Value);
        }
        return sum;
    }
}
