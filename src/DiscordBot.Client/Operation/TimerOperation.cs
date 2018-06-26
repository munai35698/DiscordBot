using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Discord.Commands;
using This = DiscordBot.Client.Operation.TimerOperation;

namespace DiscordBot.Client.Operation
{
    public class TimerOperation : FormattedModuleBase
    {
        public static System.Timers.Timer Timer { get; set; }
        
        [Command("timer")]
        public async Task TimerAsync(int seconds)
        {
            if (This.Timer != null)
                This.Timer.Dispose();

            var time = seconds * 1000;
            await this.ReplyAsync($"{seconds}(s)の計測を開始します。").ConfigureAwait(false);
            This.Timer = new System.Timers.Timer
            {
                AutoReset = false,
                Interval  = time,
                Enabled   = true,
            };
            This.Timer.Elapsed += this.AlertAsync;
        }

        public async void AlertAsync(object sender,ElapsedEventArgs args)
            => await this.ReplyAsync($"{((System.Timers.Timer)sender).Interval / 1000}(s)が経過しました。").ConfigureAwait(false);
    }
}
