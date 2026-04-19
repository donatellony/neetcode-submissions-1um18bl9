public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        var adj = new List<List<int>>();
        var indegree = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
            adj.Add([]);

        foreach(var prereq in prerequisites)
        {
            var a = prereq[0];
            var b = prereq[1];
            adj[b].Add(a);
            indegree[a]++;
        }

        Queue<int> queue = new();
        for(int i = 0; i < indegree.Length; i++)
        {
            if(indegree[i] == 0)
                queue.Enqueue(i);
        }

        List<int> result = [];
        HashSet<int> visited = [];
        while(queue.Count > 0)
        {
            var curr = queue.Dequeue();
            result.Add(curr);
            visited.Add(curr);
            foreach(var nei in adj[curr])
            {
                if(visited.Contains(nei))
                    continue;
                if(--indegree[nei] == 0)
                    queue.Enqueue(nei);
            }
        }

        return result.Count == numCourses ? result.ToArray() : [];
    }
}
