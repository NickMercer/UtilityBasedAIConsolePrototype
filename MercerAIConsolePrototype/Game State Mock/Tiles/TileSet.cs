using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Tiles
{
	public class TileSet : GameEntityCategory<Tile>
	{
		public TileSet(int tileCount) : base(tileCount)
		{
			InitializeTilePool();
			GenerateBoard(tileCount);
		}

		private void InitializeTilePool()
		{
			var tilePool = new List<Tile>();
			tilePool.Add(new Tile("Elfsong Tavern"));
			tilePool.Add(new Tile("Gray Harbor"));
			tilePool.Add(new Tile("Hall of Wonders"));
			tilePool.Add(new Tile("Rose Portal"));
			tilePool.Add(new Tile("Sorcerous Sundries"));
			tilePool.Add(new Tile("Kitchen"));
			tilePool.Add(new Tile("Kitchen Basement"));
			tilePool.Add(new Tile("Catacomb Landing"));
			tilePool.Add(new Tile("Beloved Ranger Statue"));
			tilePool.Add(new Tile("Trash Pile"));
			tilePool.Add(new Tile("Ambush Alley"));
			tilePool.Add(new Tile("Trading Post"));
			tilePool.Add(new Tile("Shrine to Bhaal"));
			tilePool.Add(new Tile("Cursed Statue"));
			tilePool.Add(new Tile("Pit Trap"));
			tilePool.Add(new Tile("Rat Den"));
			InitializeEntityPool(tilePool);
		}

		private void GenerateBoard(int tileCount)
		{
			GenerateEntities(tileCount);
		}

		public List<string> GetTileNames()
		{
			return GetEntityNames();
		}

		public List<Tile> GetTiles()
		{
			return Entities;
		}
	}
}
