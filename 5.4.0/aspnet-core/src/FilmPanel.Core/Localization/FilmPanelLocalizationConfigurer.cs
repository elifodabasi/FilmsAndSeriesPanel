using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FilmPanel.Localization
{
    public static class FilmPanelLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FilmPanelConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FilmPanelLocalizationConfigurer).GetAssembly(),
                        "FilmPanel.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
