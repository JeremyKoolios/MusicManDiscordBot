using DiscordMusicBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
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
            // Client creation
            DiscordClient discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All, // Limits the type of events that the bot receives
                MinimumLogLevel = LogLevel.Debug
            });

            // Command Handling
            CommandsNextExtension commands = discordClient.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });
            commands.RegisterCommands<MyFirstModule>();

            // Connection
            await discordClient.ConnectAsync();

            



            // Keep application from closing
            await Task.Delay(-1);
        }

            
    }
}
