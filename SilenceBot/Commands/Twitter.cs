using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;
using SilenceBot.Commands;
using SilenceBot.Services;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace SilenceBot.Commands
{
    public class Twitter : ModuleBase
    {
		public DiscordSocketClient _client;

		[Command("tweet")]
		[RequireOwner]
		public async Task Tweet([Remainder]string tweet)
		{
			using (var webclient = new HttpClient())
			using (var content = new StringContent($"{tweet}", Encoding.UTF8, "application/json"))
			{
				webclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("v0dpfCTvN9ceQX8bKnLzyX7PMRIa9ZHmlRv2feVWZgbNg");
				HttpResponseMessage response = await webclient.GetAsync($"https://api.twitter.com/1.1/statuses/update.json?status={content}");
			}
		}
    }
}
