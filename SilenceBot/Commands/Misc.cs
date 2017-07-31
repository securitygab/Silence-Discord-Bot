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
    public class Misc : ModuleBase
	{
		[Command("ping")]
		public async Task Ping()
		{
			await ReplyAsync($":stopwatch: **Pong!** My ping is currently {(Context.Client as DiscordSocketClient).Latency.ToString()}ms.");
		}

		[Command("comingsoon")]
		public async Task ComingSoon()
		{
			var channel = await Context.User.GetOrCreateDMChannelAsync();

			var comingsoon1 = new EmbedBuilder()
				.WithColor(new Color(0x31B1D5))
				.AddInlineField("Command", "Unban")
				.AddInlineField("Progress", "Just Started");

			await Context.Message.DeleteAsync();
			await channel.SendMessageAsync(string.Empty, embed: comingsoon1);
		}

		[Command("invite")]
		public async Task invite()
		{
			var channel = await Context.User.GetOrCreateDMChannelAsync();

			var invite1 = new EmbedBuilder()
			{
				Color = new Color(0x9D70F9),
				Title = "Invite",
				Description = "Click the link below to add **Silence** to your guild!" + "\n\nhttps://dbots.cf/SilenceBots"
			};

			var invite2 = new EmbedBuilder()
			{
				Color = new Color(0x9D70F9),
				Title = "Invite",
				Description = "You have been sent the invite link in your direct messages!"
			};

			await ReplyAsync(string.Empty, embed: invite2);
			await channel.SendMessageAsync(string.Empty, embed: invite1);
		}

		[Command("bluescreen")]
		[Alias("crash", "windowserror", "error")]
		public async Task BlueScreen()
		{
			await Context.Channel.SendFileAsync("images/windows-8-blue-screen-error.png");
		}

		[Command("urban")]
		public async Task Urban([Remainder]string word)
		{
			var urban1 = new EmbedBuilder()
				.WithDescription($"[{word}](http://www.urbandictionary.com/define.php?term={word})")
				.WithColor(new Color(0x9D70F9))
				.WithAuthor(author => {
					author
						.WithName("Urban Dictionary")
						.WithIconUrl("http://xtdie.me/botimg/urban.png");
				});

			await ReplyAsync(string.Empty, embed: urban1);
		}

		[Command("love")]
		public async Task love()
		{
			var love1 = new EmbedBuilder()
				.WithDescription($"__*noun*__\n\n**1.** a strong feeling of affection\n*'babies fill parents with intense feelings of love'*\n\n**2.** a great interest and pleasure in something.\n*'his love for football'*\n\n__*verb*__\n\n**1.** feel deep affection or sexual love for (someone)\n*'do you love me?'*")
				.WithColor(new Color(0x9D70F9))
				;

			await ReplyAsync(string.Empty, embed: love1);
		}
	}
}
