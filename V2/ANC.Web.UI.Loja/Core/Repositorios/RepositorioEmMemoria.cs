using ANC.Web.UI.Loja.Core.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ANC.Web.UI.Loja.Core.Repositorios
{
    public abstract class RepositorioEmMemoria<T> where T : Entidade
    {
        private readonly IList<T> itens = new List<T>();

        public virtual void Adicionar(T entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            itens.Add(entity);
        }

        public T BuscarPor(Guid id)
        {
            return itens.SingleOrDefault(e => e.Id == id);
        }
    }
}