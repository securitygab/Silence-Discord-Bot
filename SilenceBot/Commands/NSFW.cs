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
    public class NSFW : ModuleBase
	{
		[Command("Ass")]
		[Alias("peach", "butt", "booty", "temporis")]
		[Summary("That real life shit.")]
		[RequireNsfw]
		public async Task Ass()
		{
			using (var http = new HttpClient())
			{
				var obj = JArray.Parse(await http.GetStringAsync($"http://api.obutts.ru/butts/{CryptoRandom.Next(4731)}"))[0];
				await Context.Channel.SendMessageAsync($"http://media.obutts.ru/{obj["preview"]}");
			}
		}

		[Command("boobs")]
		[Summary("Boobs")]
		[Alias("tits", "titties", "boobies", "melons", "jugs")]
		[RequireNsfw]
		public async Task Boobs()
		{
			using (var http = new HttpClient())
			{
				var obj = JArray.Parse(await http.GetStringAsync($"http://api.oboobs.ru/boobs/{CryptoRandom.Next(10738)}"))[0];
				await Context.Channel.SendMessageAsync($"http://media.oboobs.ru/{obj["preview"]}");
			}
		}
	}
}
