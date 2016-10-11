using System.Configuration;

namespace Chapter09.Configuration
{
    public class Chapter09Section : ConfigurationSection
    {
        [ConfigurationProperty("connectionStringName", 
            DefaultValue = "chapter09", IsRequired = true), 
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

        [ConfigurationProperty("enableAutoUpdates", 
            DefaultValue = "True", IsRequired = false)]
        public bool EnableAutoUpdates
        {
            get
            {
                bool enabled;
                bool.TryParse(this["enableAutoUpdates"].ToString(), out enabled);
                return enabled;
            }
            set
            {
                this["enableAutoUpdates"] = value;
            }
        }

    }
}
