using ANC.Web.UI.Loja.Core.Infraestrutura;
using Microsoft.Practices.Unity;
using System;

namespace ANC.Web.UI.Loja.Util
{
    public class DependenciasDoDominio : IDependencyResolver
    {
        private readonly IUnityContainer container;

        public DependenciasDoDominio(IUnityContainer container)
        {
            this.container = container;
        }

        public T Get<T>()
        {
            return this.container.Resolve<T>();
        }

        public object Get(Type type)
        {
            return this.container.Resolve(type, null);
        }
    }
}