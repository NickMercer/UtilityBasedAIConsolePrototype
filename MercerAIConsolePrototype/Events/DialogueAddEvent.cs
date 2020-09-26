using MercerAIConsolePrototype.Game_State_Mock.Dialogues;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Events
{
    public class DialogueAddEvent : Event<DialogueAddEvent>
    {
        public Dialogue Dialogue { get; set; }
    }
}
