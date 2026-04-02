public class Solution {
    private readonly List<(int dr, int dc)> directions = [(0,1), (1,0), (0,-1), (-1,0)];
    public int IslandPerimeter(int[][] grid) {
        var visited = new HashSet<(int r, int c)>();
        var queue = new Queue<(int r, int c)>();
        var result = 0;
        for(int r = 0; r < grid.Length; r++)
        { 
            for(int c = 0; c < grid[0].Length; c++)
            {
                if(grid[r][c] == 1)
                {
                    queue.Enqueue((r,c));
                    visited.Add((r,c));
                    break;
                }
            }
            if(queue.Count > 0)
                break;
        }

        while(queue.Count > 0)
        {
            var (currR, currC) = queue.Dequeue();

            foreach(var (dr, dc) in directions)
            {
                var nr = currR + dr;
                var nc = currC + dc;
                if(nr < 0 || nc < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == 0)
                {
                    ++result;
                    continue;
                }
                if(visited.Contains((nr, nc)))
                {
                    continue;
                }
                queue.Enqueue((nr, nc));
                visited.Add((nr,nc));
            }
        }

        return result;
    }
}