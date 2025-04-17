using System;
using System.Collections.Generic;

namespace Core.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public void Subscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (!_subscribers.ContainsKey(type))
                _subscribers[type] = new List<Delegate>();

            _subscribers[type].Add(callback);
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                list.Remove(callback);
                if (list.Count == 0)
                    _subscribers.Remove(type);
            }
        }

        public void Publish<T>(T publishedEvent)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                foreach (var callback in list)
                {
                    ((Action<T>)callback)?.Invoke(publishedEvent);
                }
            }
        }
    }
}
