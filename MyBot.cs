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

            commands.CreateCommand("Status")
                .Description("Checks the bots status")
                .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("```Discord-Bot Status: \n Version: " + Environment.Version + "\n Running on: " + Environment.OSVersion + "\n Running from file location: " + Environment.CurrentDirectory + "``` \n And made by https://danielgray.me!");
                    });
            commands.CreateCommand("terminate")
                .AddCheck((cmd, u, ch) => u.Id == 137957400765267968)
                .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("Goodbye world!(Shut down by owner)");
                        Environment.Exit(0);
                    });
            commands.CreateCommand("memes")
                .Description("Providing the best memes for your daily entertainment")
                .Do(async (e) =>
                    {
                        Random meme = new Random();
                        var memetoshow = meme.Next(1, 11);
                        if (memetoshow == 1)
                        {
                            await e.Channel.SendMessage("https://images.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FVdb_ParFCks%2Fmaxresdefault.jpg&f=1");
                        }
                        else if (memetoshow == 2)
                        {
                            await e.Channel.SendMessage("https://images.duckduckgo.com/iu/?u=https%3A%2F%2Fimg.ifcdn.com%2Fimages%2F30f9c0651e51719c64f59c309684b115d9752bd7dc76e11f6c3589433f047050_1.jpg&f=1");
                        }
                        else if (memetoshow == 3)
                        {
                            await e.Channel.SendMessage("https://images.duckduckgo.com/iu/?u=https%3A%2F%2Fi.imgflip.com%2F155ngq.jpg&f=1");
                        }
                        else if (memetoshow == 4)
                        {
                            await e.Channel.SendMessage("https://images.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FVrC42YOcLU4%2Fmaxresdefault.jpg&f=1");
                        }
                        else if (memetoshow == 5)
                        {
                            await e.Channel.SendMessage("https://images.duckduckgo.com/iu/?u=http%3A%2F%2Fi0.kym-cdn.com%2Fphotos%2Fimages%2Fnewsfeed%2F000%2F875%2F516%2Fde9.jpg&f=1");
                        }

                    });

            discord.UserJoined += async (s, e) =>
                 {
                     Console.WriteLine("[" + e.Server.Name + "] " + e.User.Name + "#" + e.User.Discriminator + " Has joined the server");
                     await e.Server.DefaultChannel.SendMessage("Please welcome " + e.User.Mention + " to the server! Make sure you obey the rules and enjoy!");
                 };

           


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
