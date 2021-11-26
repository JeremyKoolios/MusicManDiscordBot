using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        private DiscordSocketClient _client;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            //initalize application
            _client = new DiscordSocketClient();
            _client.Log += Log;

            string _token = File.ReadAllText("C:/Users/jerem/Desktop/Dev/projects/DiscordMusicBot/token.txt");

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            //keep application from closing
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
