using System.Collections.Generic;

namespace bdv
{
    public class SpriteSheet : Texture
    {
        public Point<int> spriteWidth;
        public Point<int> spriteHeight;
        public SpriteSheet(string filepath, Point<int> spriteWidth, Point<int> spriteHeight): base(filepath)
        {
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

    }
}
