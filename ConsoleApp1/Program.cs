using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleApp1
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
         
            botClient = new TelegramBotClient("1007044543:AAHOF5pBe8Peva6DUC2fq1cQWNPEluSjxS4");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.") ;
            botClient.OnMessage += Bot_OnMessage; 
            botClient.StartReceiving(); 
            Thread.Sleep(int.MaxValue);
      
        }


        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                 await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: "You said:\n" + e.Message.Text, replyToMessageId: e.Message.MessageId );
               
            }
        }
    }
}
