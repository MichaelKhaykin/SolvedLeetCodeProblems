public class Solution {
    
    public class Apple : IComparable<Apple>
    {
        public int val;
        public int index;
        
        public Apple(int val, int index)
        {
            this.val = val;
            this.index = index;
        }
        
        public int CompareTo(Apple y)
        {
            return val.CompareTo(y.val);
        }
    }
    
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        List<Apple> apples = new List<Apple>();
        for(int i = 0; i < nums.Length; i++)
        {
            apples.Add(new Apple(nums[i], i));
        }
        
        Comparison<Apple> comparison = new Comparison<Apple>((x, y) => x.CompareTo(y));
        Comparer<Apple> comparer = Comparer<Apple>.Create(comparison);

        apples.Sort(comparer);
        
        for(int i = 0; i < apples.Count - 1; i++)
        {
            for(int r = i + 1; r < apples.Count && apples[r].val - (long)apples[i].val <= t; r++)
            {
                if(Math.Abs(apples[i].index - apples[r].index) <= k)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
