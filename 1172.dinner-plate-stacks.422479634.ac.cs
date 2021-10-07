public class DinnerPlates
{
    SortedDictionary<int, StackNode> leftMostStackAvaialability; // keep a pointer to the leftmost available stack. Alternatelively we can use a MinHeap
    LinkedList<StackNode> linkedStackNodeList; // Access leftmost and rightmost
    List<StackNode> stackList; // Access by index

    int capacity;
    int length; // length of the linkedList


    public DinnerPlates(int capacity)
    {
        this.capacity = capacity;

        leftMostStackAvaialability = new SortedDictionary<int, StackNode>();
        linkedStackNodeList = new LinkedList<StackNode>();
        stackList = new List<StackNode>();
    }

    public void Push(int val)
    {
        // Insert val at the left most stack that is not filled
        // StackNode for O(1) insertion
        // S1 S2 S3

        if (!leftMostStackAvaialability.Any())
        {
            leftMostStackAvaialability.Add(length, new StackNode(new Stack<int>(capacity))); // log n // 0 -> [] 
            linkedStackNodeList.AddLast(leftMostStackAvaialability.First().Value);
            stackList.Add(leftMostStackAvaialability.First().Value);

            length++;
        }
        // else 
        // 1   4
        // 2 3 5

        var leftMostStack = leftMostStackAvaialability.First().Value.val;
        leftMostStack.Push(val);
        if (leftMostStack.Count == capacity)
        { // if the first stack has reached capacity
            leftMostStackAvaialability.Remove(leftMostStackAvaialability.First().Key); // log n
        }
    }

    public int Pop()
    {
        // StackNode for O(1) deltion

        if (length == 0)
        {
            return -1;
        }

        var rightMostStackNode = linkedStackNodeList.Last?.Value;
        var poppedValue = rightMostStackNode.val.Pop();

        if (!rightMostStackNode.val.Any())
        {
            while (rightMostStackNode != null && !rightMostStackNode.val.Any()) // degenerates to N if empty stacks in the middle: _ _ _ _ 4 => 5 calls
            {
                linkedStackNodeList.RemoveLast(); // O(1)
                stackList.RemoveAt(length - 1); // O(1)
                leftMostStackAvaialability.Remove(length - 1); // O(logn)

                length--;

                rightMostStackNode = linkedStackNodeList.Last?.Value;
            }
        }
        else
        {
            leftMostStackAvaialability.TryAdd(length - 1, rightMostStackNode); // log n
        }

        return poppedValue;
    }

    public int PopAtStack(int index)
    {
        // 0 deleted
        // 1
        // Dictionary for O(1) accessing/removing at. Degenerates to O(N) if collisions 

        if (length == 0 || index >= length)
        {
            return -1;
        }

        var stackNode = stackList.ElementAt(index);
        if (!stackNode.val.Any())
        {
            return -1;
        }

        // else 
        // 1 
        // 2 3 _

        // 1 
        // 2 _ 2

        var popped = stackNode.val.Pop(); // Stack is now again available
        leftMostStackAvaialability.TryAdd(index, stackNode); // log n // 0 -> [] 
        if (index == length - 1 && !stackNode.val.Any())
        {
            // last stack adjustments to avoid popping from a empty right stack
            linkedStackNodeList.RemoveLast(); // O(1)
            stackList.RemoveAt(length - 1); // O(1)
            leftMostStackAvaialability.Remove(length - 1); // O(logn)
            length--;
        }

        return popped;
    }
}

public class StackNode
{
    public Stack<int> val;

    public StackNode prev;
    public StackNode next;

    public StackNode(Stack<int> val = null)
    {
        this.val = val;
    }
}
