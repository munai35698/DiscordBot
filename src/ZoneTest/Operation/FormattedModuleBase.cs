using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;


namespace ZoneTest.Operation
{
    public class FormattedModuleBase : ModuleBase
    {
        protected override async Task<IUserMessage> ReplyAsync(string message, bool isTTS = false, Embed embed = null, RequestOptions options = null)
            => await base.ReplyAsync(this.Formatted(message), isTTS, embed, options).ConfigureAwait(false);

        private string Formatted(string Message)
            => $"{DateTime.Now.ToShortTimeString()} {Context.User.Mention} : {Context.Message} => {Message} ";
    }
}
