using bdv;
using System.Collections.Generic;

namespace Scripts
{
    public class Loader
    {
        public List<IScript> ScriptsToLoad = new List<IScript>();
        public Loader()
        {
            // ScriptsToLoad.Add(new GridTemplate());
            // ScriptsToLoad.Add(new MovingShapes());
             ScriptsToLoad.Add(new Conways());
            // ScriptsToLoad.Add(new TestingSheet());
        }
    }
}