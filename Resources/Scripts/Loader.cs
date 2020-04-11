using bdv;
using System.Collections.Generic;

namespace Scripts
{
    public class Loader
    {
        public IScript ScriptToLoad;
        public Loader()
        {
            // ScriptsToLoad.Add(new GridTemplate());
            // ScriptsToLoad.Add(new MovingShapes());
             ScriptToLoad = new Conways();
            // ScriptsToLoad.Add(new TestingSheet());
        }
    }
}