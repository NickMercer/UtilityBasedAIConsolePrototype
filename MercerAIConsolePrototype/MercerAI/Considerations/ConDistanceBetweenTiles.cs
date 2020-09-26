using MercerAIConsolePrototype.Game_State_Mock.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI.Considerations
{
    public class ConDistanceBetweenTiles : Consideration<List<IMercerTrackable>>
    {
        private string tile1Name;
        private string tile2Name;
        private int desiredDistance;
        private int failureThreshold;

        public ConDistanceBetweenTiles(string tile1, string tile2, int desiredDistance, int failureThreshold, List<IMercerTrackable> dataContext, bool isRequired = false) : base(dataContext, isRequired)
        {
            DataContext = dataContext;
            IsRequired = isRequired;

            this.tile1Name = tile1;
            this.tile2Name = tile2;
            this.desiredDistance = desiredDistance;
            this.failureThreshold = failureThreshold;
        }

        public override Appraisal Evaluate()
        {
            var tiles = DataContext.OfType<Tile>();
            Tile tile1 = tiles.Where(x => x.Name == tile1Name).FirstOrDefault();
            Tile tile2 = tiles.Where(x => x.Name == tile2Name).FirstOrDefault();

            var appraisal = new Appraisal
            {
                CanContinue = true
            };

            if (tile1 == null || tile2 == null)
            {
                appraisal.Value = 0;
                if (IsRequired) appraisal.CanContinue = false;
            }
            else 
            {
                float actualDistance = Math.Abs(tile1.Location - tile2.Location);

                float difference = Math.Abs(actualDistance - desiredDistance);

                //Normalize the distance vs the desired distance.

                //Need to find a formula that turns a 0 into a 1 and then decreases towards 0 the higher the number gets. Past a threshold, say, 5, it just returns 0
                float utility = 1 - (difference / failureThreshold);

                appraisal.Value = utility;
            }

            return appraisal;
        }
    }
}
