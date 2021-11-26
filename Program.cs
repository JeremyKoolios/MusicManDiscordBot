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

            // MessageReceived event triggers when someone writes a message
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;

            string _token = File.ReadAllText("token.txt");

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

        // Receives and processes every incoming discord message
        private Task CommandHandler(SocketMessage msg)
        {
            // Check whether message is command or not
            string cmd = "";
            int cmdLength = -1;
            char prefix = '!';

            if (!msg.Content.StartsWith(prefix) ||
                msg.Author.IsBot)
                return Task.CompletedTask;

            if (msg.Content.Contains(' '))
                cmdLength = msg.Content.IndexOf(' ');
            else
                cmdLength = msg.Content.Length;

            cmd = msg.Content.Substring(1, cmdLength - 1);

            // List of commands
            switch (cmd)
            {
                case "hello":
                    msg.Channel.SendMessageAsync(msg.Author.Mention + "somebody once told me the world is gonna roll you");
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
