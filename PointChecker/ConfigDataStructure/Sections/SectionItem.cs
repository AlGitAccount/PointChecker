using System.Collections.Generic;

namespace PointChecker.DataStructure
{
    public class SectionItem
    {
        public string LanguageName { get; set; }
        public List<SectionContentTranslation> TranslatedSections { get; set; }
    }
}
