using System;

namespace YLAC.ConnectionTypes.SubscriptionBased.EventBroker
{
    public class EventBroker
    {
        public class BaseEvent { }

        public class EventManager //EventBus, Bus
        {
            public static EventManager Instance = new EventManager(); 
            public void Fire<TEvent>(TEvent @arg) { }
            public void Subscribe<TEvent>(Action<TEvent> callback) { }
            public void Unsubscribe<TEvent>(Action<TEvent> callback) { }
        }
    }
}