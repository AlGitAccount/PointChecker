using System.Collections.Generic;

namespace PointChecker.DataStructure
{
    public class LanguageItem
    {
        public string LanguageName { get; set; }
        public List<LanguageContentTranslation> TranslatedLanguages { get; set; }
    }
}
