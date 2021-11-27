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

        [Command("age")]
        [Summary("Responds with date of user's account creation")]
        public async Task Age()
        {
            Console.WriteLine("age command executed");
            await Context.Channel.SendMessageAsync(
                Context.User.Mention +
                "Your account was created at " +
                Context.User.CreatedAt.DateTime.Date);
        }
    }
}
