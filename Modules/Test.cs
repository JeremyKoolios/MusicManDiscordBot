using Discord.Commands;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace DiscordMusicBot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Responds with pong!")]
        public async Task Pong()
        {
            Console.WriteLine("ping command executed");
            await Context.Channel.SendMessageAsync("pong!");
        }
    }
}
