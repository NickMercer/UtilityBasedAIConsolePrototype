using MercerAIConsolePrototype.Events;
using MercerAIConsolePrototype.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Dialogues
{
	public class DialogueSet : GameEntityCategory<Dialogue>
	{
		public DialogueSet() : base()
		{
			InitializeDialoguePool();
		}

		private void InitializeDialoguePool()
		{
			var dialoguePool = new List<Dialogue>();
			dialoguePool.Add(new Dialogue("Hunt the Bhaal Priests"));
			dialoguePool.Add(new Dialogue("The Hunter's Lodge Festivities"));
			dialoguePool.Add(new Dialogue("Alleyway Robbery"));
			dialoguePool.Add(new Dialogue("Into the Catacombs"));
			dialoguePool.Add(new Dialogue("Forbidden Knowledge"));
			dialoguePool.Add(new Dialogue("Ranger's Guild Initiation"));
			dialoguePool.Add(new Dialogue("Sewer Troll"));
			dialoguePool.Add(new Dialogue("The Arcaneum Mystery"));
			dialoguePool.Add(new Dialogue("Flame Cultists"));
			dialoguePool.Add(new Dialogue("Sarlaac"));
			dialoguePool.Add(new Dialogue("The Halflings"));
			dialoguePool.Add(new Dialogue("Night Music"));
			dialoguePool.Add(new Dialogue("The Ambassador's Visit"));
			dialoguePool.Add(new Dialogue("To the Palace"));
			dialoguePool.Add(new Dialogue("Vecna's Legend"));
			dialoguePool.Add(new Dialogue("Dragon Killer"));
			InitializeEntityPool(dialoguePool);
		}

		public string GenerateDialogues(int dialogueCount)
		{
			if (EntityPool.Count < dialogueCount)
			{
				dialogueCount = EntityPool.Count;
				Console.WriteLine("Not enough events to trigger. Triggering the remaining (" + dialogueCount.ToString() + ") events instead.");
			}

			EntityPool.Shuffle();

			StringBuilder returnSB = new StringBuilder();
			returnSB.Append("Events triggered in game: ");

			for (var i = 0; i < dialogueCount; i++)
			{
				var dialogue = EntityPool[0];

				Entities.Add(dialogue);

				DialogueAddEvent dialogueEvent = new DialogueAddEvent
				{
					Dialogue = dialogue
				};
				dialogueEvent.FireEvent();

				EntityPool.Remove(dialogue);

				returnSB.Append(dialogue.Name + ", ");
			}

			return returnSB.ToString();
		}

		public List<string> GetDialogueInfo()
		{
			return GetEntityNames();
		}

		public List<Dialogue> GetDialogues()
		{
			return Entities;
		}
	}
}
