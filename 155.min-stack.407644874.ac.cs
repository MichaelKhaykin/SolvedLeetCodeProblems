public class MinStack {

    /** initialize your data structure here. */
    int[] dataStorage = new int[100000];
    int currentIndex = -1;
    
    public MinStack() {
        
    }
    
    public void Push(int x) {
        currentIndex++;
        dataStorage[currentIndex] = x;
    }
    
    public void Pop() {
        currentIndex--;
    }
    
    public int Top() {
        return dataStorage[currentIndex];
    }
    
    public int GetMin() {
        int min = int.MaxValue;
        for(int i = 0; i < currentIndex + 1; i++)
        {
            if(min > dataStorage[i])
            {
                min = dataStorage[i];
            }
        }
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
