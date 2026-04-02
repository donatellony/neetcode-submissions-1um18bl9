public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new(numCourses);
        var inDegree = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
            adj.Add([]);
        
        foreach(var pre in prerequisites)
        {
            int course = pre[0];
            int prereq = pre[1];

            adj[prereq].Add(course);
            inDegree[course]++;
        }

        var queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++)
        {
            if(inDegree[i] == 0)
                queue.Enqueue(i);
        }

        var result = new List<int>();
        while(queue.Count > 0)
        {
            var noPrereqsCourse = queue.Dequeue();
            result.Add(noPrereqsCourse);
            foreach(var neigh in adj[noPrereqsCourse])
            {
                if(--inDegree[neigh] == 0)
                {
                    queue.Enqueue(neigh);
                }
            }
        }

        return result.Count == numCourses ? result.ToArray() : [];
    }
}
