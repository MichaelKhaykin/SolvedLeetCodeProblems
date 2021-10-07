public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        
        List<int> kArr = new List<int>();
        do
        {
            kArr.Add(k % 10);
            k /= 10;
        }while(k != 0);
        
        while(kArr.Count < num.Length)
        {
            kArr.Add(0);
        }
        
        List<int> nums = new List<int>(num);
        while(nums.Count < kArr.Count)
        {
            nums.Insert(0, 0);
        }
        
        num = nums.ToArray();
        kArr.Reverse();
        
        List<int> res = new List<int>();
        int carry = 0;
        
        for(int i = num.Length - 1; i >= 0; i--)
        {
            int sum = num[i] + kArr[i] + carry;
            carry = sum / 10;
            sum %= 10;
            
            res.Add(sum);
        }
        
        if(carry != 0)
        {
            res.Add(carry);
        }
        res.Reverse();
        
        return res;
    }
}
