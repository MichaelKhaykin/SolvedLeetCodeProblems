public class MyStack {

    /** Initialize your data structure here. */
    Queue<int> data = new Queue<int>();
    public MyStack() {
        
    }
    
    /** Push element x onto stack. */
    public void Push(int x) {
        data.Enqueue(x);
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int Pop() {
        List<int> r = new List<int>();
        foreach(var item in data)
        {
            r.Add(item);
        }
        r.Reverse();
        int numToReturn = r[0];
    
        data = new Queue<int>();
        r.Reverse();
        for(int i = 0; i < r.Count - 1; i++)
        {
            data.Enqueue(r[i]);
        }
        
        return numToReturn;
    }
    
    /** Get the top element. */
    public int Top() {
        List<int> r = new List<int>();
        foreach(var item in data)
        {
            r.Add(item);
        }
        r.Reverse();
        int numToReturn = r[0];
    
        data = new Queue<int>();
        r.Reverse();
        foreach(var item in r)
        {
            data.Enqueue(item);
        }
        
        return numToReturn;
    }
    
    /** Returns whether the stack is empty. */
    public bool Empty() {
        return data.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
