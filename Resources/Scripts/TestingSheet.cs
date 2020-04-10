using bdv;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scripts
{
    public class TestingSheet : IScript
    {
        public List<Entity> Entities { get; set; }
        public RGBA BackgroundColor { get; set; }
        public Dimension Resolution { get; set; }

        public TestingSheet()
        {
            Resolution = new Dimension(800, 600);
            BackgroundColor = new RGBA(0, 0, 0, 255);
            Entities = new List<Entity>();
            var RedTile = new SpriteSheet("Sprites/DefaultSpritesheet", Point<int>.Factory(2, 0), Point<int>.Factory(0, 0));
            Entities.Add(new Entity(Point<float>.Factory(50, 50), new Dimension(100, 100), RedTile));
        }

        public void Update()
        {

        }
    }
}
