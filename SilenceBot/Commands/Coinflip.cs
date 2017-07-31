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
    public class Coinflip : ModuleBase
	{
		[Command("coinflip")]
		[Alias("cf")]
		public async Task FlipCoin()
		{
			string[] Coinflip = new string[]
			{
				":dvd:", // 0
				":cd:", // 1
            };

			using (Context.Channel.EnterTypingState())
			{
				int randomCoin = new Random().Next(Coinflip.Length);
				await ReplyAsync(Coinflip[randomCoin]);
			}
		}
	}
}
