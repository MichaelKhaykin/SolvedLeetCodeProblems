public class MyQueue {

    /** Initialize your data structure here. */
    Stack<int> stack1 = new Stack<int>();
    Stack<int> stack2 = new Stack<int>();
    public MyQueue() {
        
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
        stack1.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        while(stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }
        var returnVal = stack2.Pop();
        while(stack2.Count > 0)
        {
            stack1.Push(stack2.Pop());
        }
        return returnVal;
    }
    
    /** Get the front element. */
    public int Peek() {
         while(stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }
        var returnVal = stack2.Peek();
        while(stack2.Count > 0)
        {
            stack1.Push(stack2.Pop());
        }
        return returnVal;
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return stack1.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
