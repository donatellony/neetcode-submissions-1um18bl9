// 1. Build a topological sort
// 2. Check it by queries

// 0 before 1
public class Solution {
    public List<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) 
    {
        List<List<int>> adj = new(numCourses);
        int[] dependenciesCounter = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
        {
            adj.Add(new());
        }

        foreach(var pre in prerequisites)
        {
            var course = pre[1];
            var dependency = pre[0];
            ++dependenciesCounter[course];
            adj[dependency].Add(course);
        }

        var queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++)
        {
            if(dependenciesCounter[i] == 0)
                queue.Enqueue(i);
        }
        var depsSets = new List<HashSet<int>>();
        for(int i = 0; i < numCourses; i++)
            depsSets.Add(new());

        while(queue.Count > 0)
        {
            var currCourse = queue.Dequeue();
            foreach(var neighbour in adj[currCourse])
            {
                depsSets[neighbour].Add(currCourse);
                depsSets[neighbour].UnionWith(depsSets[currCourse]);

                if(--dependenciesCounter[neighbour] == 0)
                    queue.Enqueue(neighbour);
            }
        }

        var result = new List<bool>();
        foreach(var query in queries)
        {
            var course = query[1];
            var pre = query[0];
            result.Add(depsSets[course].Contains(pre));
        }
        return result;
    }
}