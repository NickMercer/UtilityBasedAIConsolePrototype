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
			tilePool.Add(new Tile("Elfsong Tavern", new List<Tag> { Tag.Indoor }));
			tilePool.Add(new Tile("Gray Harbor", new List<Tag> { Tag.Underground, Tag.Catacombs }));
			tilePool.Add(new Tile("Hall of Wonders", new List<Tag> { Tag.Mages, Tag.Arcane }));
			tilePool.Add(new Tile("Rose Portal", new List<Tag> { Tag.Ambassador, Tag.Noble }));
			tilePool.Add(new Tile("Sorcerous Sundries", new List<Tag> { Tag.Arcane, Tag.Mages, Tag.Cultists }));
			tilePool.Add(new Tile("Kitchen", new List<Tag> { Tag.Indoor }));
			tilePool.Add(new Tile("Kitchen Basement", new List<Tag> { Tag.Indoor, Tag.Underground }));
			tilePool.Add(new Tile("Catacomb Landing", new List<Tag> { Tag.Underground, Tag.Catacombs }));
			tilePool.Add(new Tile("Beloved Ranger Statue", new List<Tag> { Tag.Hunters, Tag.Outdoor, Tag.Noble, Tag.Street }));
			tilePool.Add(new Tile("Trash Pile", new List<Tag> { Tag.Street, Tag.Outlaw, Tag.Outdoor }));
			tilePool.Add(new Tile("Ambush Alley", new List<Tag> { Tag.Thieves, Tag.Outdoor, Tag.Outlaw, Tag.Street }));
			tilePool.Add(new Tile("Trading Post", new List<Tag> { Tag.Ambassador, Tag.Thieves, Tag.Noble }));
			tilePool.Add(new Tile("Shrine to Bhaal", new List<Tag> { Tag.Bhaal, Tag.Cultists, Tag.Catacombs, Tag.Underground }));
			tilePool.Add(new Tile("Cursed Statue", new List<Tag> { Tag.Bhaal, Tag.Arcane, Tag.Catacombs, Tag.Cultists, Tag.Indoor }));
			tilePool.Add(new Tile("Pit Trap", new List<Tag> { Tag.Thieves, Tag.Underground }));
			tilePool.Add(new Tile("Rat Den", new List<Tag> { Tag.Thieves,  Tag.Outlaw, Tag.Catacombs, Tag.Underground }));
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
