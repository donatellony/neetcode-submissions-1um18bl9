public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) 
    {
        var dp = new bool?[s1.Length + 1, s2.Length + 1];
        if(s1.Length + s2.Length != s3.Length)
            return false;
        
        return Dfs(0,0);

        bool Dfs(int i1, int i2)
        {
            var i3 = i1 + i2;
            if(dp[i1, i2].HasValue)
                return dp[i1,i2].Value;

            if (i3 == s3.Length)
            {
                dp[i1,i2] = true;
                return true;
            }

            var res = false;
            if (i1 < s1.Length && s1[i1] == s3[i3])
                res = Dfs(i1 + 1, i2);

            if (!res && i2 < s2.Length && s2[i2] == s3[i3])
                res = Dfs(i1, i2 + 1);
            dp[i1,i2] = res;
            return res;
        }
    }
}
