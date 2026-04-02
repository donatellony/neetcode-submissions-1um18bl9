public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var ends = new HashSet<string>(deadends);
        var queue = new Queue<string>();
        var used = new HashSet<string>();
        var result = 0;
        queue.Enqueue("0000");
        while(queue.Count > 0)
        {
            var size = queue.Count;
            while(size-- > 0)
            {
                var curr = queue.Dequeue();
                if(curr == target)
                    return result;
                
                if(used.Contains(curr))
                    continue;
                if(ends.Contains(curr))
                    continue;
                used.Add(curr);

                foreach(var code in GetPossibleCodes(curr))
                {
                    queue.Enqueue(code);
                }
            }
            ++result;
        }
        return -1;
    }
    
    private HashSet<string> GetPossibleCodes(string src)
    {
        var possibleTransitions = new HashSet<string>();
        for(int i = 0; i < src.Length; i++)
        {
            var n = int.Parse(src[i].ToString());
            string prefix = "";
            string suffix = "";
            if(i > 0)
                prefix = src.Substring(0, i);
            if(i < src.Length - 1)
                suffix = src.Substring(i + 1);
            if(n == 0)
            {
                possibleTransitions.Add(prefix + "9" + suffix);
                possibleTransitions.Add(prefix + "1" + suffix);
            }
            else if(n == 9)
            {
                possibleTransitions.Add(prefix + "8" + suffix);
                possibleTransitions.Add(prefix + "0" + suffix);
            }
            else
            {
                possibleTransitions.Add(prefix + (n-1).ToString() + suffix);
                possibleTransitions.Add(prefix + (n+1).ToString() + suffix);
            }
        }
        return possibleTransitions;
    }
}