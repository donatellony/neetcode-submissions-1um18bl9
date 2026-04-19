public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        HashSet<char> chars = new();
        int max = 0, l = 0;

        for(int r = 0; r < s.Length; r++)
        {
            while(chars.Contains(s[r]))
            {
                chars.Remove(s[l++]);
            }
            chars.Add(s[r]);
            max = Math.Max(max, chars.Count);
        }

        return max;
    }
}
