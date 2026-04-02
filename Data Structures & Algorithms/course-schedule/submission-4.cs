public class Solution {
    private List<List<int>> adj;
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        adj = new List<List<int>>(numCourses);
        for(int i = 0; i < numCourses; i++)
        {
            adj.Add(new());
        }
        foreach(var prereq in prerequisites)
        {
            adj[prereq[0]].Add(prereq[1]);
        }

        HashSet<int> visited = new();
        HashSet<int> path = new();
        for(int i = 0; i < adj.Count; i++)
        {
            if(!Dfs(i, path, visited))
                return false;
        }
        return true;
    }

    private bool Dfs(int i, HashSet<int> path, HashSet<int> visited)
    {
        if(path.Contains(i))
            return false; // Cycle dedected.
        if(visited.Contains(i))
            return true;
        
        path.Add(i);
        var neighbours = adj[i];
        foreach(var neighbour in neighbours)
        {
            if(!Dfs(neighbour, path, visited))
                return false;
        }
        path.Remove(i);
        visited.Add(i);
        return true;
    }
}