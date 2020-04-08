using System.Collections.Generic;
using bdv;

namespace Scripts
{
    public class GridTemplate : IScript
    {
        public List<Entity> Entities { get; set; }
        public RGBA BackgroundColor { get; set; }
        public Dimension Resolution { get; set; }

        public GridTemplate()
        {
            Resolution = new Dimension(800, 600);
            BackgroundColor = new RGBA(255, 20, 147, 255);
            Entities = new List<Entity>();
            int rows = 10;
            int cols = 10;
            var tileSize = new Dimension(Resolution.Width / rows, Resolution.Height / cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Entities.Add(new Entity(
                        Point<float>.Factory(tileSize.Width * i + i, tileSize.Height * j + j),
                        tileSize,
                        new RGBA(255, 0, 255, 255)));
                }
            }
        }

        public void Update() {
            
        }
    }
}