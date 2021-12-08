using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            string token = File.ReadAllText("C:/Users/jerem/Desktop/Dev/projects/DiscordMusicBot/bin/Debug/net5.0/token.txt");

            // Keep application from closing
            await Task.Delay(-1);
        }
    }
}
