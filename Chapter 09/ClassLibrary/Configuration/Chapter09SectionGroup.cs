using System.Configuration;

namespace Chapter09.Configuration
{
    public class Chapter09SectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("chapter09Group")]
        public Chapter09Section Chapter09Section
        {
            get
            {
                return (Chapter09Section)Sections["chapter09"];
            }
        }
    }
}
