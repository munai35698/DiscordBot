using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using This = DiscordBot.Client.ClientManager;

namespace DiscordBot.Client
{
    public class ClientManager
    {
        private static DiscordSocketClient Client { get; set; }
        private static CommandService CommandService { get; set; }
        private static IServiceProvider ServiceProvider { get; set; }

        public static string AccessToken { get; set; }

        public ClientManager(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(token);

            This.AccessToken = token;

            This.Client = new DiscordSocketClient();
            This.CommandService = new CommandService();
            This.ServiceProvider = new ServiceCollection().BuildServiceProvider();

            This.Client.MessageReceived += CommandRecieved;
        }

        //static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task WaitMessageAsync()
        {
            await This.CommandService.AddModulesAsync(Assembly.GetEntryAssembly());

            //var types = Assembly.GetEntryAssembly().GetTypes()
            //    .Where(x => x.IsSubclassOf(typeof(ModuleBase)))
            //    .Where(x => !x.IsAbstract)
            //    .ToArray();

            //foreach (var unit in types)
            //    await This.CommandService.AddModuleAsync(unit);

            await This.Client.LoginAsync(TokenType.Bot, This.AccessToken);
            await This.Client.StartAsync();
        }

        public async Task CloseAsync()
        {
            if(This.Client.LoginState == LoginState.LoggedIn)
            {
                await This.Client.StopAsync();
                await This.Client.LogoutAsync();
            }
        }

        /// <summary>
        /// メッセージの受信処理
        /// </summary>
        /// <param name="msgParam"></param>
        /// <returns></returns>
        private async Task CommandRecieved(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);

            if (message == null)
                return;
            if (message.Author.IsBot)
                return;

            var argPos = 0;
            
            if (!(message.HasCharPrefix('\\', ref argPos) ||
                message.HasMentionPrefix(This.Client.CurrentUser, ref argPos)))
                return;

            var context = new CommandContext(This.Client, message);
            // 実行
            var result = await This.CommandService.ExecuteAsync(context, argPos, This.ServiceProvider);

            //実行できなかった場合
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync($"{DateTime.Now} {context.User.Mention} : {context.Message}{Environment.NewLine}Error({result.ErrorReason})");

            //await context.Channel.DeleteMessagesAsync(new[] { context.Message.Id }).ConfigureAwait(false);
        }

    }
}
