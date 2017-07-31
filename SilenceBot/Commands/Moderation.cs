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
    public class Moderation : ModuleBase
	{
		[Command("ban")]
		[RequireUserPermission(Discord.GuildPermission.BanMembers)]
		[RequireBotPermission(Discord.GuildPermission.BanMembers)]
		public async Task banCommand(IGuildUser userToBan, [Remainder] string reason = "Unspecified.")
		{
			if (userToBan.GuildPermissions.BanMembers)
			{
				var builder = new EmbedBuilder()
				{
					Color = new Color(0xFF0000),
					Title = ":x: Error",
					Description = Context.User.Mention + ", **You cannot ban another staff member.**"
				};
				await ReplyAsync(String.Empty, embed: builder);
			}
			if (userToBan.Id == Context.User.Id)
			{
				var builder = new EmbedBuilder()
				{
					Color = new Color(0xFF0000),
					Title = ":x: Error",
					Description = Context.User.Mention + ", **You cannot ban yourself from the guild.**"
				};
				await ReplyAsync(String.Empty, embed: builder);
			}
			var channel = await userToBan.GetOrCreateDMChannelAsync();
			await channel.SendMessageAsync($"You have been banned from {Context.Guild.Name}");
			await Context.Guild.AddBanAsync(userToBan);
			var builder3 = new EmbedBuilder()
			{
				Color = new Color(0xFF00FF),
				Title = "Information",
				Description = "You have been banned from the guild by " + Context.User.Username
			};
			await channel.SendMessageAsync(String.Empty, embed: builder3);
			var builder2 = new EmbedBuilder()
			{
				Color = new Color(0x00FF00),
				Title = "Success",
				Description = Context.User.Mention + ", Successfully banned " + userToBan
			};
			await ReplyAsync(String.Empty, embed: builder2);
		}

		/*	[Command("unban")]
			[RequireUserPermission(Discord.GuildPermission.BanMembers)]
			[RequireBotPermission(Discord.GuildPermission.BanMembers)]
			public async Task unbanCommand([Remainder]IUser id)
			{
				await Context.Guild.RemoveBanAsync(id);
				await ReplyAsync($"Successfully unbanned {id} from the {Context.Guild.Name} discord.");
			}*/

		[Command("kick")]
		[RequireUserPermission(Discord.GuildPermission.KickMembers)]
		[RequireBotPermission(Discord.GuildPermission.KickMembers)]
		public async Task kickCommand(IGuildUser userToKick, [Remainder] string reason = "Unspecified.")
		{
			if (userToKick.GuildPermissions.KickMembers)
			{
				var builder = new EmbedBuilder()
				{
					Color = new Color(0xFF0000),
					Title = ":x: Error",
					Description = Context.User.Mention + ", **You cannot kick another staff member.**"
				};
				await ReplyAsync(String.Empty, embed: builder);
			}
			if (userToKick.Id == Context.User.Id)
			{
				var builder = new EmbedBuilder()
				{
					Color = new Color(0xFF0000),
					Title = "Command Error",
					Description = Context.User.Mention + ", **You cannot kick yourself.**"
				};
				await ReplyAsync(String.Empty, embed: builder);
			}
			var channel = await userToKick.GetOrCreateDMChannelAsync();
			await channel.SendMessageAsync($"You have been kicked from {Context.Guild.Name}");
			await userToKick.KickAsync();
			var builder2 = new EmbedBuilder()
			{
				Color = new Color(0x00FF00),
				Title = "Success",
				Description = Context.User.Mention + ", Successfully kicked " + userToKick
			};
			await ReplyAsync(String.Empty, embed: builder2);
		}
	}
}
