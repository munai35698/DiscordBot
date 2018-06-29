using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;

namespace DiscordBot.Client.Operation
{
    public class PerkOperation : ModuleBase
    {
        //[Command("perk")]
        //public async Task Random() {
        //    string perkname = "selfcare";

        //    await this.ReplyAsync(perkname);
        //}

        [Command("perk")]
        public async Task Random()
        {
            //string[] perkname = ["selfcare",;

            string[] perks = new string[3];
            perks[0] = "セルフケア";
            perks[1] = "全力疾走";
            perks[2] = "決死の一撃";


            //こういう書き方もできるよ
            //var perks2 = new[] //var:そっちで考えてください(中見ればわかるんで)　キーワード:型推論
            //{
            //    "絆",
            //    "セルフケア",
            //    "全力疾走",
            //    "決死の一撃",
            //};

            var randomer = new Random(DateTime.Now.Millisecond);
            var resultIndex = randomer.Next(3);

            await this.ReplyAsync(perks[resultIndex]);
        }

        [Command("奇数偶数")]
        public async Task kisuuguusuu(int number) {
            if (number % 2 == 1)
            // x % y : xをyで割ったあまりを出す
            // x == y :両者が同じ(x=y)かどうか
            {
                //そうだったら
                await this.ReplyAsync("奇数");

            }
            else {
                await this.ReplyAsync("偶数");
            }

        }

        [Command("九九")]
        public async Task kuku(int number) {
            for (int x = 1; x < 10; x++)
            //for(最初の準備 ; ～～～を満たしている間下の内容を繰り返す ; １巡ごとにこれをしてください)
            //※x++ ← xを＋１する
            {
                int answer = number * x;
                string answerAsString = answer.ToString();
                await this.ReplyAsync(answerAsString);
            }
            

        }
    }
}
