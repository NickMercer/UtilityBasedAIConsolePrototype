using MercerAIConsolePrototype.Events;
using MercerAIConsolePrototype.Game_State_Mock.Players;
using MercerAIConsolePrototype.MercerAI.Considerations;
using MercerAIConsolePrototype.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI
{
    public class Mercer
    {
        private Reasoner Reasoner;
        private List<IMercerTrackable> Blackboard = new List<IMercerTrackable>();
        private List<Scenario> Scenarios = new List<Scenario>();


        //TODO: set update frequency and scenario count to promote in config or something.
        private int updateFrequency = 3;
        private int updateCounter = 0;

        private int topScenarioCount = 2;
        

        public Mercer()
        {
            Reasoner = new Reasoner();

            InitializeScenarios();

            GameStartEvent.RegisterListener(OnGameStart);
            ItemAddEvent.RegisterListener(OnItemAdd);
            DialogueAddEvent.RegisterListener(OnDialogueAdd);
        }

        ~Mercer()
        {
            GameStartEvent.UnregisterListener(OnGameStart);
            ItemAddEvent.UnregisterListener(OnItemAdd);
            DialogueAddEvent.UnregisterListener(OnDialogueAdd);
        }

        #region Events
        private void OnGameStart(GameStartEvent info)
        {
            foreach (IMercerTrackable tile in info.TileSet)
            {
                Blackboard.Add(tile);
            }

            foreach (IMercerTrackable player in info.PlayerSet)
            {
                Blackboard.Add(player); 
            }

            Reasoner.ScoreChoices();
        }

        private void OnItemAdd(ItemAddEvent info)
        {
            Blackboard.Add(info.Item);
            UpdateState();
        }

        private void OnDialogueAdd(DialogueAddEvent info)
        {
            Blackboard.Add(info.Dialogue);
            UpdateState();
        }

        private void UpdateState()
        {
            updateCounter++;
            if (updateCounter >= updateFrequency)
            {
                updateCounter = 0;
                Reasoner.ScoreChoices();
            }
        }

        #endregion

        public List<string> GetTrackableNames()
        {
            var names = new List<string>();
            foreach (var item in Blackboard)
            {
                names.Add(item.Name);
            }

            return names;
        }

        public List<string> GetScores()
        {
            var choices = Reasoner.GetChoices();
            var result = new List<string>();

            foreach (var choice in choices)
            {
                result.Add($"Scenario: \"{choice.Name}\" - Score: {choice.Utility}");
            }
            return result;
        }

        public List<Tag> GetRecommendedTags()
        {
            var tags = new List<Tag>();

            var topScenarios = Scenarios.OrderByDescending(x => x.Choice.Utility).Take(Math.Min(Scenarios.Count(), topScenarioCount));

            foreach(Scenario scenario in topScenarios)
            {
                foreach (var tag in scenario.Tags)
                {
                    tags.Add(tag);
                }
            }

            tags.Shuffle();

            if (tags.Count() > 3) tags.RemoveRange(3, tags.Count() - 3);

            return tags;
        }

        private void InitializeScenarios()
        {
            
            var choice1 = new Choice("Bhaal's Wrath");
            var tags1 = new List<Tag> { Tag.Bhaal, Tag.Arcane, Tag.Cultists };

            var highPriority = new Category("High Priority", 0.6f);
            choice1.AddConsideration(new ConObjectExists("Shrine to Bhaal", Blackboard), highPriority);
            choice1.AddConsideration(new ConObjectExists("Cursed Statue", Blackboard), highPriority);
            choice1.AddConsideration(new ConDistanceBetweenTiles("Shrine to Bhaal", "Cursed Statue", 4, 5, Blackboard), highPriority);

            choice1.AddConsideration(new ConObjectExists("Staff of Bhaal", Blackboard));
            choice1.AddConsideration(new ConObjectExists("Hunt the Bhaal Priests", Blackboard));
            choice1.AddConsideration(new ConObjectExists("Forbidden Knowledge", Blackboard));
            choice1.AddConsideration(new ConPlayerHasClass("Shadow", Blackboard));
            var scenario1 = new Scenario(choice1, tags1);
            Scenarios.Add(scenario1);


            var choice2 = new Choice("The Great Hunt");
            var tags2 = new List<Tag> { Tag.Hunters, Tag.Outdoor, Tag.Noble };

            choice2.AddConsideration(new ConObjectExists("Beloved Ranger Statue", Blackboard));
            choice2.AddConsideration(new ConObjectExists("Rat Den", Blackboard));
            choice2.AddConsideration(new ConObjectExists("Crossbow", Blackboard));
            choice2.AddConsideration(new ConObjectExists("Wyrmstooth", Blackboard));
            choice2.AddConsideration(new ConObjectExists("The Hunter's Lodge Festivities", Blackboard));
            choice2.AddConsideration(new ConObjectExists("Ranger's Guild Initiation", Blackboard));
            choice2.AddConsideration(new ConObjectExists("Dragon Killer", Blackboard));
            var scenario2 = new Scenario(choice2, tags2);
            Scenarios.Add(scenario2);


            var choice3 = new Choice("The Thieves' Guild");
            var tags3 = new List<Tag> { Tag.Outlaw, Tag.Thieves, Tag.Underground, Tag.Catacombs, Tag.CityGuard };

            var highPriority3 = new Category("High Priority", 0.6f);
            choice3.AddConsideration(new ConPlayerHasClass("Thievery", Blackboard, true), highPriority3);


            choice3.AddConsideration(new ConObjectExists("Ambush Alley", Blackboard));
            choice3.AddConsideration(new ConObjectExists("Rat Den", Blackboard));
            choice3.AddConsideration(new ConObjectExists("Catacomb Landing", Blackboard));
            choice3.AddConsideration(new ConObjectExists("The One Ring", Blackboard));
            choice3.AddConsideration(new ConObjectExists("Into the Catacombs", Blackboard));
            choice3.AddConsideration(new ConObjectExists("Night Music", Blackboard));
            var scenario3 = new Scenario(choice3, tags3);
            Scenarios.Add(scenario3);

            Scenarios.ForEach(x => Reasoner.AddChoice(x.Choice));
        }
    }
}
