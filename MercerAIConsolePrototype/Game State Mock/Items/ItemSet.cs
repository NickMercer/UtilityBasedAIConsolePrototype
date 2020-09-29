using MercerAIConsolePrototype.Events;
using MercerAIConsolePrototype.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Items
{
	public class ItemSet : GameEntityCategory<Item>
	{
		public ItemSet() : base()
		{
			InitializeItemPool();
		}

		private void InitializeItemPool()
		{
			var itemPool = new List<Item>();
			itemPool.Add(new Item("Teleportation Gloves", new List<Tag> { Tag.Arcane, Tag.Armor, Tag.Mages }));
			itemPool.Add(new Item("Staff of Bhaal", new List<Tag> { Tag.Bhaal, Tag.Cultists, Tag.Weapon }));
			itemPool.Add(new Item("Crossbow", new List<Tag> { Tag.Weapon, Tag.Hunters }));
			itemPool.Add(new Item("Eye of Magus", new List<Tag> { Tag.Arcane, Tag.Weapon, Tag.Mages }));
			itemPool.Add(new Item("Elder Scroll", new List<Tag> { Tag.Arcane, Tag.OtherDimension }));
			itemPool.Add(new Item("Goblin Food", new List<Tag> { Tag.Hunters }));
			itemPool.Add(new Item("Troll Horn"));
			itemPool.Add(new Item("The Flameseeker Prophecies", new List<Tag> { Tag.Cultists, Tag.Arcane }));
			itemPool.Add(new Item("Sacred Flame", new List<Tag> { Tag.Cultists, Tag.Mages, Tag.Arcane }));
			itemPool.Add(new Item("Golden Fish", new List<Tag> { Tag.Thieves }));
			itemPool.Add(new Item("The One Ring", new List<Tag> { Tag.Thieves }));
			itemPool.Add(new Item("Murgyr Flesh", new List<Tag> { Tag.Bhaal, Tag.Catacombs, Tag.Arcane, Tag.Cultists }));
			itemPool.Add(new Item("Guard's Insignia", new List<Tag> { Tag.CityGuard, Tag.Ambassador}));
			itemPool.Add(new Item("Amulet of Kings", new List<Tag> { Tag.Ambassador }));
			itemPool.Add(new Item("Hand of Vecna", new List<Tag> { Tag.Cultists, Tag.Weapon, Tag.Arcane }));
			itemPool.Add(new Item("Wyrmstooth", new List<Tag> { Tag.Weapon, Tag.Noble, Tag.Hunters }));
			InitializeEntityPool(itemPool);
		}


		public string GenerateItem(List<Tag> tags = null)
		{
			if(EntityPool.Count == 0)
			{
				return "There are no items left.";
			}

			Item item;

			if(tags == null)
			{
				EntityPool.Shuffle();

				item = EntityPool[0];
			}
			else
			{
				item = GetAppropriate(tags, 70);
			}

			Entities.Add(item);

			ItemAddEvent itemEvent = new ItemAddEvent
			{
				Item = item
			};
			itemEvent.FireEvent();

			EntityPool.Remove(item);

			if (item != null)
				return $"Added item: {item.Name}.";
			else
				return "Unable to add item.";
		}

		public List<string> GetItemInfo()
		{
			return GetEntityNames();
		}

		public List<Item> GetItems()
		{
			return Entities;
		}
	}
}
