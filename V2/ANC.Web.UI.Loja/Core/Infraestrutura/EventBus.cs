using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    //public class EventBus : IEventPublisher
    //{
    //    private readonly Dictionary<Type, IList<Action<Event>>> handlers = new Dictionary<Type, IList<Action<Event>>>();

    //    public void Register<T>(Action<T> handler) where T : Event
    //    {
    //        GetOrAdd(typeof(T)).Add(e => handler((T)e));
    //    }

    //    private IList<Action<Event>> GetOrAdd(Type type)
    //    {
    //        IList<Action<Event>> events;

    //        if (!handlers.TryGetValue(type, out events))
    //        {
    //            events = new List<Action<Event>>();
    //            handlers.Add(type, events);
    //        }

    //        return events;
    //    }

    //    public void Publish<T>(T @event) where T : Event
    //    {
    //        IList<Action<Event>> events;

    //        if (handlers.TryGetValue(@event.GetType(), out events))
    //            foreach (var evt in events)
    //                evt(@event); //considere ser assíncrono
    //    }
    //}
}