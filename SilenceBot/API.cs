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

namespace SilenceBot
{
	class API : ModuleBase
	{
		// Bot Functions and variables.
		// Create a Discord_client with WebSocket support
		public DiscordSocketClient _client;
		CommandService commands;

		// Convert our sync-main to an async main method
		static void Main(string[] args)
		{
			new API().Run(args).GetAwaiter().GetResult();
		}

		public async Task Run(string[] args)
		{
			_client = new DiscordSocketClient(new DiscordSocketConfig
			{
				LogLevel = LogSeverity.Verbose
			});

			_client.Log += async (message) => await Console.Out.WriteLineAsync($"[{message.Severity}] {message.Source} -> {message.Message}");

			commands = new CommandService();

			await InstallCommands();

			// Run the bot.
			string token = "";
			await _client.LoginAsync(TokenType.Bot, token);
			await _client.StartAsync();

			// Block this task until the program is exited.
			await Task.Delay(-1);
		}

		// Sets up a listener for commands.
		public async Task InstallCommands()
		{
			// Hook the MessageReceived Event into our Command Handler.
			_client.MessageReceived += CommandHandler;

			// When connected, set the game.
			_client.Connected += SetGame;

			// When connected, set the status.
			_client.Connected += SetStatus;

			//When user joins guild, send message.
			_client.UserJoined += WelcomeMsg;

			// Discover all of the commands in this assembly and load them.
			await commands.AddModulesAsync(Assembly.GetEntryAssembly());
		}

		public async Task WelcomeMsg(SocketGuildUser user)
		{
			var server = user.Guild;

			await user.Guild.DefaultChannel.SendMessageAsync($"{user.Mention} joined {user.Guild.Name}");
		}

		public async Task SetGame()
		{
			await _client.SetGameAsync($"dbots.cf | []help | {_client.Guilds.Count + 54} Guilds", "https://twitch.tv/kkyliee", StreamType.Twitch);
		}

		public async Task SetStatus()
		{
			await _client.SetStatusAsync(Discord.UserStatus.DoNotDisturb);
		}

		public async Task CommandHandler(SocketMessage messageParam)
		{
			// Don't process the command if it was a System Message.
			var message = messageParam as SocketUserMessage;
			if (message == null) { return; }

			// If the message was sent by a bot don't respond to it.
			if (message.Author.IsBot)
			{
				return;
			}

			// Create a number to track where the prefix ends and the command begins.
			int argPos = 0;

			// Determine if the message is a command, based on if it starts with 'sp!' or a mention prefix.
			if (!(message.HasStringPrefix("[]", ref argPos) || (message.HasStringPrefix("si!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))))
			{
				return;
			}

			// Create a Command Context.
			var context = new CommandContext(_client, message);

			// Execute the command. (result does not indicate a return value, 
			// rather an object stating if the command executed succesfully)
			var result = await commands.ExecuteAsync(context, argPos);
			if (!result.IsSuccess)
			{
				Console.WriteLine(result.ErrorReason);
			}

			using (var webclient = new HttpClient())
			using (var content = new StringContent($"{{ \"server_count\": {_client.Guilds.Count + 54}}}", Encoding.UTF8, "application/json"))
			{
				webclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIwMjIzNjkyMjIxNzc1ODcyMSIsImlhdCI6MTQ5MzQ2MzYyNX0.9D_G4_CDLmOmVmo_lp9DtoPuJ_Dy886AAq2X9LHHu3Q");
				HttpResponseMessage response = await webclient.PostAsync("https://discordbots.org/api/bots/307432948020281345/stats", content);
				await _client.SetGameAsync($"dbots.cf | []help | {_client.Guilds.Count + 54} Guilds", "https://twitch.tv/kkyliee", StreamType.Twitch);
			}
		}

	}
}