using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot.Commands
{
    public class MyFirstModule : BaseCommandModule
    {
        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx, [RemainingText] string name)
        {
            await ctx.RespondAsync($"Howdy {name}");
        }
    }
}