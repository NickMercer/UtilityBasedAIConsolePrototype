using System;
using System.Collections.Generic;
using System.Text;
using MercerAIConsolePrototype.Game_State_Mock.Tiles;
using MercerAIConsolePrototype.Game_State_Mock.Dialogues;
using MercerAIConsolePrototype.Game_State_Mock.Items;
using MercerAIConsolePrototype.Game_State_Mock.Players;
using UtilitySystem;
using MercerAIConsolePrototype.Events;

namespace MercerAIConsolePrototype.Game_State_Mock
{
	public class Game
	{
		public TileSet TileSet;
		public PlayerSet PlayerSet;
		public ItemSet ItemSet;
		public DialogueSet DialogueSet;

		public Game(int tileCount, int playerCount)
		{
			TileSet = new TileSet(tileCount);
			PlayerSet = new PlayerSet(playerCount);
			ItemSet = new ItemSet();
			DialogueSet = new DialogueSet();

			GameStartEvent startEvent = new GameStartEvent
			{
				TileSet = TileSet.GetTiles(),
				PlayerSet = PlayerSet.GetPlayers()
			};
			startEvent.FireEvent();
		}

		public string ItemEvent(int itemCount)
		{
			return ItemSet.GenerateItems(itemCount);
		}

		public string DialogueEvent(int dialogueCount)
		{
			return DialogueSet.GenerateDialogues(dialogueCount);
		}

		public void GetTiles()
		{
			var tiles = TileSet.GetTileNames();

			foreach(string tile in tiles)
			{
				Console.WriteLine($"Tile: {tile}");
			}
		}

		public void GetPlayers()
		{
			var players = PlayerSet.GetPlayerInfo();

			foreach (string player in players)
			{
				Console.WriteLine(player);
			}
		}

		public void GetItems()
		{
			var items = ItemSet.GetItemInfo();
			foreach (string item in items)
			{
				Console.WriteLine("Item: " + item);
			}
		}

		public void GetDialogues()
		{
			var dialogues = DialogueSet.GetDialogueInfo();
			foreach (string item in dialogues)
			{
				Console.WriteLine("Event: " + item);
			}
		}
	}
}
