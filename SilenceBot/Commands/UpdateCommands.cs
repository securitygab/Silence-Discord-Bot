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
    public class SetGameStatus : ModuleBase
	{
		public DiscordSocketClient _client;

		[Command("setgame")]
		[RequireOwner]
		public async Task SetGame([Remainder]string game)
		{
			await (Context.Client as DiscordSocketClient).SetGameAsync(game);
			await ReplyAsync(Context.User.Mention + $"\nThe game has been set to {game}");
		}

		[Command("setstream")]
		[RequireOwner]
		public async Task SetStream([Remainder]string stream)
		{
			await (Context.Client as DiscordSocketClient).SetGameAsync(stream, "https://twitch.tv/kkyliee", StreamType.Twitch);
			await ReplyAsync(Context.User.Mention + $"\nThe stream has been set to {stream}");
		}

		[Command("setstatus")]
		[RequireOwner]
		public async Task SetStatus([Remainder]Discord.UserStatus status)
		{
			await (Context.Client as DiscordSocketClient).SetStatusAsync(status);
			await ReplyAsync(Context.User.Mention + $"\nThe status has been set to {status}");
		}

		[Command("updateguilds")]
		[RequireOwner]
		public async Task UpdateGuilds()
		{
			await _client.SetGameAsync($";help | dbots.cf | {_client.Guilds.Count}", "https://twitch.tv/kkyliee", StreamType.Twitch);
		}
	}
}
