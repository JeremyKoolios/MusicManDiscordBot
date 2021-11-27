using Discord;
using Discord.Commands;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace DiscordMusicBot.Modules
{
    public class Music : ModuleBase<SocketCommandContext>
    {
        [Command("join", RunMode = RunMode.Async)]
        [Summary("Joins a voice channel")]
        public async Task JoinChannel(IVoiceChannel voiceChannel = null)
        {
            Console.WriteLine("join command executed");
            await Context.Channel.SendMessageAsync("*joins voice channel*");

            // Get the audio channel that the user is in
            voiceChannel = voiceChannel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if(voiceChannel == null)
            {
                await Context.Channel.SendMessageAsync("You must be in a voice channel to use this command");
                return;
            }

            // Join voice channel
            var audioClient = await voiceChannel.ConnectAsync();
        }
    }
}
