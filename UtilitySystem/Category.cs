using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitySystem
{
    public class Category
    {
        public delegate Appraisal Evaluation();

        public string Name { get; }
        public float Utility { get; private set; }
        public float Weight { get; set; }

        private List<IConsideration> considerations = new List<IConsideration>();

        public Category(string name, float weight, List<IConsideration> considerations = null)
        {
            Name = name;
            Weight = weight;

            if (considerations != null)
            {
                foreach (IConsideration item in considerations)
                {
                    AddConsideration(item);
                }
            }
        }

        public void AddConsideration(IConsideration consideration)
        {
            considerations.Add(consideration);
        }

        internal float ScoreUtility()
        {
            float result = 0;

            foreach (var consideration in considerations)
            {
                var appraisal = consideration.Evaluate();

                if (appraisal.CanContinue == false)
                {
                    result = 0;
                    Utility = 0;
                    return result;
                }

                result += appraisal.Value;
            }

            result = result / considerations.Count;

            Utility = result;

            return result;
        }
    }
}
