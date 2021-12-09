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
        //this property is automatically populated by the service provider
        public Random Rng { private get; set; }

        [Command("random")]
        public async Task RandomCommand(CommandContext ctx, int min, int max)
        {
            await ctx.RespondAsync($"Your random number is: {Rng.Next(min, max)}!");
        }


        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx, DiscordMember member)
        {
            await ctx.RespondAsync($"Howdy {member.Mention}");
        }
    }
}