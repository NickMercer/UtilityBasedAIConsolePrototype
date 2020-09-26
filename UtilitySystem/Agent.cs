using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitySystem
{
    public class Agent
    {
        private Reasoner reasoner;

        public Agent()
        {
            reasoner = new Reasoner(this);
        }

        public void AddChoice(Choice choice)
        {
            reasoner.AddChoice(choice);
        }

        public void AddChoices(List<Choice> choices)
        {
            foreach (var choice in choices)
            {
                AddChoice(choice);
            }
        }

        public void RemoveChoice(string name)
        {
            reasoner.RemoveChoice(name);
        }

        public void UpdateScores()
        {
            reasoner.ScoreChoices();
        }

        public List<float> GetScores()
        {
            return reasoner.GetScores();
        }

        public List<Choice> GetChoices()
        {
            return reasoner.GetChoices();
        }
    }
}
