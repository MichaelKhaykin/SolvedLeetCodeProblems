public class Solution {
    public int SingleNumber(int[] nums) {
        var list = nums.ToList();
        list.Sort();
        
        for(int i = 0; i < list.Count; i +=2)
        {
            if(i + 1 >= list.Count) return list[i];
            if(list[i] != list[i + 1])
            {
                return list[i];
            }
        }
        
        return -1;
    }
}
