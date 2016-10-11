using System.Configuration;

namespace Chapter07.Domain
{
    public class FavoriteLinkSection : ConfigurationSection
    {
        [ConfigurationProperty("connectionStringName", 
            DefaultValue = "FavoriteLinkDB", IsRequired = true), 
            StringValidator(MinLength = 1, MaxLength = 50)]
        public string ConnectionStringName
        {
            get
            {
                return (string) this["connectionStringName"];
            }
            set
            {
                this["connectionStringName"] = value;
            }
        }
    }
}
