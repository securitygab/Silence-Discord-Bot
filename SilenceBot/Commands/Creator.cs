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
    public class Creator : ModuleBase
    {
		[Command("creator")]
		public async Task SendCreator()
		{
			var builder = new EmbedBuilder()
			.WithColor(new Color(0x9D70F9))
			.WithFooter(footer => {
				footer
				.WithText("Coded by xtDie#0201")
				.WithIconUrl("https://cdn.discordapp.com/avatars/202236922217758721/3361e52befe6a2f7f31475aa2d424be6.png");
			})
			.WithAuthor(author => {
				author
				.WithName(Context.User.Username)
				.WithIconUrl("https://cdn.discordapp.com/avatars/" + Context.User.Id + "/" + Context.User.AvatarId + ".png");
			})
			.AddInlineField("Developer", "xtDie#0201")
			.AddInlineField("Contact", "[http://xtdie.me](http://xtdie.me/socialmedia.html)");

			await ReplyAsync(string.Empty, embed: builder);
		}
	}
}
