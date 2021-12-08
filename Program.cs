using DSharpPlus;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        // Fake Main function
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        // Actual Main function
        static async Task MainAsync()
        {
            DiscordClient discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
        }
            //string token = File.ReadAllText("C:/Users/jerem/Desktop/Dev/projects/DiscordMusicBot/bin/Debug/net5.0/token.txt");

            //// Keep application from closing
            //await Task.Delay(-1);
    }
}
