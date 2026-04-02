public class Solution {
    private List<(int r, int c)> directions = [(1,0), (0,1), (-1,0), (0,-1)];
    public int MaxAreaOfIsland(int[][] grid) {
        var max = 0;
        HashSet<(int r, int c)> visited = new();
        for(int r = 0; r < grid.Length; r++)
        {
            for(int c = 0; c < grid[0].Length; c++)
            {
                if(grid[r][c] == 1)
                    max = Math.Max(max, Bfs(r, c, grid, visited));
            }
        }
        return max;
    }

    private int Bfs(int r, int c, int[][] grid, HashSet<(int r, int c)> visited)
    {
        var key = (r,c);
        var result = 0;
        if(visited.Contains(key))
            return result;
        
        var queue = new Queue<(int r, int c)>();
        queue.Enqueue(key);

        while(queue.Count > 0)
        {
            var (currR, currC) = queue.Dequeue();
            if(visited.Contains((currR, currC)))
                continue;
            ++result;
            visited.Add((currR, currC));
            
            foreach(var (dr, dc) in directions)
            {
                var nr = currR + dr;
                var nc = currC + dc;
                if(nr < 0 || nc < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == 0)
                    continue;
                queue.Enqueue((nr, nc));
            }
        }
        return result;
    }
}
