using System;
using System.Threading.Tasks;
using Discord.Commands;
using ZoneTest.Operation;

using This = ZoneTest.Operation.DiceOperation;
//using This = ZoneTest.DiceOperation;

namespace ZoneTest.Operation
//namespace ZoneTest
{
    public class DiceOperation : FormattedModuleBase
    {
        private static int DefaultMaxValue = 99;

        [Command("dice default")]
        public async Task DefautAsync(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value is not natural");

            This.DefaultMaxValue = value;
            await this.ReplyAsync("dice defined.").ConfigureAwait(false);
        }

        [Command("dice")]
        public async Task DiceAsync()
            => await this.DiceAsync(This.DefaultMaxValue).ConfigureAwait(false);

        [Command("dice")]
        public async Task DiceAsync(int maxValue)
        {
            var random = new Random(DateTime.Now.Millisecond);
            await this.ReplyAsync(random.Next(1, maxValue).ToString()).ConfigureAwait(false);
        }
    }
}
