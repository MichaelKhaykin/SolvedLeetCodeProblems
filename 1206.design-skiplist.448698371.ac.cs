public class SkipListNode
        {
            public int? Value { get; set; }
            public SkipListNode Below { get; set; }
            public SkipListNode Right { get; set; }

            public SkipListNode Left { get; set; }
            public int Height { get; set; }

            public bool IsSentinal => Value == null;
    
            public SkipListNode(int? value, int height)
            {
                Value = value;
                Height = height;
            }
        }

           public class Skiplist
        {
            Random rand;

            SkipListNode Head;

            public Skiplist()
            {
                this.rand = new Random(Guid.NewGuid().GetHashCode());
                Head = new SkipListNode(null, 0);
            }

            private void InsertInBetween(SkipListNode prev, SkipListNode middle, SkipListNode right)
            {
                prev.Right = middle;
                middle.Left = prev;

                if (prev == right) return;

                middle.Right = right;
                right.Left = middle;
            }

            private void RemoveLink(SkipListNode node)
            {
                node.Left.Right = node.Right;
                if (node.Right != null)
                {
                    node.Right.Left = node.Left;
                }
            }
            private int GenerateHeight(int maxlevel)
            {
                int level = 0;
                while (rand.Next(0, 2) == 0 && level < maxlevel)
                {
                    level++;
                }
                return level;
            }
            public void Add(int value)
            {
                int generatedHeight = GenerateHeight(Head.Height + 1);

                if (generatedHeight > Head.Height)
                {
                    var oldHead = Head;
                    Head = new SkipListNode(null, generatedHeight)
                    {
                        Below = oldHead,
                    };
                }

                SkipListNode current = Head;
                SkipListNode lastInserted = null;

                while (current != null)
                {
                    if (generatedHeight < current.Height)
                    {
                        current = current.Below;
                        continue;
                    }

                    SkipListNode newNode = new SkipListNode(value, current.Height);

                    var prev = current;
                    while (current.IsSentinal || value > current.Value)
                    {
                        prev = current;

                        if (current.Right == null) break;

                        current = current.Right;
                    }

                    InsertInBetween(prev, newNode, current);

                    current = prev.Below;

                    if (lastInserted != null)
                    {
                        lastInserted.Below = newNode;
                    }
                    lastInserted = newNode;
                }
            }
            private SkipListNode search(int value)
            {
                var curr = Head;

                while (curr != null)
                {
                    if (curr.Right == null || value < curr.Right.Value)
                    {
                        curr = curr.Below;
                        continue;
                    }

                    if (value == curr.Right.Value)
                    {
                        return curr.Right;
                    }

                    curr = curr.Right;
                }

                return null;
            }
            public bool Search(int value)
            {
                return search(value) != null;
            }
            public bool Erase(int value)
            {
                var node = search(value);
                if (node == null) return false;

                while (node != null)
                {
                    RemoveLink(node);
                    node = node.Below;
                }

                return true;
            }
        }
