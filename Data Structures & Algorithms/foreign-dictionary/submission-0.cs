public class Solution {
    public string foreignDictionary(string[] words) 
    {
        const int charsAmount = 26;
        List<HashSet<int>> adj = new(charsAmount);
        var indegree = new int[charsAmount];
        Array.Fill(indegree, -1);
        for(int i = 0; i < charsAmount; i++)
            adj.Add(new());
        
        foreach(var word in words)
            foreach(var c in word) 
                indegree[c - 'a'] = 0;

        for(int i = 0; i < words.Length - 1; i++)
        {
            string w1 = words[i], w2 = words[i+1];
            int len = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.StartsWith(w2)) 
                return "";
            
            for(int j = 0; j < len; j++)
            {
                if(w1[j] != w2[j])
                {
                    int c1 = w1[j] - 'a', c2 = w2[j] - 'a';
                    if(adj[c1].Add(c2)) indegree[c2]++;
                    break;
                }
            }
        }
        
        var q = new Queue<int>();
        for(int i = 0; i < charsAmount; i++)
        {
            if(indegree[i] == 0)
                q.Enqueue(i);
        }

        StringBuilder result = new();
        while(q.Count > 0)
        {
            var noDepsChar = q.Dequeue();
            result.Append((char)(noDepsChar + 'a'));
            foreach(var neighbour in adj[noDepsChar])
            {
                if(--indegree[neighbour] == 0)
                {                    
                    q.Enqueue(neighbour);
                }
            }
        }

        for(int i = 0; i < charsAmount; i++)
        {
            if(indegree[i] > 0)
                return "";
        }
        return result.ToString();
    }
}