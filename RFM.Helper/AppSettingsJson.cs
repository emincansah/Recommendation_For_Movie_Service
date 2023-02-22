using Microsoft.Extensions.Configuration;
using System.IO;

namespace Helpers
{
    public static class AppSettingsJson
    {
        public static IConfigurationRoot GetAppSettings()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);
            var builder = new ConfigurationBuilder().SetBasePath(appRoot).AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
