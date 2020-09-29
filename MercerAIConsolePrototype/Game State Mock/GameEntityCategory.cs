using MercerAIConsolePrototype.MercerAI;
using MercerAIConsolePrototype.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock
{
	public class GameEntityCategory<TEntity> where TEntity : IEntity
	{
		protected List<TEntity> EntityPool = new List<TEntity>();
		protected List<TEntity> Entities = new List<TEntity>();

		public GameEntityCategory()
		{

		}

		public GameEntityCategory(int entityCount)
		{
		}

		protected void InitializeEntityPool(List<TEntity> prepPool)
		{
			foreach (var item in prepPool)
			{
				EntityPool.Add(item);
			}
		}

		protected void GenerateEntities(int entityCount)
		{
			if (entityCount > EntityPool.Count)
			{
				Console.WriteLine($"Not enough {typeof(TEntity).Name}s to create amount given. Creating maximum amount.");
				entityCount = EntityPool.Count;
			}

			EntityPool.Shuffle();

			for (var i = 0; i < entityCount; i++)
			{
				Entities.Add(EntityPool[i]);
			}
		}

		protected List<string> GetEntityNames()
		{
			var entityNames = new List<string>();

			foreach (TEntity entity in Entities)
			{
				entityNames.Add(entity.Name);
			}

			return entityNames;
		}

		protected List<TEntity> GetEntities()
		{
			return Entities;
		}

		protected TEntity GetAppropriate(List<Tag> tags, int appropriateItemPercentage = 100)
		{
			tags = tags.Distinct().ToList();

			var orderedEntities = EntityPool.Where(x => x.Tags != null).OrderByDescending(x => x.Tags.Count()).Where(x => x.Tags.Intersect(tags).Count() > 0).ToList();

			orderedEntities.Shuffle();

			var rand = new Random();

			var num = rand.Next(0, 100);

			if (orderedEntities.Count > 0 && num < appropriateItemPercentage)
				return orderedEntities[0];
			else if(EntityPool.Count > 0)
			{
				EntityPool.Shuffle();
				return EntityPool[0];
			}
			else
			{
				return default;
			}
				
		}
	}
}
