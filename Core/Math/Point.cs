namespace bdv
{
    public class Point<T>
    {
        public T x { get; set; }
        public T y { get; set; }

        public static Point<T> Factory(T x, T y)
        {
            var current = new Point<T>();
            current.x = x;
            current.y = y;
            return current;
        }

        public CustomVector2D PointSubtraction(Point<T> a, Point<T> b)
        {
            dynamic dx = a.x;
            dynamic dy = a.y;
            dynamic dxb = b.x;
            dynamic dyb = b.y;
            return new CustomVector2D(Point<T>.Factory(dx - dxb, dy - dyb));
        }
    }
}