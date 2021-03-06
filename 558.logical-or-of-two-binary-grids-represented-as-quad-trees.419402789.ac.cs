public class Solution
    {
        public Node Intersect(Node quadTree1, Node quadTree2)
        {
            if (quadTree1 == null || quadTree2 == null)
            {
                return null;
            }

            if (quadTree1.isLeaf && quadTree2.isLeaf)
            {
                return new Node(quadTree1.val || quadTree2.val, true, null, null, null, null);
            }

            Node tl, tr, bl, br;
            if (quadTree1.isLeaf)
            {
                tl = Intersect(quadTree1, quadTree2.topLeft);
                tr = Intersect(quadTree1, quadTree2.topRight);
                bl = Intersect(quadTree1, quadTree2.bottomLeft);
                br = Intersect(quadTree1, quadTree2.bottomRight);
            }
            else
            {
                if (quadTree2.isLeaf)
                {
                    tl = Intersect(quadTree1.topLeft, quadTree2);
                    tr = Intersect(quadTree1.topRight, quadTree2);
                    bl = Intersect(quadTree1.bottomLeft, quadTree2);
                    br = Intersect(quadTree1.bottomRight, quadTree2);
                }
                else
                {
                    tl = Intersect(quadTree1.topLeft, quadTree2.topLeft);
                    tr = Intersect(quadTree1.topRight, quadTree2.topRight);
                    bl = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
                    br = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);
                }
            }

            if (tl.val == tr.val && tl.val == bl.val && tl.val == br.val)
            {
                if (tl.isLeaf && tr.isLeaf && bl.isLeaf && br.isLeaf)
                {
                    return new Node(tl.val, true, null, null, null, null);
                }
            }

            return new Node(false, false, tl, tr, bl, br);
        }
    }
