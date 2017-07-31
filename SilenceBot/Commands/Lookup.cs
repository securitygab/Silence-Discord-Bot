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
    public class Lookup : ModuleBase
	{
		[Command("lookup")]
		[Alias("check", "search", "userinfo", "uinfo")]
		public async Task lookup(IGuildUser user)
		{
			var builder = new EmbedBuilder()
			.WithTitle($":information_source: User Info - {user.Username}({user.Nickname})")
			.WithColor(new Color(0x9D70F9))
			.WithFooter(footer =>
			{
				footer
					.WithText(user.Username + "#" + user.Discriminator)
					.WithIconUrl($"https://cdn.discordapp.com/avatars/{Context.User.Id}/{Context.User.AvatarId}.png");
			})
			.AddInlineField("Username", user.Username)
			.AddInlineField("Status", user.Status)
			.AddInlineField("Is Bot?", user.IsBot)
			.AddInlineField("Created At", user.CreatedAt)
			.AddInlineField("Joined At", user.JoinedAt);
			await ReplyAsync(string.Empty, embed: builder);
		}

	}
}
