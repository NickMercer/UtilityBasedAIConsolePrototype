using System.Collections.Generic;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI
{
    public class Scenario
    {
        public Choice Choice { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public Scenario(Choice choice, List<Tag> tags = null)
        {
            Choice = choice;
            Tags = tags;

            if (Tags == null) Tags = new List<Tag>();
        }
    }
}