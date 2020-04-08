namespace bdv
{
    public class Render
    {
        private RenderQueue renderObjects = new RenderQueue();

        public RenderQueue RequestQueue()
        {
            return renderObjects;

        }


    }
}