using MercerAIConsolePrototype.MercerAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Tiles
{
	public class Tile : IMercerTrackable, IEntity
	{
		public static List<int> locations = new List<int> { 1, 4, 2, 6, 5, 9, 11, 13, 2, 7, 6, 9, 0, 2, 3 };
		public string Name { get; set; }
		public int Location { get; set; }

		public Tile(string name)
		{
			Name = name;

			var rand = new Random();

			Location = locations[rand.Next(0, locations.Count - 1)];
		}
	}
}
