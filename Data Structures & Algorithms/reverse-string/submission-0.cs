public class Solution {
    public void ReverseString(char[] s) 
    {
        for(int i = 0; i < s.Length / 2; i++)
        {
            (s[i], s[s.Length - 1 - i]) = (s[s.Length - 1 - i], s[i]);
        }
    }
}