using System;
using System.Collections.Generic;

namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    //public class CommandBus : ICommandSender
    //{
    //    private readonly Dictionary<Type, Action<Command>> handlers = new Dictionary<Type, Action<Command>>();

    //    public void Register<T>(Action<T> handler) where T : Command
    //    {
    //        var type = typeof(T);

    //        if (!handlers.ContainsKey(type))
    //            handlers.Add(type, x => handler((T)x));
    //    }

    //    public void Send<T>(T command) where T : Command
    //    {
    //        handlers[command.GetType()](command);
    //    }
    //}
}