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
    public class Purge : ModuleBase
	{
		[Command("purge")]
		[RequireUserPermission(Discord.GuildPermission.ManageMessages)]
		public async Task Purgee(int number = 0)
		{

			await Context.Message.DeleteAsync();
			if (number < 0) { return; }
			var Messages = await Context.Channel.GetMessagesAsync(number).Flatten();
			await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(Messages);
			await ReplyAsync(Context.User.Mention + $" has purged {number} message(s)");
		}

		[Command("spurge")]
		[RequireUserPermission(Discord.GuildPermission.ManageMessages)]
		public async Task SPurge(int number = 0)
		{
			await Context.Message.DeleteAsync();
			if (number < 0) { return; }
			var Messages = await Context.Channel.GetMessagesAsync(number).Flatten();
			await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(Messages);
		}
	}
}
