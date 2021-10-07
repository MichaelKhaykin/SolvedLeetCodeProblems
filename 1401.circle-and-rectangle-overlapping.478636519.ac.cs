public class Solution {
    public bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2) {
        
        if (x_center + radius <= x2 && x_center - radius >= x1 && y_center + radius <= y2 &&
                    y_center - radius >= y1)
        {
            return true;
        }
        
        double midX = (double) x1 + (double) (x2 - x1) / 2;
        double midY = (double) y1 + (double) (y2 - y1) / 2;

        if (midX >= x_center - radius && midX <= x_center + radius && midY >= y_center - radius &&
            midY <= y_center + radius)
        {
            return true;
        }
        
        int squareRad = (x2 - x1) / 2;
        
        int centerX = (x2 - x1) / 2 + x1;
        int centerY = (y2 - y1) / 2 + y1;
        
        Rectangle square = new Rectangle(x1, y2, x2 - x1, y2 - y1);
        
        //x_center + radius * Math.cos(0), y_center + radius * Math.sin(0)
        for(double i = 0; i < 360; i += 0.5)
        {
            var currentPointX = x_center + radius * Math.Cos(i * Math.PI / 180);
            var currentPointY = y_center + radius * Math.Sin(i * Math.PI / 180);
            
            if(IsPointInRectangle(square, currentPointX, currentPointY))
            {
                return true;
            }
        }
        
        if(IsPointInRectangle(square, x_center, y_center)) return true;
        
        return false;
    }
    
    public struct Rectangle
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
    
    public bool IsPointInRectangle(Rectangle rect, double x, double y)
    {
        return x >= rect.X && x <= rect.X + rect.Width && y <= rect.Y && y >= rect.Y - rect.Height;
    }
}
