using MercerAIConsolePrototype.Game_State_Mock.Players;
using MercerAIConsolePrototype.Game_State_Mock.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Events
{
	public class GameStartEvent : Event<GameStartEvent>
	{
		public List<Tile> TileSet { get; set; } = new List<Tile>();
		public List<Player> PlayerSet { get; set; } = new List<Player>();
	}
}
