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
        [Command("join")]
        [Summary("Joins a voice channel")]
        public async Task Join()
        {
            Console.WriteLine("join command executed");
            await Context.Channel.SendMessageAsync("pong!");
        }
    }
}
