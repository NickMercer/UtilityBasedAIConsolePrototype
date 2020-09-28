using MercerAIConsolePrototype.MercerAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Game_State_Mock.Players
{
    public class Player : IMercerTrackable, IEntity
    {

        public string Name { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public List<Tag> Tags { get; set; }

        public Player(string name, string class1, string class2 = "", List<Tag> tags = null)
        {
            Name = name;
            Class1 = class1;
            if (class2 != "") Class2 = class2;
            
            Tags = tags;
            if (Tags == null) tags = new List<Tag>();
        }
    }
}
