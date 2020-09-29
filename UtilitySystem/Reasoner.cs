using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitySystem
{
    public class Reasoner
    {
        private List<Choice> Choices = new List<Choice>();

        public Reasoner()
        {
        }

        public void AddChoice(Choice choice)
        {
            Choices.Add(choice);
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
            var choice = Choices.Where(x => x.Name == name).FirstOrDefault();

            if(choice != null)
                Choices.Remove(choice);
        }

        public List<float> GetScores()
        {
            return Choices.OrderByDescending(x => x.Utility).Select(x => x.Utility).ToList();
        }

        public List<Choice> GetChoices()
        {
            return Choices.OrderByDescending(x => x.Utility).ToList();
        }

        public void ScoreChoices()
        {
            foreach (var choice in Choices)
            {
                choice.ScoreUtility();
            } 
        }
    }
}
