using MercerAIConsolePrototype.Game_State_Mock.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI.Considerations
{
    public class ConPlayerHasClass : Consideration<List<IMercerTrackable>>
    {
        private string className;

        public ConPlayerHasClass(string className, List<IMercerTrackable> dataContext, bool isRequired = false) : base(dataContext, isRequired)
        {
            DataContext = dataContext;
            IsRequired = isRequired;

            this.className = className;
        }

        public override Appraisal Evaluate()
        {
            float result = 0;

            var players = DataContext.OfType<Player>();

            if (players.Where(x => (x.Class1 == className || x.Class2 == className)).Count() > 0)
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
