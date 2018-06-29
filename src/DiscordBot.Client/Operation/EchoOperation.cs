using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands; //おまじない

//Echo:入力メッセージをそのまま返してみます。

namespace DiscordBot.Client.Operation
{
    //Echoという実行ファイル
    public class EchoOperation : ModuleBase //おまじない
    {
        //\echo メッセージ というチャット入力で動くことになる。
        //Yamabikoという処理をここで定義します。
        [Command("echo")] //おまじない(キーワード:属性 C#) ←\echo ～～～～～ のときに、ここを実行しなさいという定義になります
        public async Task Yamabiko(string message)
        {
            //※↑string message が、「命令の段階で、1つstring:文字列の情報をもらいます。」

            //ReplyAsync:Discordに、メッセージを送る
            var task = await this.ReplyAsync(message); //var task = の部分はおまじないです
            //task.Wait(); //完全におまじない(終わるまで待ってくださいという意味)
        }

        [Command("好きなコマンドを定義してください")]
        public async Task 好きな名前をつけてください()
        {
           
        }
    }
}
