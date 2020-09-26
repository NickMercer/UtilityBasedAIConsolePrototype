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
			itemPool.Add(new Item("Teleportation Gloves"));
			itemPool.Add(new Item("Staff of Bhaal"));
			itemPool.Add(new Item("Crossbow"));
			itemPool.Add(new Item("Eye of Magus"));
			itemPool.Add(new Item("Elder Scroll"));
			itemPool.Add(new Item("Goblin Food"));
			itemPool.Add(new Item("Troll Horn"));
			itemPool.Add(new Item("The Flameseeker Prophecies"));
			itemPool.Add(new Item("Sacred Flame"));
			itemPool.Add(new Item("Golden Fish"));
			itemPool.Add(new Item("The One Ring"));
			itemPool.Add(new Item("Murgyr Flesh"));
			itemPool.Add(new Item("Guard's Insignia"));
			itemPool.Add(new Item("Amulet of Kings"));
			itemPool.Add(new Item("Hand of Vecna"));
			itemPool.Add(new Item("Wyrmstooth"));
			InitializeEntityPool(itemPool);
		}

		public string GenerateItems(int itemCount)
		{
			if (EntityPool.Count < itemCount)
			{
				itemCount = EntityPool.Count;
				Console.WriteLine("Not enough items to give. Giving the remaining (" + itemCount.ToString() + ") items instead.");
			}

			EntityPool.Shuffle();

			StringBuilder returnSB = new StringBuilder();
			returnSB.Append("Items added to game: ");

			for (var i = 0; i < itemCount; i++)
			{
				var item = EntityPool[0];

				Entities.Add(item);

				ItemAddEvent itemEvent = new ItemAddEvent
				{
					Item = item
				};
				itemEvent.FireEvent();

				EntityPool.Remove(item);

				returnSB.Append(item.Name + ", ");
			}

			return returnSB.ToString();
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
