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
			dialoguePool.Add(new Dialogue("Hunt the Bhaal Priests", new List<Tag> { Tag.Bhaal, Tag.Street }));
			dialoguePool.Add(new Dialogue("The Hunter's Lodge Festivities", new List<Tag> { Tag.Indoor, Tag.Hunters }));
			dialoguePool.Add(new Dialogue("Alleyway Robbery", new List<Tag> { Tag.Outdoor, Tag.Street, Tag.Outlaw, Tag.Thieves }));
			dialoguePool.Add(new Dialogue("Into the Catacombs", new List<Tag> { Tag.Catacombs, Tag.Underground, Tag.Cultists, Tag.Thieves, Tag.Outlaw }));
			dialoguePool.Add(new Dialogue("Forbidden Knowledge", new List<Tag> { Tag.Cultists, Tag.Bhaal, Tag.Catacombs }));
			dialoguePool.Add(new Dialogue("Ranger's Guild Initiation", new List<Tag> { Tag.Hunters, Tag.Outdoor}));
			dialoguePool.Add(new Dialogue("Sewer Troll", new List<Tag> { Tag.Underground, Tag.Hunters, Tag.Catacombs }));
			dialoguePool.Add(new Dialogue("The Arcaneum Mystery", new List<Tag> { Tag.Mages, Tag.Arcane, Tag.Indoor }));
			dialoguePool.Add(new Dialogue("Flame Cultists", new List<Tag> { Tag.Cultists, Tag.Catacombs, Tag.Underground }));
			dialoguePool.Add(new Dialogue("Sarlaac", new List<Tag> { Tag.Hunters, Tag.Outdoor }));
			dialoguePool.Add(new Dialogue("The Halflings", new List<Tag> { Tag.Outlaw, Tag.Thieves, Tag.Street }));
			dialoguePool.Add(new Dialogue("Night Music", new List<Tag> { Tag.Thieves, Tag.Outdoor }));
			dialoguePool.Add(new Dialogue("The Ambassador's Visit", new List<Tag> { Tag.Ambassador, Tag.Arcane, Tag.Outdoor, Tag.CityGuard, Tag.Noble }));
			dialoguePool.Add(new Dialogue("To the Palace", new List<Tag> { Tag.CityGuard, Tag.Outdoor, Tag.Noble }));
			dialoguePool.Add(new Dialogue("Vecna's Legend", new List<Tag> { Tag.Arcane, Tag.Cultists, Tag.Outdoor }));
			dialoguePool.Add(new Dialogue("Dragon Killer", new List<Tag> { Tag.Hunters, Tag.Outdoor, Tag.Noble }));
			InitializeEntityPool(dialoguePool);
		}

		public string GenerateDialogue(List<Tag> tags = null)
		{
			if (EntityPool.Count == 0)
			{
				return "There are no events left.";
			}

			Dialogue dialogue;

			if (tags == null)
			{
				EntityPool.Shuffle();

				dialogue = EntityPool[0];
			}
			else
			{
				dialogue = GetAppropriate(tags);
			}

			Entities.Add(dialogue);

			DialogueAddEvent dialogueEvent = new DialogueAddEvent
			{
				Dialogue = dialogue
			};
			dialogueEvent.FireEvent();

			EntityPool.Remove(dialogue);

			if (dialogue != null)
				return $"Triggered event: {dialogue.Name}";
			else
				return "Unable to trigger event.";
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
