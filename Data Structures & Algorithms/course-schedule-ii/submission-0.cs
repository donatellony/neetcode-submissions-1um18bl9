public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        List<int> result = new();
        HashSet<int> path = new();
        // Index is src, value - prereqs
        List<List<int>> reqs = new();
        for(int i = 0; i < numCourses; i++)
            reqs.Add(new List<int>());
        foreach(var prereq in prerequisites)
        {
            reqs[prereq[0]].Add(prereq[1]);
        }

        for(int i = 0; i < numCourses; i++)
        {
            if(!Dfs(i, path, result, reqs))
                return new int[0];
        }

        return result.ToArray();
    }

    private bool Dfs(int i, HashSet<int> path, List<int> result, List<List<int>> reqs)
    {
        if(path.Contains(i))
            return false;
        if(result.Contains(i))
            return true;
        
        path.Add(i);
        var iReqs = reqs[i];
        foreach(var iReq in iReqs)
        {
            if(!Dfs(iReq, path, result, reqs))
                return false;
        }
        result.Add(i);
        path.Remove(i);
        return true;
    }
}
