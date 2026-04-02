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
            parent[i] = i;
            rank[i] = 1;
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
        var p1 = Find(n1);
        var p2 = Find(n2);
        if(p1 == p2)
            return false;
        
        if(rank[p1] < rank[p2])
        {
            parent[p1] = p2;
        }
        else if(rank[p2] < rank[p1])
        {
            parent[p2] = p1;
        }
        else
        {
            parent[p2] = p1;
            rank[p1]++;
        }
        return true;
    }
}

public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        var emailToAccMap = new Dictionary<string, int>();
        var unionFind = new UnionFind(accounts.Count);
        for(int accId = 0; accId < accounts.Count; accId++)
        {
            var accInfo = accounts[accId];
            for(int i = 1; i < accInfo.Count; i++)
            {
                var email = accInfo[i];
                if(emailToAccMap.TryGetValue(email, out var existingAccId))
                {
                    unionFind.Union(existingAccId, accId);
                    continue;
                }
                emailToAccMap[email] = accId;
            }
        }

        var accIdToEmailMap = new Dictionary<int, List<string>>();
        foreach(var (email, accId) in emailToAccMap)
        {
            var leaderId = unionFind.Find(accId);
            if(!accIdToEmailMap.ContainsKey(leaderId))
                accIdToEmailMap[leaderId] = new();
            accIdToEmailMap[leaderId].Add(email);
        }

        var result = new List<List<string>>();
        foreach(var (accId, emails) in accIdToEmailMap)
        {
            var accountRow = new List<string>();
            accountRow.Add(accounts[accId][0]);
            accountRow.AddRange(emails.OrderBy(x => x).ToList());
            result.Add(accountRow);
        }
        return result;
    }
}