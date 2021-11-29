using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private CommandHandler _commandHandler;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            // Initalize application
            _client = new DiscordSocketClient();
            _client.Log += Log;

            string token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // CommandHandling
            _commands = new CommandService(); // CommandService is a framework for commands. It automatically gets Discord messages

            _commandHandler = new CommandHandler(_client, _commands);
            await _commandHandler.InstallCommandsAsync();

            // Keep application from closing
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
