public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var prereqs = new Dictionary<int, List<int>>();

        foreach (var p in prerequisites)
        {
            if (!prereqs.ContainsKey(p[0]))
                prereqs[p[0]] = new List<int>();

            prereqs[p[0]].Add(p[1]);
        }

        var visiting = new HashSet<int>();
        var visited  = new HashSet<int>();

        foreach (var course in prereqs.Keys)
        {
            if (!Dfs(course, prereqs, visiting, visited))
                return false;
        }

        return true;
    }

    private bool Dfs(
        int course,
        Dictionary<int, List<int>> prereqs,
        HashSet<int> visiting,
        HashSet<int> visited)
    {
        if (visiting.Contains(course))
            return false;

        if (visited.Contains(course))
            return true;

        visiting.Add(course);

        if (prereqs.TryGetValue(course, out var deps))
        {
            foreach (var dep in deps)
            {
                if (!Dfs(dep, prereqs, visiting, visited))
                    return false;
            }
        }

        visiting.Remove(course);
        visited.Add(course);

        return true;
    }
}
