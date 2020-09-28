using MercerAIConsolePrototype.MercerAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Dialogues
{

    public class Dialogue : IMercerTrackable, IEntity
    {
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }

        public Dialogue(string name, List<Tag> tags = null)
        {
            Name = name;
            Tags = tags;

            if (Tags == null) tags = new List<Tag>();
        }
    }
}
