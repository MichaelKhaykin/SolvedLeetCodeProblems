/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */

public class NestedIterator
{
    private readonly Stack<NestedInteger> _stack;
    private readonly ISet<NestedInteger> _visited;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _stack = new Stack<NestedInteger>();
        _visited = new HashSet<NestedInteger>();
        for (int i = nestedList.Count - 1; i >= 0; i--)
        {
            if (_visited.Add(nestedList[i]))
            {
                _stack.Push(nestedList[i]);
            }
        }
    }

    private void MoveStack()
    {
        while (_stack.Count != 0 && !_stack.Peek().IsInteger())
        {
            var pop = _stack.Pop();
            for (int i = pop.GetList().Count - 1; i >= 0; i--)
            {
                if (_visited.Add(pop.GetList()[i]))
                {
                    _stack.Push(pop.GetList()[i]);
                }
            }
        }
    }

    public bool HasNext()
    {
        MoveStack();
        return _stack.Count > 0;
    }

    public int Next()
    {
        MoveStack();
        return _stack.Pop().GetInteger();
    }
}

public class NestedIterator2 {

    List<int> n;
    int current = 0;
    
    public NestedIterator2(IList<NestedInteger> nestedList) {
        
        n = new List<int>();
        
        foreach(var nestedInt in nestedList)
        {
            var list = new List<int>();
            Convert(nestedInt, list);
            
            n.AddRange(list);
        }
    }
    
    private void Convert(NestedInteger n, List<int> current)
    {
        if(n.IsInteger())
        {
            current.Add(n.GetInteger());
            return;
        }
        
        var list = n.GetList();
        foreach(var item in list)
        {
            Convert(item, current);
        }
    }

    public bool HasNext() {
        return current < n.Count;
    }

    public int Next() {
        return n[current++];
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
