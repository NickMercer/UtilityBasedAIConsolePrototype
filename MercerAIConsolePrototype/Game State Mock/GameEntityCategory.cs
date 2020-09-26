using MercerAIConsolePrototype.Utilities;
using System;
using System.Collections.Generic;
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

			foreach (var entity in Entities)
			{
				entityNames.Add(entity.Name);
			}

			return entityNames;
		}

		protected List<TEntity> GetEntities()
		{
			return Entities;
		}
	}
}
