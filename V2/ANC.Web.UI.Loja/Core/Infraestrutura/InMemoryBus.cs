using System;
using System.Collections.Generic;
using System.Linq;

namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    public class InMemoryBus : IBus
    {
        private readonly IList<Type> handlers = new List<Type>();
        private readonly IDependencyResolver dependencyResolver;

        public InMemoryBus(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public void RegisterHandler<T>()
        {
            this.handlers.Add(typeof(T));
        }

        public void Send<T>(T command) where T : Command
        {
            Invoke<T>(command);
        }

        public void Dispatch<T>(T @event) where T : Event
        {
            Invoke<T>(@event);
        }

        private void Invoke<T>(Message message) where T : Message
        {
            var handlerType = typeof(IHandler<>).MakeGenericType(typeof(T));

            foreach (var handler in handlers.Where(h => handlerType.IsAssignableFrom(h)))
                ((IHandler<T>)this.dependencyResolver.Get(handler)).Handle((T)message);
        }
    }
}