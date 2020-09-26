using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Players
{
	public class PlayerSet : GameEntityCategory<Player>
	{
		public PlayerSet(int playerCount) : base(playerCount)
		{
			InitializePlayerPool();
			GeneratePlayers(playerCount);
		}

		private void InitializePlayerPool()
		{
			var playerPool = new List<Player>();
			playerPool.Add(new Player("Dekori", "Archery", "Fire"));
			playerPool.Add(new Player("Arcaerus", "Shadow", "Empathy"));
			playerPool.Add(new Player("Hangrysaurus", "Archery", "Water"));
			playerPool.Add(new Player("DandyLion", "Martial", "Diplomacy"));
			playerPool.Add(new Player("Sloth", "Survivalism", "Target Arts"));
			playerPool.Add(new Player("Marci", "Thievery", "Fire"));
			playerPool.Add(new Player("Keith", "Thievery", "Biomancy"));
			InitializeEntityPool(playerPool);
		}

		private void GeneratePlayers(int playerCount)
		{
			GenerateEntities(playerCount);
		}

		public List<string> GetPlayerInfo()
		{
			var playerInfo = new List<string>();

			foreach (var player in Entities)
			{
				playerInfo.Add(player.Name + ": " + player.Class1 + "/" + player.Class2);
			}

			return playerInfo;
		}

		public List<Player> GetPlayers()
		{
			return Entities;
		}
	}
}
