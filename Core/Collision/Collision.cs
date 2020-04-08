namespace bdv
{
    public class Collision<T>
    {
        public T collisionType { get; set; }
        public static Collision<T> Factory(T collider)
        {
            var current = new Collision<T>();
            current.collisionType = collider;
            return current;
        }
    }
}