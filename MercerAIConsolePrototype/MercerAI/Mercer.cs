using MercerAIConsolePrototype.Events;
using MercerAIConsolePrototype.Game_State_Mock.Players;
using MercerAIConsolePrototype.MercerAI.Considerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySystem;

namespace MercerAIConsolePrototype.MercerAI
{
    public class Mercer
    {
        private Agent Agent;
        private List<IMercerTrackable> Blackboard = new List<IMercerTrackable>();


        //TODO: set update frequency in config or something.
        private int updateFrequency = 3;
        private int updateCounter = 0;

        public Mercer()
        {
            Agent = new Agent();

            InitializeScenarioChoices();

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

            Agent.UpdateScores();
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
                Agent.UpdateScores();
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
            var choices = Agent.GetChoices();
            var result = new List<string>();

            foreach (var choice in choices)
            {
                result.Add($"Scenario: \"{choice.Name}\" - Score: {choice.Utility}");
            }
            return result;
        }

        private void InitializeScenarioChoices()
        {
            var scenarios = new List<Choice>();

            var scenario1 = new Choice("Bhaal's Wrath");
            var highPriority = new Category("High Priority", 0.7f);
            scenario1.AddConsideration(new ConObjectExists("Shrine to Bhaal", Blackboard), highPriority);
            scenario1.AddConsideration(new ConObjectExists("Cursed Statue", Blackboard), highPriority);
            scenario1.AddConsideration(new ConObjectExists("Staff of Bhaal", Blackboard));
            scenario1.AddConsideration(new ConObjectExists("Hunt the Bhaal Priests", Blackboard));
            scenario1.AddConsideration(new ConObjectExists("Forbidden Knowledge", Blackboard));
            scenario1.AddConsideration(new ConDistanceBetweenTiles("Shrine to Bhaal", "Cursed Statue", 4, 5, Blackboard), highPriority);
            scenario1.AddConsideration(new ConPlayerHasClass("Shadow", Blackboard));
            scenarios.Add(scenario1);

            var scenario2 = new Choice("The Great Hunt");
            scenario2.AddConsideration(new ConObjectExists("Beloved Ranger Statue", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("Rat Den", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("Crossbow", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("Wyrmstooth", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("The Hunter's Lodge Festivities", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("Ranger's Guild Initiation", Blackboard));
            scenario2.AddConsideration(new ConObjectExists("Dragon Killer", Blackboard));
            scenarios.Add(scenario2);

            var scenario3 = new Choice("The Thieves' Guild");
            var highPriority3 = new Category("High Priority", 0.6f);
            scenario3.AddConsideration(new ConObjectExists("Ambush Alley", Blackboard));
            scenario3.AddConsideration(new ConObjectExists("Rat Den", Blackboard));
            scenario3.AddConsideration(new ConObjectExists("Catacomb Landing", Blackboard));
            scenario3.AddConsideration(new ConObjectExists("The One Ring", Blackboard));
            scenario3.AddConsideration(new ConObjectExists("Into the Catacombs", Blackboard));
            scenario3.AddConsideration(new ConObjectExists("Night Music", Blackboard));
            scenario3.AddConsideration(new ConPlayerHasClass("Thievery", Blackboard, true), highPriority3);
            scenarios.Add(scenario3);

            Agent.AddChoices(scenarios);
        }
    }
}
