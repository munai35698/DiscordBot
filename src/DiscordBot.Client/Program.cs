using System;

namespace DiscordBot.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //アクセストークン：Botのパスワード読み込み
            var token = AppSettings.AccessToken;

            using (var client = new ClientManager(token)) //実処理の準備
            {
                try //おまじない
                {
                    //メッセージの受信を待つ
                    var waiting = client.WaitMessageAsync();
                    waiting.Wait();

                    //何がしのキーボード入力を待つ
                    Console.ReadLine();
                }
                catch (Exception ex) //おまじない
                {
                    var aaa = ex;
                }
            }
        }
    }
}
