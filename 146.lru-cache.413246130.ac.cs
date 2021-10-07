public class LRUCache
{
    public class DoublyLinkedNode
    { 
        public int Key { get; set; }
        public int Value { get; set; }
        public DoublyLinkedNode Next { get; set; }
        public DoublyLinkedNode Previous { get; set; }

    }

    DoublyLinkedNode Head = new DoublyLinkedNode();
    DoublyLinkedNode Tail = new DoublyLinkedNode();
    Dictionary<int, DoublyLinkedNode> table = new Dictionary<int, DoublyLinkedNode>();

    int capacity;

    public LRUCache(int cap)
    {
        capacity = cap;
        Head = new DoublyLinkedNode()
        {
            Key = int.MinValue,
            Value = int.MinValue,
        };
        Tail = new DoublyLinkedNode()
        {
            Key = int.MaxValue,
            Value = int.MaxValue
        };

        Head.Next = Tail;
        Tail.Previous = Head;
    }

    public void MoveToFront(DoublyLinkedNode node)
    {
        if (node.Previous != null && node.Next != null)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }
        
        var oldnext = Head.Next;

        Head.Next = node;
        node.Previous = Head;
        node.Next = oldnext;
        oldnext.Previous = node;
    }
    public int Get(int key)
    {
        if (!table.ContainsKey(key)) return -1;
        var node = table[key];

        MoveToFront(node);

        return node.Value;
    }
    public void Put(int key, int value)
    {
        if(table.ContainsKey(key))
        {
            table[key].Value = value;
            MoveToFront(table[key]);
            return;
        }

        if (table.Count < capacity)
        {
            var nodeToAdd = new DoublyLinkedNode() { Key = key, Value = value };
            MoveToFront(nodeToAdd);
            table.Add(key, nodeToAdd);
            return;
        }

        DoublyLinkedNode node = new DoublyLinkedNode() { Key = key, Value = value };
        MoveToFront(node);
        table.Add(key, node);
        var prev = Tail.Previous;
        prev.Previous.Next = Tail;
        Tail.Previous = prev.Previous;

        table.Remove(prev.Key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
