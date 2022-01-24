using System;
using System.Diagnostics.Contracts;


namespace ConsoleApp3
{
    [Serializable]
    public struct Rectangle
    {
        private Point topLeftPoint;
        private double width;
        private double height;

        public Point TopLeftPoint
        {
            get { return topLeftPoint; }
        }
        public double Width
        {
            get { return width; }
        }
        public double Height
        {
            get { return height; }
        }

        public Rectangle(Point topLeftPoint, double width, double height)
        {
            if (width <= 0) throw new ArgumentNullException();
            if (height <= 0) throw new ArgumentNullException();

            this.topLeftPoint = topLeftPoint;
            this.width = width;
            this.height = height;
        }

        public bool Intersects(Rectangle rectangle)
        {
            return IsInRectangle(rectangle.TopLeftPoint) ||
                   rectangle.IsInRectangle(this.TopLeftPoint);
        }

        public bool Contains(Rectangle rectangle)
        {
            return IsInRectangle(rectangle.TopLeftPoint) &&
                   IsInRectangle(new Point(rectangle.TopLeftPoint.X + Width, rectangle.TopLeftPoint.Y + Height));
        }

        public bool IsInRectangle(Point point)
        {
            return (point.X >= TopLeftPoint.X) &&
                   (point.X <= (TopLeftPoint.X + Width)) &&
                   (point.Y >= TopLeftPoint.Y) &&
                   (point.Y <= (TopLeftPoint.Y + Height));
        }
    }
}
