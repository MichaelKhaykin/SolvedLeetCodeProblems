  public class Solution
    {
        public enum Directions
        {
            Right = 0,
            Down = 1,
            Left = 2,
            Up = 3,
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            Directions currDir = Directions.Right;

            int x = 0;
            int y = 0;

            List<int> elements = new List<int>();
            HashSet<(int, int)> seen = new HashSet<(int, int)>();

            int height = matrix.Length;
            int width = matrix[0].Length;
            int totalElementsInMatrix = width * height;

            while (elements.Count < totalElementsInMatrix)
            {
                bool res = IsAtBoundary(y, x, width, height);
                if (res || seen.Contains((y, x)))
                {
                    //figure out the reset point for y, x
                    switch (currDir)
                    {
                        case Directions.Left:
                            x++;
                            break;

                        case Directions.Right:
                            x--;
                            break;

                        case Directions.Up:
                            y++;
                            break;

                        case Directions.Down:
                            y--;
                            break;
                    }

                    if (currDir == Directions.Up)
                    {
                        currDir = Directions.Right;
                    }
                    else
                    {
                        currDir += 1;
                    }

                    Move(ref x, ref y, currDir);
                    continue;
                }

                elements.Add(matrix[y][x]);
                seen.Add((y, x));

                Move(ref x, ref y, currDir);
            }

            return elements;
        }

        public void Move(ref int x, ref int y, Directions dir)
        {
            switch (dir)
            {
                case Directions.Left:
                    x--;
                    break;

                case Directions.Right:
                    x++;
                    break;

                case Directions.Up:
                    y--;
                    break;

                case Directions.Down:
                    y++;
                    break;
            }
        }

        public bool IsAtBoundary(int y, int x, int width, int height)
        {
            return (y < 0 || y >= height || x < 0 || x >= width);
        }
    }
