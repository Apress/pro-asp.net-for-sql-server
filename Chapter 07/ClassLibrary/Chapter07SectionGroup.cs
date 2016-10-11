using System.Configuration;
using Chapter07.Domain;

namespace Chapter07
{
    public class Chapter07SectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("favoriteLink")]
        public FavoriteLinkSection FavoriteLinkSection
        {
            get
            {
                return (FavoriteLinkSection)Sections["favoriteLink"];
            }
        }
    }
}
