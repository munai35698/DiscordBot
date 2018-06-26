using System;
using System.Configuration;
using System.Runtime.CompilerServices;

using This = DiscordBot.Client.AppSettings;

namespace DiscordBot.Client
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
