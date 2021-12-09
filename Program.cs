using DSharpPlus;
using DSharpPlus.Entities;
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
            // DiscordClient creation and connection
            DiscordClient discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All, // Limits the type of events that the bot receives
                MinimumLogLevel = LogLevel.Debug
            });
            await discordClient.ConnectAsync();

            // Message created event handled by lambda expression
            // s contains instance of object that fired the event,
            // e contains arguments for specific event that you're handling
            discordClient.MessageCreated += async (s, e) =>
            {
                // Use _ = Task.Run(async () => { code here } when dealing with commands that take long to run to prevent deadlocks)

                // ping command
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");

                // daniel is epic command
                _ = Task.Run(async () =>
                {
                    if (e.Message.Content.ToLower().StartsWith("daniel is epic"))
                    {
                        using (FileStream fs = new FileStream("C:/Users/jerem/Pictures/hotdoggy.png", FileMode.Open, FileAccess.Read))
                        {
                            DiscordMessage msg = await new DiscordMessageBuilder()
                            .WithContent($"That's right is indeed epic {e.Author.Mention}")
                            .WithFiles(new Dictionary<string, Stream>() { { "C:/Users/jerem/Pictures/hotdoggy.png", fs } })
                            .WithReply(e.Message.Id)
                            .WithAllowedMentions(new IMention[] { new UserMention(e.Author) })
                            .SendAsync(e.Channel);
                        }
                    }
                });
                
            };




            // Keep application from closing
            await Task.Delay(-1);
        }

            
    }
}
