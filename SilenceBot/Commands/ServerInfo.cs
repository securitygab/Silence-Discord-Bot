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
	public class ServerInfo : ModuleBase
	{
		[Command("server")]
		[Summary("Get information for the current server")]
		public async Task ServerInff()
		{
			var textChannels = await Context.Guild.GetTextChannelsAsync();
			var voiceChannels = await Context.Guild.GetVoiceChannelsAsync();

			var response = new EmbedBuilder()
				.WithTitle($"Server information for {Context.Guild.Name}")
				.WithColor(new Color(0x9D70F9))
				.WithThumbnailUrl(Context.Guild.IconUrl)
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "ID";
					x.Value = Context.Guild.Id.ToString();
				})
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Created at";
					x.Value = Context.Guild.CreatedAt.UtcDateTime.ToString();
				})
				.AddField(async x =>
				{
					x.IsInline = true;
					x.Name = "Default channel";
					x.Value = (await Context.Guild.GetDefaultChannelAsync()).Mention;
				})
				.AddField(async x =>
				{
					x.IsInline = true;
					x.Name = "Owner";
					x.Value = (await Context.Guild.GetOwnerAsync()).Mention;
				})
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Voice region";
					x.Value = Context.Guild.VoiceRegionId;
				})
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Authentication level";
					x.Value = Context.Guild.MfaLevel.ToString();
				})
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Text channel count";
					x.Value = textChannels.Count().ToString();
				})
				.AddField(x =>
				{
					x.IsInline = true;
					x.Name = "Voice channel count";
					x.Value = voiceChannels.Count().ToString();
				})
				.AddField(x =>
				{
					x.IsInline = false;
					x.Name = "Text channels";
					x.Value = string.Join(", ", textChannels.Select(c => c.Name));
				})
				.AddField(x =>
				{
					x.IsInline = false;
					x.Name = "Voice channels";
					x.Value = string.Join(", ", voiceChannels.Select(c => c.Name));
				})
				.AddField(x =>
				{
					x.IsInline = false;
					x.Name = "Roles";
					x.Value = string.Join(", ", Context.Guild.Roles.Select(r => r.Name));
				});
			await ReplyAsync("", embed: response);
		}
	}
}
