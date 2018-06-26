using System;

namespace ZoneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = AppSettings.AccessToken;

            var client = new ClientManager(token);
            try
            {
                var waiting = client.WaitMessageAsync();
                waiting.Wait();

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                var aaa = ex;
            }
            finally
            {
                var dispoing = client.CloseAsync();
                dispoing.Wait();
            }

        }
    }
}
