namespace bdv
{
    public class CustomVector2D
    {
        public Point<float> Components { get; }

        public int Mod { get; }

        public CustomVector2D(Point<float> components)
        {
            Components = Point<float>.Factory(components.x, components.y);
        }

        public void SumOrSubtract(Point<float> components)
        {
            Components.x += components.x;
            Components.y += components.y;
        }

    }
}