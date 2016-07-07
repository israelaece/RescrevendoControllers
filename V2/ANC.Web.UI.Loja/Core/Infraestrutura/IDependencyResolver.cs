using System;

namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    public interface IDependencyResolver
    {
        T Get<T>();

        object Get(Type type);
    }
}