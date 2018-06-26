using System;

namespace DiscordBot.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = AppSettings.AccessToken;

            using (var client = new ClientManager(token))
            {
                try
                {
                    var waiting = client.WaitMessageAsync();
                    waiting.Wait();

                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    var aaa = ex;
                }
            }
        }
    }
}
