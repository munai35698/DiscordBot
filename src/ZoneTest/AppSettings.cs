using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using This = ZoneTest.AppSettings;

namespace ZoneTest
{
    public static class AppSettings
    {
        public static string AccessToken => This.GetValue();

        public static string GetValue([CallerMemberName]string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return ConfigurationManager.AppSettings[name];
        }
    }
}
