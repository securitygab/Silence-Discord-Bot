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
    public class Embed : ModuleBase
	{
		public DiscordSocketClient _client;

		[Command("embed")]
		public async Task EmbedMsg([Remainder]string say)
		{
			var say1 = new EmbedBuilder()
				.WithDescription(say)
				.WithColor(new Color(0x9D70F9))
				.WithAuthor(author => {
					author
						.WithName(Context.User.Username)
						.WithIconUrl($"https://cdn.discordapp.com/avatars/{Context.User.Id}/{Context.User.AvatarId}.png");
				});

			await ReplyAsync(string.Empty, embed: say1);
		}
	}
}
