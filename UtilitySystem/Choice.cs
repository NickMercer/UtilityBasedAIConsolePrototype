using System.Collections.Generic;

namespace UtilitySystem
{
    public class Choice
    {
        public delegate Appraisal Evaluation();

        public string Name { get; }
        public float Utility { get; private set; }

        private List<Evaluation> considerations = new List<Evaluation>();

        public Choice(string name, List<IConsideration> considerations = null)
        {
            Name = name;

            if(considerations != null)
            {
                foreach (IConsideration item in considerations)
                {
                    AddConsideration(item);
                }
            }
        }

        public void AddConsideration(IConsideration consideration)
        {
            considerations.Add(consideration.Evaluate);
        }

        internal float ScoreUtility()
        {
            float result = 0;

            foreach(var consideration in considerations)
            {
                var appraisal = consideration();

                if(appraisal.CanContinue == false)
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