public class Solution {
    public int MinEatingSpeed(int[] piles, int h) 
    {
        int l = 1, r = -1;
        foreach(var pile in piles)
            r = Math.Max(pile, r);
        
        while(l < r)
        {
            var m = l + (r-l)/2;
            if(CanEat(piles, h, m))
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }
        return l;
    }

    private bool CanEat(int[] piles, int h, int speed)
    {
        long hours = 0;

        foreach (var pile in piles)
        {
            hours += (pile + speed - 1) / speed;

            if (hours > h)
                return false;
        }

        return true;
    }
}
