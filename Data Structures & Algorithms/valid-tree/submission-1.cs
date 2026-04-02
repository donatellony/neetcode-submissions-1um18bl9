public class UnionFind
{
    private int[] parent;
    private int[] rank;

    public int MaxRank => rank.Max();

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
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    public bool Union(int n1, int n2)
    {
        int p1 = Find(n1), p2 = Find(n2);
        if(p1 == p2)
            return false;
        
        if(rank[p2] > rank[p1])
        {
            rank[p2] += rank[p1];
            parent[p1] = p2;
        }
        else
        {
            rank[p1] += rank[p2];
            parent[p2] = p1;
        }

        return true;
    }
}

public class Solution {
    public bool ValidTree(int n, int[][] edges) 
    {
        var unionFind = new UnionFind(n);
        foreach(var e in edges)
        {
            if(!unionFind.Union(e[0], e[1]))
                return false;
        }
        return unionFind.MaxRank == n;
    }
}
