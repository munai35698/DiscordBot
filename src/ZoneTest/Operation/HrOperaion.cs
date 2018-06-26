using System.Threading.Tasks;
using Discord.Commands;

namespace ZoneTest.Operation
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
