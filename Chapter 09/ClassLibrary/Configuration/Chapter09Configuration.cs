using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace Chapter09.Configuration
{
    public class Chapter09Configuration
    {
        public static Chapter09SectionGroup GetConfig()
        {
            System.Configuration.Configuration config;
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                string path = "~";
                config = WebConfigurationManager.OpenWebConfiguration(path);
            }
            else
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            Chapter09SectionGroup chapter09Config =
               (Chapter09SectionGroup)config.SectionGroups["chapter09Group"];
            return chapter09Config;
        }
    }
}
