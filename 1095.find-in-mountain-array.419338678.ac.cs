/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    
    Dictionary<int, int> memo = new Dictionary<int, int>();
    
    int Add(MountainArray array, int index)
    {
        if(index < 0) return -1;
        if(index >= array.Length()) return array.Length();
        
        if(memo.ContainsKey(index))
        {
            return memo[index];
        }
        memo.Add(index, array.Get(index));
        return memo[index];
    }
    
    bool IsLeftSide(MountainArray array, int index)
    {
        var left = Add(array, index - 1);
        var middle = Add(array, index);
        var right = Add(array, index + 1);
        
        return left < middle && middle < right;
    }
    
    bool IsRightSide(MountainArray array, int index)
    {
        var left = Add(array, index - 1);
        var middle = Add(array, index);
        var right = Add(array, index + 1);
        
        return left > middle && middle > right;
    }
   
    public int FindInMountainArray(int target, MountainArray array) {
        
        int low = 0;
        int high = array.Length() - 1;
        
        bool foundPeak = false;
        int peak = -1;
        while(true)
        {
            int mid = (low + high) / 2;
            
            if(IsLeftSide(array, mid)) 
            {
                low = mid + 1;
            }
            else if(IsRightSide(array, mid))
            {
                high = mid - 1;
            }
            else
            {
                foundPeak = true;
                peak = mid;
                break;
            }
        }
        
        int left = Find(target, array, 0, peak, true);
        if(left != -1) return left;
        
        return Find(target, array, peak, array.Length(), false);
    }
    
    int Find(int target, MountainArray array, int low, int high, bool asc)
    {
        while(low <= high)
        {
            int mid = (low + high) / 2;
            var val = Add(array, mid);
            if(val == target) return mid;
            
            if(val > target)
            {
                if(asc)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else
            {
                if(asc)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }
        
        return -1;
    }
}
