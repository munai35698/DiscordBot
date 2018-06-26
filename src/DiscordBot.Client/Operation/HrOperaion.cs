using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Client.Operation
{
    public class HrOperaion : ModuleBase
    {
        [Command("hr")]
        public async Task HrAsync()
        {
            await this.ReplyAsync("========================================");
        }
    }
}
