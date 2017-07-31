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
    public class Dab : ModuleBase
	{
		[Command("dab")]
		public async Task SendDab()
		{
			// Typing is good to use for image sending.
			using (Context.Channel.EnterTypingState())
			{
				await Context.Channel.SendFileAsync("../images/dab.gif");
			}
		}
	}
}
