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
    public class Help : ModuleBase
	{
		[Command("help")]
		public async Task helpCommand()
		{
			var channel = await Context.User.GetOrCreateDMChannelAsync();

			var builder = new EmbedBuilder()
			.WithTitle("Silence Commands")
			.WithColor(new Color(0x9D70F9))
			.WithFooter(footer =>
			{
				footer
				.WithText($"Coded by xtDie#0201 | {Context.User.Username} | {Context.Guild.Name}")
				.WithIconUrl("https://cdn.discordapp.com/avatars/202236922217758721/3361e52befe6a2f7f31475aa2d424be6.png");
			})
			.AddInlineField("General", "help - Sends you this menu\nBotInfo - Shows info on Silence\ndab - Will return an image of squidward dabbing\nbluescreen - We ran into a problem...\ncoinflip - Flip the coin (CT or T)\ninvite - Get an invite link for the bot to join your own guild!\nComingSoon - What is planned to be added to Silence\ncreator - Who created Silence ")
			.AddInlineField("Utility", "Ping - Shows the bots latency\nUptime - Shows the bots uptime\nChannelInfo - Shows info on the current channel\nlookup <user> - Lookup a user in the guild\nserver - Shows info on the current guild\nurban - Look up a word in the urban dictionary")
			.AddInlineField("NSFW", "Ass - Random ass pic\nBoobs - Random boobs pic")
			.AddInlineField("Moderation", "ban <User>\n(Permission: Ban Users)\n\nkick <User> - Kicks a user\n(Permission: Kick Users)\n\npurge <amount> - Purges specified amount of messages\n(Permission: Manage Messages)\n\nspurge - Silently purge specified amount of messages\n(Permission: Manage Messages)")
			.AddInlineField("Additional", "Feel free to join the discord for anymore assistance");
			var embed = builder.Build();


			var builder2 = new EmbedBuilder()
			{
				Color = new Color(0x00FF00),
				Title = ":white_check_mark:",
				Description = Context.User.Mention + ", You have been sent the command list!"
			};
			//		await channel.SendMessageAsync("https://discord.gg/98WGT85", embed: builder);
			await ReplyAsync(string.Empty, embed: builder2);
			await channel.SendMessageAsync(string.Empty, embed: builder);
		}
	}
}
