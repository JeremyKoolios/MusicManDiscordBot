using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DiscordMusicBot.Commands
{
    public class MyFirstModule : BaseCommandModule
    {

        [Command("random")]
        public async Task RandomCommand(CommandContext ctx, int min, int max)
        {
            Random random = new Random();
            await ctx.RespondAsync($"Your random number is: {random.Next(min, max)}!");
        }


        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx, DiscordMember member)
        {
            await ctx.RespondAsync($"Howdy {member.Mention}");
        }
    }
}