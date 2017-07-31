using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using SilenceBot.Services;
using Humanizer;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace SilenceBot.Commands
{
    public class ChannelInfo : ModuleBase
	{
		[Command("channelinfo")]
		public async Task ChannelInf()
		{
			var builder = new EmbedBuilder()
				.WithColor(new Color(0x9D70F9))
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Channel Name";
					x.Value = (Context.Channel.Name.ToString());
				})
				.AddInlineField("Is NSFW?", Context.Channel.IsNsfw)
				.AddField("Channel ID", Context.Channel.Id.ToString())
				.AddField("Created At", Context.Channel.CreatedAt.ToString());
			await ReplyAsync(string.Empty, embed: builder);
		}
	}
}
