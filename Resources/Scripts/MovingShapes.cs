using bdv;
using System.Collections.Generic;

namespace Scripts
{
    public class MovingShapes : IScript
    {
        public List<Entity> Entities { get; set; }
        public RGBA BackgroundColor { get; set; }
        public Dimension Resolution { get; set; }

        public MovingShapes()
        {
            Resolution = new Dimension(800, 600);
            BackgroundColor = new RGBA(0, 0, 0, 255);
            Entities = new List<Entity>();
            Entities.Add(new Entity(
             Point<float>.Factory(0.0f, 0.0f),
              new Dimension(100, 100), new SpriteSheet("Sprites/DefaultSpritesheet", Point<int>.Factory(2, 0), Point<int>.Factory(0, 0))));
            Entities.Add(new Entity(
           Point<float>.Factory(350.0f, 150.0f),
            new Dimension(100, 100), new SpriteSheet("Sprites/DefaultSpritesheet", Point<int>.Factory(4, 0), Point<int>.Factory(0, 0))));
            foreach (var obj in Entities)
            {
                obj.SetSpeed(Point<float>.Factory(5.0f, 5.0f));
            }
        }

        public void Update()
        {
            foreach (var entity in Entities)
            {
                entity.position.x += entity.speed.x;
                entity.position.y += entity.speed.y;

                if (entity.position.x > Resolution.Width || entity.position.x < 0)
                {
                    entity.Transform("X", Point<float>.Factory(entity.speed.x * -1.0f, 0.0f));
                }
                if (entity.position.y > Resolution.Height || entity.position.y < 0)
                {
                    entity.Transform("Y", Point<float>.Factory(0.0f, entity.speed.y * -1.0f));
                }
            }
        }
    }
}