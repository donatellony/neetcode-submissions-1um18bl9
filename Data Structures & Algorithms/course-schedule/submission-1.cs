public class Solution {
    /*
    0 <-> 1
    0 -> 1
    1 -> 0

    0 -> 1
    0 -> 2
    2 -> 3
    4 -> 2
    */
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        Dictionary<int, HashSet<int>> prereqs = new();
        foreach(var prereq in prerequisites)
        {
            var src = prereq[0];
            var dest = prereq[1];
            if(!prereqs.ContainsKey(src))
            {
                prereqs[src] = new();
            }
            prereqs[src].Add(dest);
        }

        if(!prereqs.Any())
            return true;

        HashSet<int> globalVisited = new();
        HashSet<int> path = new();

        foreach(var prereq in prereqs)
        {
            if(!Dfs(prereq.Key, prereqs, globalVisited, path))
                return false;
            path.Clear();
        }
        return true;
    }

    private bool Dfs(int key, Dictionary<int, HashSet<int>> prereqs, HashSet<int> globalVisited, HashSet<int> path)
    {
        if(path.Contains(key))
            return false;
        
        if(globalVisited.Contains(key))
            return true;
        
        path.Add(key);
        var isEnd = !prereqs.TryGetValue(key, out var keyReqs);
        if(isEnd)
        {
            globalVisited.Add(key);
            return true;
        }
        
        var subtreesRes = true;
        foreach(var keyReq in keyReqs)
        {
            if(!Dfs(keyReq, prereqs, globalVisited, path))
            {
                subtreesRes = false;
                break;
            }
            path.Remove(keyReq);
        }
        globalVisited.Add(key);
        return subtreesRes;
    }
}
