using System.Collections.Generic;

namespace bdv
{
    public class GenericDictionary
    {
        private Dictionary<string, object> _dict = new Dictionary<string, object>();

        public void Set<T>(string key, T value) where T : class
        {
            _dict.Add(key, value);
        }

        public T Get<T>(string key) where T : class
        {
            return _dict[key] as T;
        }
    }
}