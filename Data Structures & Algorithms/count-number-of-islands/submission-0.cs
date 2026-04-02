public class Solution {
    private const char ONE = '1';
    private const char ZERO = '0';
    private readonly List<(int r, int c)> directions = [(0,1), (1,0), (0,-1), (-1,0)];
    public int NumIslands(char[][] grid) 
    {
        var visited = new HashSet<(int r, int c)>();
        var result = 0;
        for(int r = 0; r < grid.Length; r++)
        {
            for(int c = 0; c < grid[0].Length; c++)
            {
                if(grid[r][c] == ONE)
                    if(Bfs(r, c, grid, visited))
                        ++result;
            }
        }
        return result;
    }

    public bool Bfs(int r, int c, char[][] grid, HashSet<(int r, int c)> visited)
    {
        var key = (r,c);
        if(visited.Contains(key))
            return false;
        
        var queue = new Queue<(int r, int c)>();
        queue.Enqueue(key);

        while(queue.Count > 0)
        {
            var (curR, curC) = queue.Dequeue();
            if(visited.Contains((curR, curC)))
                continue;
            visited.Add((curR, curC));

            foreach(var (dR, dC) in directions)
            {
                var nr = curR + dR;
                var nc = curC + dC;

                if(nr < 0 || nc < 0 || nr >= grid.Length || nc >= grid[0].Length || grid[nr][nc] == ZERO)
                    continue;
                queue.Enqueue((nr, nc));
            }
        }
        return true;
    }
}
