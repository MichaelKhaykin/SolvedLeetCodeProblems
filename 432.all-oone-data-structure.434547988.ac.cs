public class AllOne
    {
        private readonly LinkedList<(ISet<string> keys, int value)> _ll;
        private readonly IDictionary<string, LinkedListNode<(ISet<string> keys, int value)>> _map;
        
        public AllOne()
        {
            _ll = new LinkedList<(ISet<string> keys, int value)>();
            _map = new Dictionary<string, LinkedListNode<(ISet<string> keys, int value)>>();
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (!_map.ContainsKey(key))
            {
                LinkedListNode<(ISet<string> keys, int value)> node = null;
                if (_ll.Count == 0)
                {
                    node = _ll.AddFirst((new HashSet<string>(), 1));
                }
                else
                {
                    if(_ll.First.Value.value == 1)
                    {
                        node = _ll.First;
                    }
                    else
                    {
                        node = _ll.AddFirst((new HashSet<string>(), 1));
                    }
                }

                node.Value.keys.Add(key);
                _map[key] = node;
                return;
            }

            var currentNode = _map[key];
            var next = currentNode.Next;
            currentNode.Value.keys.Remove(key);

            if (next == null)
            {
                next = _ll.AddAfter(currentNode, (new HashSet<string>(), currentNode.Value.value + 1));
            }
            else
            {
                if (next.Value.value > currentNode.Value.value + 1)
                {
                    next = _ll.AddAfter(currentNode, (new HashSet<string>(), currentNode.Value.value + 1));
                }
            }

            next.Value.keys.Add(key);
            _map[key] = next;

            if (currentNode.Value.keys.Count == 0)
            {
                _ll.Remove(currentNode);
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!_map.ContainsKey(key))
            {
                return;
            }

            var currentNode = _map[key];
            var prevNode = currentNode.Previous;

            currentNode.Value.keys.Remove(key);

            if (currentNode.Value.value != 1)
            {
                if (prevNode == null)
                {
                    prevNode = _ll.AddBefore(currentNode, (new HashSet<string>(), currentNode.Value.value - 1));
                }
                else
                {
                    if (prevNode.Value.value < currentNode.Value.value - 1)
                    {
                        prevNode = _ll.AddBefore(currentNode, (new HashSet<string>(), currentNode.Value.value - 1));
                    }
                }

                prevNode.Value.keys.Add(key);
                _map[key] = prevNode;
            }
            else
            {
                _map.Remove(key);
            }

            if (currentNode.Value.keys.Count == 0)
            {
                _ll.Remove(currentNode);
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            if (_ll.Count > 0)
            {
                return _ll.Last.Value.keys.First();
            }

            return string.Empty;
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            if (_ll.Count > 0)
            {
                return _ll.First.Value.keys.First();
            }

            return string.Empty;
        }
    }
