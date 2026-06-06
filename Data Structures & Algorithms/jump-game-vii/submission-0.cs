public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) 
    {
        if(s[s.Length - 1] == '1')
            return false;

        var dp = new bool[s.Length];
        dp[s.Length - 1] = true;

        for(int i = s.Length - 2; i >= 0; i--)
        {
            if(s[i] == '1')
            {
                continue;
            }
            var maxJ = Math.Min(maxJump, s.Length - i - 1);
            for(int j = maxJ; j >= minJump; j--)
            {
                if(dp[i + j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[0];     
    }
}