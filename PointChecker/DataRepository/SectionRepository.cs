using PointChecker.DataStructure;
using System.Linq;
using System.Collections.Generic;

namespace PointChecker.DataRepository
{
    class SectionRepository
    {
        private static readonly SectionRepository instance = new SectionRepository();
        private Configuration configuration;
        private LanguageItem activeLanguage;

        private SectionRepository() {}

        public static SectionRepository Context()
        {
            return instance;
        }

        public void AddConfiguration(Configuration conf)
        {
            configuration = conf;
            SedActiveLanguage();
        }

        private void SedActiveLanguage()
        {
            ActiveLanguage = (from languageItem in configuration.Language
                             where languageItem.LanguageName == "En"
                             select languageItem).First();
        }

        public LanguageItem ActiveLanguage { get; set; }

        public void UpdateActiveLanguage(string title)
        {
            //var distinctOrderLines = from languageItem in (configuration.Language.
            //    SelectMany(languageList => languageList.TranslatedLanguages).Distinct())
            //                         where languageItem.LanguageTitle == title
            //                         select languageItem;

            //List<SectionItem>
            //List<SectionItem>

            foreach (var languageItem in configuration.Language)
            {
                foreach (var content in languageItem.TranslatedLanguages)
                {
                    if (content.LanguageTitle.Equals(title))
                    {
                        ActiveLanguage = languageItem;
                        return;
                    }
                }
            }

        }

        public List<string> SectionList
        {
            get
            {
                return (from item
                        in ((from sections in configuration.Sections
                             where sections.LanguageName == ActiveLanguage.LanguageName
                             select sections.TranslatedSections
                             ).First()) 
                        select item.SectionTitle
                       ).ToList<string>();
            }
        }

        public List<SectionContentTranslation> GetTranslatedSections
        {
            get
            {
                return (from sections in configuration.Sections
                        where sections.LanguageName == ActiveLanguage.LanguageName
                        select sections.TranslatedSections).First().ToList<SectionContentTranslation>();
            }

        }

        public string LanguageTitle
        {
            get
            {
                return (from item 
                        in ((from language in configuration.Language
                            where language.LanguageName == ActiveLanguage.LanguageName
                            select language.TranslatedLanguages
                        ).First().ToList<LanguageContentTranslation>())
                        select item.LanguageTitle).First();
            }
        }

        public List<string> LanguageList
        {
            get
            {
                return (from item
                        in ((from language in configuration.Language
                             where language.LanguageName == ActiveLanguage.LanguageName
                             select language.TranslatedLanguages
                        ).First().ToList<LanguageContentTranslation>())
                        select item.LanguageTitle).ToList<string>();
            }
        }

        public MenuContentTranslation GeneralMenuNames
        {
            get 
            {
                return (from sections in configuration.Menu
                        where sections.LanguageName == ActiveLanguage.LanguageName
                        select sections.TranslatedMenu).First();
            }
        }
    }
}
