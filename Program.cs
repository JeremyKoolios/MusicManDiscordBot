using DiscordMusicBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        // Actual Main function
        static async Task MainAsync()
        {
            // Application configuration
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All, // Limits the type of events that the bot receives
                MinimumLogLevel = LogLevel.Debug
            });
            var services = new ServiceCollection()
                .AddSingleton<Random>()
                .BuildServiceProvider();
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                Services = services
            });

            // Register modules
            commands.RegisterCommands<MyFirstModule>();

            // Connect client to discord
            await discord.ConnectAsync();

            



            // Keep application from closing
            await Task.Delay(-1);
        }

            
    }
}
