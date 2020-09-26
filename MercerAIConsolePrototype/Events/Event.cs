using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.Events
{
    public abstract class Event<T> where T : Event<T>
    {
        private bool eventFired = false;

        public delegate void EventListener(T info);
        private static event EventListener Listeners;

        public static void RegisterListener(EventListener listener)
        {
            Listeners += listener;
        }

        public static void UnregisterListener(EventListener listener)
        {
            Listeners -= listener;
        }

        public virtual void FireEvent()
        {
            if (eventFired)
            {
                Console.WriteLine("This Event has already fired. You cannot refire an event.");
            }

            eventFired = true;
            Listeners?.Invoke(this as T);
        }
    }
}
