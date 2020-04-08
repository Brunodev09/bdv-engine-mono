using System.Collections.Generic;

namespace bdv
{
    public interface IScript
    {
        List<Entity> Entities { get; set; }
        Dimension Resolution { get; set; }
        RGBA BackgroundColor { get; set; }

        void Update();
    }
}