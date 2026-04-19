public class Solution {

    /*
    Input: s = "zxyzxyz"

    Output: 3


    */
    public int LengthOfLongestSubstring(string s) 
    {
        HashSet<char> chars = [];
        int l = 0, max = 0;
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
