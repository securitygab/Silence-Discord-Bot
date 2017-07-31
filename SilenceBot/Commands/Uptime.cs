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
    public class Uptime : ModuleBase
	{
		[Command("uptime")]
		[Summary("Returns general information about the bot")]
		public async Task Info()
		{
			DateTime startTime = Process.GetCurrentProcess().StartTime;
			TimeSpan uptime = DateTime.Now.Subtract(startTime);
			
			await ReplyAsync($"I've been awake for,\n{uptime.Humanize(5)}");
		}
	}
}
