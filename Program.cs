using DiscordMusicBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        // Actual Main function
        static async Task MainAsync(string[] args)
        {
            // Application configuration
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All, // Limits the type of events that the bot receives
                MinimumLogLevel = LogLevel.Debug
            });

            // Lavalink
            var lavalinkEndpoint = new ConnectionEndpoint
            {
                // From Lavalink\application.yml
                Hostname = "127.0.0.1",
                Port = 2333
            };
            var lavalinkConfig = new LavalinkConfiguration
            {
                // Password from Lavalink\application.yml
                Password = "youshallnotpass",
                RestEndpoint = lavalinkEndpoint,
                SocketEndpoint = lavalinkEndpoint
            };
            var lavalink = discord.UseLavalink();

            // Services
            var services = new ServiceCollection()
                .AddSingleton<Random>()
                .BuildServiceProvider();

            // Commands
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                Services = services
            });
            commands.RegisterCommands<MyFirstModule>();
            commands.RegisterCommands<Lavalink>();

            // Connect to discord then lavalink
            await discord.ConnectAsync();
            await lavalink.ConnectAsync(lavalinkConfig);

            



            await Task.Delay(-1);
        }

            
    }
}
