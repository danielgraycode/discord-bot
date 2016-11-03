using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

//Copyright Daniel Gray 2016
//Please refer to the licence included for more info

namespace Discord_Bot
{
    class MyBot
    {
        DiscordClient discord;


        public MyBot()
        {
            discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Info;



                });


            discord.UsingCommands(x =>
                {
                    //Always good to have a bot prefix that other bots do not tend to use, or discord use.
                    x.PrefixChar = '$';
                    x.AllowMentionPrefix = true;
                    x.HelpMode = HelpMode.Public;
                });

            var commands = discord.GetService<CommandService>();
            //make sure to put your token here
            var ownertoken = 137957400765267968;

            commands.CreateCommand("Status")
                .Description("Checks the bots status")
                .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("```Discord-Bot Status: \n Version: " + Environment.Version + "\n Running on: " + Environment.OSVersion + "\n Running from file location: " + Environment.CurrentDirectory + "``` \n And made by https://danielgray.me!");
                    });


            //startup and login (For closed source program there is a input for the token, feel free to remove if its only you using)
            discord.ExecuteAndWait(async () =>
                {

                    Console.WriteLine("Please enter the bot token (Press enter when finished)");
                    var bottoken = Console.ReadLine();
                    await discord.Connect(bottoken, TokenType.Bot);
                    Console.Title = "Discord-Bot (The best c# bot!)";
                    Console.WriteLine("Discord-Bot Running and logged into discord!");
                });
        }
    }
}
