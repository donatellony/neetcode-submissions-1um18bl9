public class Solution {
    private List<(int, int)> directions = [ (0, 1), (1, 0), (0, -1), (-1, 0) ];
    public int MinimumEffortPath(int[][] heights) 
    {
        var visited = new HashSet<(int r, int c)>();
        var pq = new PriorityQueue<(int r, int c, int effort), int>();
        pq.Enqueue((0, 0, 0), -1);
        while(pq.Count > 0)
        {
            var (r, c, effort) = pq.Dequeue();
            if(r == heights.Length - 1 && c == heights[0].Length - 1)
                return effort;

            if (visited.Contains((r, c))) 
                continue;
            
            visited.Add((r, c));
            foreach(var (dr, dc) in directions)
            {
                var nr = r + dr;
                var nc = c + dc;
                if(visited.Contains((nr, nc)) || nr < 0 || nc < 0 || nr >= heights.Length || nc >= heights[0].Length)
                    continue;

                int edgeEffort = Math.Abs(heights[r][c] - heights[nr][nc]);
                int newEffort = Math.Max(effort, edgeEffort);

                pq.Enqueue((nr, nc, newEffort), newEffort);
            }
        }

        return -1;
    }
}