using Newtonsoft.Json;
using PointChecker.DataStructure;
using PointChecker.FileReader;

namespace PointChecker.Deserializator
{
    class Deserializator
    {
        public Configuration GetSectionList(string json)
        {
            Configuration configuration = JsonConvert.DeserializeObject<Configuration>(json);
            return configuration;
        }
    }
}
