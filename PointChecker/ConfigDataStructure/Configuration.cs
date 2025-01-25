using System.Collections.Generic;

namespace PointChecker.DataStructure
{
    public class Configuration
    {
        public List<LanguageItem> Language { get; set; }
        public List<SizeItem> Size { get; set; }
        public List<MenuItem> Menu { get; set; }
        public List<SectionItem> Sections { get; set; }
    }
}
