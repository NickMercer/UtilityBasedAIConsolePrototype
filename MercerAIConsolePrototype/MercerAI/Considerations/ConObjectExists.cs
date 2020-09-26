using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI.Considerations
{
    public class ConObjectExists : Consideration<List<IMercerTrackable>>
    {
        private string itemName;
        private IMercerTrackable obj;

        public ConObjectExists(string name, List<IMercerTrackable> dataContext, bool isRequired = false) : base(dataContext, isRequired)
        {
            DataContext = dataContext;
            IsRequired = isRequired;
            itemName = name;
        }

        public ConObjectExists(IMercerTrackable obj, List<IMercerTrackable> dataContext, bool isRequired = false) : base(dataContext, isRequired)
        {
            DataContext = dataContext;
            IsRequired = isRequired;
            this.obj = obj;
        }

        public override Appraisal Evaluate()
        {
            float result = 0;

            if(DataContext.Contains(obj))
            {
                result = 1;
            }

            if(DataContext.Where(x => x.Name == itemName).Count() > 0)
            {
                result = 1;
            }

            var canContinue = true;
            if (IsRequired && result == 0) canContinue = false;

            var appraisal = new Appraisal
            {
                CanContinue = canContinue,
                Value = result
            };

            return appraisal;
        }
    }
}
