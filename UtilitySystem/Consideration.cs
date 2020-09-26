using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitySystem
{
    public abstract class Consideration<T> : IConsideration
    {
        protected T DataContext { get; set; }
        protected bool IsRequired { get; set; } = false;

        public Consideration(T dataContext, bool isRequired = false)
        {
            DataContext = dataContext;
            IsRequired = isRequired;
        }

        public abstract Appraisal Evaluate();
    }
}
