using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMusicBot.Commands
{
    public class Lavalink : BaseCommandModule
    {
        [Command("join")]
        public async Task Join(CommandContext ctx, [RemainingText] DiscordChannel channel)
        {
            var lava = ctx.Client.GetLavalink();
            if (!lava.ConnectedNodes.Any())
            {
                await ctx.RespondAsync("The Lavalink connection is not established");
                return;
            }

            var node = lava.ConnectedNodes.Values.First();
            if (channel.Type != ChannelType.Voice)
            {
                await ctx.RespondAsync("You need to connect to a voice channel");
                return;
            }

            await node.ConnectAsync(channel);
            await ctx.RespondAsync($"Joined {channel.Name}");
        }

        [Command("leave")]
        public async Task Leave(CommandContext ctx, [RemainingText] DiscordChannel channel)
        {
            var lava = ctx.Client.GetLavalink();
            if (!lava.ConnectedNodes.Any())
            {
                await ctx.RespondAsync("The Lavalink connection is not established");
                return;
            }

            var node = lava.ConnectedNodes.Values.First();

            if (channel.Type != ChannelType.Voice)
            {
                await ctx.RespondAsync("You need to connect to a voice channel");
                return;
            }

            var conn = node.GetGuildConnection(channel.Guild);

            if (conn == null)
            {
                await ctx.RespondAsync("[Leave] Lavalink is not connected");
                return;
            }

            await conn.DisconnectAsync();
            await ctx.RespondAsync($"Left {channel.Name}");
        }

        [Command("play")]
        public async Task Play(CommandContext ctx, [RemainingText] string search)
        {
            if (ctx.Member.VoiceState == null || 
                ctx.Member.VoiceState.Channel == null)
            {
                await ctx.RespondAsync("You need to be connected to a voice channel");
                return;
            }

            var lava = ctx.Client.GetLavalink();
            var node = lava.ConnectedNodes.Values.First();
            var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

            if (conn == null)
            {
                await ctx.RespondAsync("Lavalink is not connected");
                return;
            }

            // search for track on youtube
            var loadResult = await node.Rest.GetTracksAsync(search);

            if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed ||
                loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
            {
                await ctx.RespondAsync($"Could not find any tracks when searching for {search}");
                return;
            }

            var track = loadResult.Tracks.First();

            // Play track
            await conn.PlayAsync(track);
            await ctx.RespondAsync($"Now playing {track.Title}");
        }

        [Command]
        public async Task Play(CommandContext ctx, Uri url)
        {
            if (ctx.Member.VoiceState == null ||
                ctx.Member.VoiceState.Channel == null)
            {
                await ctx.RespondAsync("You need to be connected to a voice channel");
                return;
            }

            var lava = ctx.Client.GetLavalink();
            var node = lava.ConnectedNodes.Values.First();
            var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

            if (conn == null)
            {
                await ctx.RespondAsync("Lavalink is not connected");
                return;
            }
        }
    }
}
