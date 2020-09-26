using MercerAIConsolePrototype.Game_State_Mock;
using MercerAIConsolePrototype.MercerAI;
using System;
using UtilitySystem;

namespace MercerAIConsolePrototype
{
	class Program
	{
		private static Game Game;
		private static Mercer Mercer;

		static void Main(string[] args)
		{
			InitializeGame();
			ConsoleCommandLoop();
		}

		private static void InitializeGame()
		{
			Mercer = new Mercer();

			Console.WriteLine("How many tiles should this map have?");
			var tileCount = int.Parse(Console.ReadLine());

			Console.WriteLine("How many players should this game have?");
			var playerCount = int.Parse(Console.ReadLine());

			Game = new Game(tileCount, playerCount);

			var tiles1 = Game.TileSet.GetTileNames();
			foreach (string tile in tiles1)
			{
				Console.WriteLine("Tile: " + tile);
			}

			var players1 = Game.PlayerSet.GetPlayerInfo();
			foreach (string player in players1)
			{
				Console.WriteLine("Player: " + player);
			}
		}

		private static void ConsoleCommandLoop()
		{
			bool programRunning = true;
			while (programRunning)
			{
				Console.WriteLine();
				programRunning = ConsoleMenu();
			}
		}

		private static bool ConsoleMenu()
		{
			switch (Console.ReadLine())
			{
				#region Mercer

				case "scores":
					var choices = Mercer.GetScores();

					Console.WriteLine("Mercer: Here are my current scenario rankings:");
					Console.WriteLine("---------------------------");
					foreach (var choice in choices)
					{
						Console.WriteLine(choice);
					}
					Console.WriteLine("---------------------------");
					return true;
				#endregion

				#region Gameplay Events
				case "gamestate":
					Game.GetTiles();
					Game.GetPlayers();
					Game.GetItems();
					Game.GetDialogues();
					return true;

				case "round":
					Random rand = new Random();

					Console.WriteLine(Game.ItemEvent(rand.Next(0, 5)));
					Console.WriteLine(Game.DialogueEvent(rand.Next(0, 5)));
					return true;

				case "item":
					Console.WriteLine("How many?");
					var itemCount = int.Parse(Console.ReadLine());
					Console.WriteLine(Game.ItemEvent(itemCount));
					return true;

				case "items":
					Game.GetItems();
					return true;

				case "event":
					Console.WriteLine("How many?");
					var eventCount = int.Parse(Console.ReadLine());
					Console.WriteLine(Game.DialogueEvent(eventCount));
					return true;

				case "events":
					Game.GetDialogues();
					return true;
				#endregion

				#region Game Board
				case "startgame":
					InitializeGame();
					return true;

				case "tiles":
					Game.GetTiles();
					return true;

				case "players":
					Game.GetPlayers();
					return true;
				#endregion

				#region Basic Menu Commands
				case "0":
				case "clear":
					Console.Clear();
					return true;

				case "1":
				case "end":
					return false;
				#endregion

				default:
					Console.WriteLine("That was not a valid command. Please try again.");
					return true;
			}
		}
	}
}
