public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] rank;
    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for(int i = 0; i < n; i++)
        {
            rank[i] = 1;
            parent[i] = i;
        }
    }

    public int Find(int x)
    {
        if(x != parent[x])
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public bool Union(int n1, int n2)
    {
        var p1 = Find(n1);
        var p2 = Find(n2);
        if(p1 == p2)
            return false;
        
        if(rank[p1] < rank[p2])
        {
            parent[p1] = p2;
            rank[p2] += rank[p1];
        }
        else
        {
            parent[p2] = p1;
            rank[p1] += rank[p2];
        }

        return true;
    }
}

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var unionFind = new UnionFind(n);
        foreach(var edge in edges)
        {
            unionFind.Union(edge[0], edge[1]);
        }

        HashSet<int> parents = new();
        for(int i = 0; i < n; i++)
        {
            parents.Add(unionFind.Find(i));
        }
        return parents.Count;
    }
}
