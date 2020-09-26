using MercerAIConsolePrototype.Game_State_Mock.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Events
{
    public class ItemAddEvent : Event<ItemAddEvent>
    {
        public Item Item { get; set; }
    }
}
