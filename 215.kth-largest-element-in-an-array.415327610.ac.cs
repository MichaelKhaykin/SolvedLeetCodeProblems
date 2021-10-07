public class MaxHeap
{
    List<int> data = new List<int>();
    
    public MaxHeap()
    {
        
    }
    
    public void Insert(int val)
    {
        data.Add(val);
        HeapifyUp(data.Count - 1);
    }
    
    public int Pop()
    {
        var rootval = data[0];
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        HeapifyDown(0);
        
        return rootval;
    }
    
    private void HeapifyUp(int index)
    {
        int parent = (index - 1) / 2;
        
        if(index <= 0) return;
        
        if(data[index] > data[parent])
        {
            var temp = data[parent];
            data[parent] = data[index];
            data[index] = temp;
            
            HeapifyUp(parent);
        }
    }
    
    private void HeapifyDown(int index)
    {   
        int left = index * 2 + 1;
        
        if(left >= data.Count) return;
        
        int right = index * 2 + 2;
        
        if(right >= data.Count)
        {
            if(data[left] > data[index])
            {
                var temp = data[index];
                data[index] = data[left];
                data[left] = temp;
            }
            return;
        }
        
        if(data[left] > data[right] && data[left] > data[index])
        {
            var temp = data[index];
            data[index] = data[left];
            data[left] = temp;
            
            HeapifyDown(left);
        }
        else if(data[right] > data[index])
        {
            var temp = data[index];
            data[index] = data[right];
            data[right] = temp;
            
            HeapifyDown(right);
        }
    }
}

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        MaxHeap heap = new MaxHeap();
        
        foreach(var item in nums)
        {
            heap.Insert(item);
        }

        int count = 0;
        while(count < k - 1)
        {
            heap.Pop();
            count++;
        }
        
        return heap.Pop();
    }
}
