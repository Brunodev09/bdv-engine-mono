using System.Collections.Generic;

namespace bdv
{
    public class RenderQueue
    {
        private Queue<Entity> Stage;

        public RenderQueue()
        {
            Stage = new Queue<Entity>();
        }

        public Queue<Entity> Enqueue(Entity entity)
        {
            Stage.Enqueue(entity);
            return Stage;
        }

        public Entity Dequeue()
        {
            return Stage.Dequeue();
        }

        public Queue<Entity> GetQueue()
        {
            return Stage;
        }
    }
}