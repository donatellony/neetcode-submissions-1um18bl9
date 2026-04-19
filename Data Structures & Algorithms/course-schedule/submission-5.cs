public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        var adj = new List<List<int>>(numCourses);
        var indegree = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
        {
            adj.Add([]);
        }

        foreach(var prereq in prerequisites)
        {
            adj[prereq[1]].Add(prereq[0]);
            indegree[prereq[0]]++;
        }

        var queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++)
        {
            if(indegree[i] == 0)
                queue.Enqueue(i);
        }

        var visited = 0;
        while(queue.Count > 0)
        {
            var curr = queue.Dequeue();
            ++visited;
            foreach(var nei in adj[curr])
            {
                if(--indegree[nei] == 0)
                    queue.Enqueue(nei);
            }
        }

        return visited == numCourses;
    }
}
