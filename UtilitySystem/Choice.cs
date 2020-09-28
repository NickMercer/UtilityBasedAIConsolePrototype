using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilitySystem
{
    public class Choice
    {
        public delegate Appraisal Evaluation();

        public string Name { get; }
        public float Utility { get; private set; }

        private List<Category> categories = new List<Category>();


        public Choice(string name, List<Category> categories = null)
        {
            Name = name;

            if(categories != null)
            {
                foreach (Category item in categories)
                {
                    AddCategory(item);
                }
            }
        }


        public void AddCategory(Category category)
        {
            categories.Add(category);
        }
        public Category GetCategory(string categoryName)
        {
            return categories.Where(x => x.Name == categoryName).FirstOrDefault();
        }

        public void AddConsideration(IConsideration consideration, Category category = null)
        {
            if(category == null)
            {
                category = GetCategory("Default");

                if(category == null)
                {
                    AddCategory(new Category("Default", 1.0f));
                    category = GetCategory("Default");
                }
            }

            if (!categories.Contains(category))
            {
                AddCategory(category);
            }
            
            category.AddConsideration(consideration);
        }
        public void AddConsideration(IConsideration consideration, string categoryName)
        {
            var category = categories.Where(x => x.Name == categoryName).FirstOrDefault();

            if (category != null)
            {
                category.AddConsideration(consideration);
            }
        }


        internal float ScoreUtility()
        {
            float result = 0;

            foreach (var category in categories)
            {
                if(category.Name == "Default")
                {
                    category.Weight = (1f -  categories.Where(x => x.Name != "Default").Sum(x => x.Weight));
                }

                category.ScoreUtility();

                result += category.Utility * category.Weight;
            }

            Utility = result;

            return result;
        }
    }
}