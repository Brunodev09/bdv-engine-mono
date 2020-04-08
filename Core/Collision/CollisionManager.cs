namespace bdv
{
    public class CollisionManager
    {
        public static Collision<RectangleCollider> GetCollider(Model mdl, Entity a, Entity b)
        {
            switch (mdl)
            {
                default:
                case Model.RECTANGLE:
                    {
                        return Collision<RectangleCollider>.Factory(new RectangleCollider(a, b));
                    }
            }
        }
    }
}