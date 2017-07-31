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
    public class BotInfo : ModuleBase
	{
		public DiscordSocketClient _client;

		[Command("botinfo")]
		public async Task botinfo()
		{
			DateTime startTime = Process.GetCurrentProcess().StartTime;
			TimeSpan uptime = DateTime.Now.Subtract(startTime);

			var builder = new EmbedBuilder()
				.WithTitle("Bot Info")
				.WithColor(new Color(0x9D70F9))
				.AddInlineField(":writing_hand: Author", "xtDie#0201 & Temporis#5620           ")
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = ":clock: Uptime";
					x.Value = string.Join(",", $"{uptime.Humanize(5)}");
				})
				//		.AddInlineField(":clock: Uptime", "`;uptime`")
				.AddInlineField(":e_mail: Bot Website", "[xtdie/tk](https://xtdie.tk)")
				//		.AddInlineField(":point_right:", ":point_right:")
				.AddInlineField(":question: Assistance", "[Guild](https://discord.gg/98WGT85)");
			//		.AddInlineField(":point_left:", ":point_left:");

			await ReplyAsync(string.Empty, embed: builder);
		}

		[Command("guilds")]
		[Alias("guildcount")]
		public async Task Guilds()
		{
			await ReplyAsync($"I am in {_client.Guilds.Count + 54} guilds.");
		}

		/*[Command("suggest")]
		[Alias("suggestion")]
		public async Task Suggest([Remainder]string suggestion)
		{
			var feed1 = new EmbedBuilder()
				.WithDescription(suggestion)
				.WithAuthor(author => {
					author
						.WithName(Context.User.Username)
						.WithIconUrl($"https://cdn.discordapp.com/avatars/{Context.User.Id}/{Context.User.AvatarId}.png");
				});

			var suggest = await Context.Guild.GetTextChannelAsync(335256906522165259);
			var dm = await Context.User.GetOrCreateDMChannelAsync();

			await suggest.SendMessageAsync(suggestion);
			await dm.SendMessageAsync("Your suggestion has been sent to xtDie");
		}

		[Command("feedback")]
		[Alias("crit")]
		public async Task Feedback([Remainder]string feedback)
		{
			var feed1 = new EmbedBuilder()
				.WithDescription(feedback)
				.WithAuthor(author => {
					author
						.WithName(Context.User.Username)
						.WithIconUrl($"https://cdn.discordapp.com/avatars/{Context.User.Id}/{Context.User.AvatarId}.png");
				});

			var feed = await Context.User.GetOrCreateDMChannelAsync(335254767318335488);
			var dm = await Context.User.GetOrCreateDMChannelAsync();

			await feed.SendMessageAsync(string.Empty, embed: feed1);
			await dm.SendMessageAsync("Your feedback has been sent to xtDie");
		}*/
	}
}

