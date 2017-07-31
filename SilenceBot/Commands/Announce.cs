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
    public class Announce : ModuleBase
    {
		[Command("announce")]
		[RequireOwner]
		public async Task Announcement([Remainder]string content)
		{
			var guilds = await Context.Client.GetGuildsAsync();
			var channel = await Context.User.GetOrCreateDMChannelAsync();

			var builder = new EmbedBuilder()
				.WithTitle("Announcement")
				.WithDescription(content)
				.WithColor(new Color(0x9D70F9))
				.WithFooter(footer => {
					footer
						.WithText(Context.User.Username)
						.WithIconUrl($"https://cdn.discordapp.com/avatars/{Context.User.Id}/{Context.User.AvatarId}.png");
				});

			foreach (SocketGuild g in guilds)
			{
				try
				{
					await g.DefaultChannel.SendMessageAsync(string.Empty, embed: builder);
				}
				catch (Exception e)
				{
					await channel.SendMessageAsync("No perms to talk in\n" + g.Name);
				}
			}
		}
    }
}
